using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;


namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class TestRequestEntryForm : System.Web.UI.Page
    {
        private DataBase db = new DataBase();

        private void Load_DropDownList()
        {
            db.Command.CommandText = "SELECT TEST_ID, TEST_NAME FROM TEST";
            db.Connection.Open();
            SqlDataReader reader = db.Command.ExecuteReader();


            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TEST_ID", typeof(int));
                dt.Columns.Add("TEST_NAME", typeof(string));

                while (reader.Read())
                {
                    dt.Rows.Add(Convert.ToInt32(reader["TEST_ID"].ToString()), reader["TEST_NAME"].ToString());
                }

                selectTestDropDownList.DataSource = dt;
                selectTestDropDownList.DataTextField = "TEST_NAME";
                selectTestDropDownList.DataValueField = "TEST_ID";
                selectTestDropDownList.DataBind();

                selectTestDropDownList.Items.Insert(0, "--select--");

                
            }
            db.Connection.Close();

            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_DropDownList();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            List<Test> testList = new List<Test>();
            double totalAmount = 0;
            
            if (ViewState["List"] != null)
            {
                testList = (List<Test>)ViewState["List"];
            }

            if (ViewState["totalAmount"] != null)
            {
                totalAmount += (double) ViewState["totalAmount"];
            }

            Test newTest = (Test) ViewState["newTest"];

            totalAmount += newTest.TestFee;
            totalAmountTextBox.Text = totalAmount.ToString(CultureInfo.InvariantCulture);

            ViewState["totalAmount"] = totalAmount;

            bool added = false;

            foreach (Test data in testList)
            {
                if (data.TestName == newTest.TestName)
                    added = true;

            }
            if (added == false)
            {
                testList.Add(newTest);
            }
            else
            {
                string script = "alert(\"Test is already added !\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
           
            
            ViewState["List"] = testList;
            selectedTestGridView.DataSource = testList;
            selectedTestGridView.DataBind();
        }


        protected void itemSelected(object sender, EventArgs e)
        {
            db.Command.CommandText = "SELECT TEST_ID, TEST_NAME, TEST_FEE FROM TEST WHERE TEST_ID = " + selectTestDropDownList.SelectedValue + ";";
            db.Connection.Open();
            SqlDataReader reader = db.Command.ExecuteReader();

            while (reader.Read())
            {
                Test newTest = new Test();
                newTest.TestId = Convert.ToInt32(reader["TEST_ID"].ToString());
                newTest.TestName = reader["TEST_NAME"].ToString();
                newTest.TestFee = Convert.ToDouble(reader["TEST_FEE"].ToString());


                ViewState["newTest"] = newTest;
                testFeeTextBox.Text = newTest.TestFee.ToString(CultureInfo.InvariantCulture);
            }
            db.Connection.Close();
        }

        private string GenerateBillNo()
        {
            string billNo;

            DateTime dt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            string yy = dt.Year.ToString();
            billNo = yy[2].ToString() + yy[3].ToString();
            if (dt.Month < 10)
            {
                billNo += "0";
            }
            billNo += dt.Month.ToString();
            if (dt.Day < 10)
            {
                billNo += "0";
            }
            billNo += dt.Day.ToString();

            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = rand.Next(1000, 9999);

            billNo += numIterations.ToString();
            return billNo;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            
            int patId = 0;

            db.Command.CommandText = "INSERT INTO PATIENT(PAT_NAME, PAT_BIRTHDATE, PAT_MOBILENO) VALUES(@patName, @patBirthDate, @patMobileNo);";
            db.Command.Parameters.AddWithValue("@patName", patientNameTextBox.Text);
            db.Command.Parameters.AddWithValue("@patBirthDate", Convert.ToDateTime(patientBirthDateTextBox.Text));
            db.Command.Parameters.AddWithValue("@patMobileNo", patientMobileNoTextBox.Text);

            db.Connection.Open();
            db.Command.ExecuteNonQuery();
            db.Connection.Close();


            db.Command.CommandText = "SELECT PAT_ID FROM PATIENT WHERE PAT_MOBILENO = '" +
                                     patientMobileNoTextBox.Text +
                                     "';";
            db.Connection.Open();
            SqlDataReader reader = db.Command.ExecuteReader();
            while (reader.Read())
            {
                patId = Convert.ToInt32(reader["PAT_ID"].ToString());
            }
            db.Connection.Close();

            string billNo = GenerateBillNo();
            bool recordExist = true;
            while (recordExist)
            {
                billNo = GenerateBillNo();
                db.Command.CommandText = "SELECT COUNT(*) AS NUM FROM BILL_INFORMATION WHERE BILL_NO = " + billNo + ";";
                db.Connection.Open();
                reader = db.Command.ExecuteReader();
                while(reader.Read())
                {
                    if (reader["NUM"].ToString() == "0")
                        recordExist = false;
                }
                db.Connection.Close();
                
            }

            db.Command.CommandText = "INSERT INTO BILL_INFORMATION(BILL_NO, TOTAL_AMOUNT, TOTAL_PAID, TOTAL_DUE, BILL_DATE, PAT_ID) VALUES(" +
                                     billNo +
                                     ", @totalAmount, 0, @totalDue, @billDate," + patId.ToString() + ");";
            db.Command.Parameters.AddWithValue("@totalAmount", totalAmountTextBox.Text);
            db.Command.Parameters.AddWithValue("@totalDue", totalAmountTextBox.Text);
            db.Command.Parameters.AddWithValue("@billDate", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));

            db.Connection.Open();
            db.Command.ExecuteNonQuery();

            db.Connection.Close();

            List<Test> testList = (List<Test>) ViewState["List"];
            
            
            
            foreach (Test newTest in testList)
            {
                db.Command.CommandText = "INSERT INTO PAT_TEST_REQ(TEST_ID, PAT_ID, TEST_DATE, BILL_NO) VALUES ";
                db.Command.CommandText += "(" + newTest.TestId + "," + patId.ToString() + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + billNo + ");";
                db.Connection.Open();
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
        
        }
    }
}