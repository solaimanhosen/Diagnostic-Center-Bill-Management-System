using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;


namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class TestNameForm : System.Web.UI.Page
    {
        private DataBase db = new DataBase();

        private void Load_DropBox()
        {
            db.Command.CommandText = "SELECT * FROM TEST_TYPE;";
            db.Connection.Open();
            SqlDataReader reader = db.Command.ExecuteReader();
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TYPE_ID", typeof(int));
                dt.Columns.Add("TYPE_NAME", typeof(string));
                while (reader.Read())
                {
                    dt.Rows.Add(Convert.ToInt32(reader["TYPE_ID"].ToString()), reader["TYPE_NAME"].ToString());
                }

                testTypeDropDownList.DataSource = dt;
                testTypeDropDownList.DataTextField = "TYPE_NAME";
                testTypeDropDownList.DataValueField = "TYPE_ID";
                testTypeDropDownList.DataBind();

                testTypeDropDownList.Items.Insert(0, "--select--");
            }
            db.Connection.Close();
        }

        protected void saveTestButton_Click(object sender, EventArgs e)
        {
            string script;
            if (testTypeDropDownList.SelectedValue == "--select--")
            {
                script = "alert(\"Select a Test Type !\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                db.Command.CommandText = "INSERT INTO TEST(TEST_NAME, TEST_FEE, TYPE_ID) SELECT @testName, @testFee, @testType WHERE NOT EXISTS(SELECT * FROM TEST WHERE TEST_NAME = @testName);";
                db.Command.Parameters.AddWithValue("@testName", testname.Value);
                db.Command.Parameters.AddWithValue("@testFee", Convert.ToDouble(testfee.Value));
                db.Command.Parameters.AddWithValue("@testType", testTypeDropDownList.SelectedValue);
                db.Connection.Open();
                int affectedRow = db.Command.ExecuteNonQuery();


                if (affectedRow == 0)
                {
                    script = "alert(\"Test Name already Exists!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    script = "alert(\"Successfully Added !\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }


                testname.Value = "";
                testfee.Value = "";


                db.Connection.Close();
                Load_DropBox();
                Load_GridView();
                
            }
           
        }

        private void Load_GridView()
        {
            db.Command.CommandText = "SELECT TEST_NAME, TEST_FEE, TYPE_NAME FROM TEST, TEST_TYPE WHERE TEST.TYPE_ID = TEST_TYPE.TYPE_ID;";
            db.Connection.Open();
            SqlDataReader reader = db.Command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("SL", typeof(int));
            dt.Columns.Add("Test Name", typeof(string));
            dt.Columns.Add("Test Fee", typeof(double));
            dt.Columns.Add("Test Type", typeof(string));

            int serial = 1;

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row[0] = serial++;
                row[1] = reader["TEST_NAME"].ToString();
                row[2] = Convert.ToDouble(reader["TEST_FEE"].ToString());
                row[3] = reader["TYPE_NAME"].ToString();

                dt.Rows.Add(row);
            }

            testNameGridView.DataSource = dt;
            testNameGridView.DataBind();

            db.Connection.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Load_DropBox();
            Load_GridView();
        }
    }
}