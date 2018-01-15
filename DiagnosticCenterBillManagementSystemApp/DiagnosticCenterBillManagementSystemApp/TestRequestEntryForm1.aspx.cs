using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class TestRequestEntryForm1 : System.Web.UI.Page
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
                totalAmount += (double)ViewState["totalAmount"];
            }

            Test newTest = (Test)ViewState["newTest"];

            totalAmount += newTest.TestFee;
            //totalAmountTextBox.Text = totalAmount.ToString(CultureInfo.InvariantCulture);

            total_amount.Value = totalAmount.ToString();

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

            int serial = 1;

            DataTable dt = new DataTable();
            dt.Columns.Add("SL", typeof(int));
            dt.Columns.Add("TEST", typeof(string));
            dt.Columns.Add("FEE", typeof(double));

            foreach (Test data in testList)
            {
                DataRow row = dt.NewRow();

                row[0] = serial++;
                row[1] = data.TestName;
                row[2] = data.TestFee;

                dt.Rows.Add(row);
            }

            testGridView.DataSource = dt;
            testGridView.DataBind();

          

            
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
                test_fee.Value = newTest.TestFee.ToString();
                
            }
            db.Connection.Close();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (name.Value.Length == 0)
            {
                string script = "alert(\"Name is Required !\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                if (bday.Value.Length == 0)
                {
                    string script = "alert(\"Birth Date is Required !\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    if (Mobile_no.Value.Length == 0)
                    {
                        string script = "alert(\"Mobile No is Required !\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
                        
                        if (selectTestDropDownList.SelectedValue == "--select--")
                        {
                            string script = "alert(\"Test Selection is Required !\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }
                        else
                        {
                            
                           
                            if (total_amount.Value == "")
                            {
                                string script = "alert(\"Add a Test !\");";
                                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            }
                            else
                            {
                                int patId = 0;

                                db.Command.CommandText = "INSERT INTO PATIENT(PAT_NAME, PAT_BIRTHDATE, PAT_MOBILENO)  SELECT @patName, @patBirthDate, @patMobileNo WHERE NOT EXISTS(SELECT * FROM PATIENT WHERE PAT_MOBILENO = @patMobileNo);";
                                db.Command.Parameters.AddWithValue("@patName", name.Value);
                                db.Command.Parameters.AddWithValue("@patBirthDate", Convert.ToDateTime(bday.Value));
                                db.Command.Parameters.AddWithValue("@patMobileNo", Mobile_no.Value);

                                db.Connection.Open();
                                int affectedRow = db.Command.ExecuteNonQuery();
                                db.Connection.Close();

                                if (affectedRow == 0)
                                {
                                    string script = "alert(\"Mobile NO already exists !\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script,
                                        true);
                                }
                                else
                                {
                                    db.Command.CommandText = "SELECT PAT_ID FROM PATIENT WHERE PAT_MOBILENO = '" +
                                                             Mobile_no.Value +
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
                                        while (reader.Read())
                                        {
                                            if (reader["NUM"].ToString() == "0")
                                                recordExist = false;
                                        }
                                        db.Connection.Close();

                                    }

                                    db.Command.CommandText = "INSERT INTO BILL_INFORMATION(BILL_NO, TOTAL_AMOUNT, TOTAL_PAID, TOTAL_DUE, BILL_DATE, PAT_ID) VALUES(" +
                                                             billNo +
                                                             ", @totalAmount, 0, @totalDue, @billDate," + patId.ToString() + ");";
                                    db.Command.Parameters.AddWithValue("@totalAmount", total_amount.Value);
                                    db.Command.Parameters.AddWithValue("@totalDue", total_amount.Value);
                                    db.Command.Parameters.AddWithValue("@billDate", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));

                                    db.Connection.Open();
                                    db.Command.ExecuteNonQuery();

                                    db.Connection.Close();

                                    List<Test> testList = (List<Test>)ViewState["List"];



                                    foreach (Test newTest in testList)
                                    {
                                        db.Command.CommandText = "INSERT INTO PAT_TEST_REQ(TEST_ID, PAT_ID, TEST_DATE, BILL_NO) VALUES ";
                                        db.Command.CommandText += "(" + newTest.TestId + "," + patId.ToString() + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "'," + billNo + ");";
                                        db.Connection.Open();
                                        db.Command.ExecuteNonQuery();
                                        db.Connection.Close();
                                    }
                                    string script = "alert(\"Successfully Added !\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                                    name.Value = "";
                                    bday.Value = "";
                                    Mobile_no.Value = "";
                                    total_amount.Value = "";

                                    DataTable dt = new DataTable();
                                    dt.Columns.Add("SL", typeof(int));
                                    dt.Columns.Add("TEST", typeof(string));
                                    dt.Columns.Add("FEE", typeof(double));

                                    testGridView.DataSource = dt;
                                    testGridView.DataBind();

                                    Load_DropDownList();

                                }


                                

                            }
                        }
             
                    
                    }
                }
            }
            
        }


        
    }
}