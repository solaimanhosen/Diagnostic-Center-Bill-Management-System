using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;


namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class TestTypeSetupForm : System.Web.UI.Page
    {   private DataBase db = new DataBase();

        public void Load_GridView()
        {
            db.Command.CommandText = "SELECT TYPE_NAME FROM TEST_TYPE;";
            db.Connection.Open();
            SqlDataReader reader = db.Command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("SL", typeof(int));
            dt.Columns.Add("Type Name", typeof(string));

            int serial = 1;

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row[0] = serial++;
                row[1] = reader["TYPE_NAME"].ToString();
                dt.Rows.Add(row);
            }
            testTypeGridView.DataSource = dt;
            testTypeGridView.DataBind();

            db.Connection.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Load_GridView();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            db.Command.CommandText = "INSERT INTO TEST_TYPE(TYPE_NAME) SELECT @typeName WHERE NOT EXISTS (SELECT * FROM TEST_TYPE WHERE TYPE_NAME = @typeName);";
            db.Command.Parameters.AddWithValue("@typeName", typename.Value);
            db.Connection.Open();
            int affected_row = db.Command.ExecuteNonQuery();
            db.Connection.Close();
            Load_GridView();
            typename.Value = "";
            if (affected_row == 0)
            {
                MsgBox("Type Name already Exists !", this.Page, this);
                //string script = "alert(\"Type Name already Exists!\");";
                //ScriptManager.RegisterStartupScript(this, GetType(),"ServerControlScript", script, true);
            }
            else
            {
                string script = "alert(\"Successfully Added !\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            
            
        }
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}