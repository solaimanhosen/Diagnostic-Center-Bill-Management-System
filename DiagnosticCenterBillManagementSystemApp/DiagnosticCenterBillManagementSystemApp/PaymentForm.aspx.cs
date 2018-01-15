using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class PaymentForm : System.Web.UI.Page
    {   private DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (billno.Value.Length >= 0 && mobileno.Value.Length == 0)
            {
                if (billno.Value.Length == 10)
                {
                    db.Command.CommandText = "SELECT TOTAL_AMOUNT, TOTAL_DUE, BILL_DATE FROM BILL_INFORMATION WHERE BILL_NO = " + billno.Value + ";";
                    db.Connection.Open();
                    SqlDataReader reader = db.Command.ExecuteReader();
                    int affectedRow = 0;
                    while (reader.Read())
                    {
                        affectedRow++;
                        amount.Value = reader["TOTAL_AMOUNT"].ToString();
                        ViewState["TOTAL_DUE"] = reader["TOTAL_DUE"].ToString();
                        string date = reader["BILL_DATE"].ToString();
                        entrydate.Value = date.Substring(0, 10);
                    }
                    if (affectedRow == 0)
                    {
                        string script = "alert(\"Bill No is not Exists !\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        billno.Value = "";
                        entrydate.Value = "";
                        amount.Value = "";
                    }
                    db.Connection.Close();
                }
                else
                {
                    string script = "alert(\"Bill No is not valid !\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    billno.Value = "";
                    mobileno.Value = "";
                }
            }
            if (billno.Value.Length == 0 && mobileno.Value.Length >= 0)
            {
                if (mobileno.Value.Length == 11)
                {
                    db.Command.CommandText = "SELECT TOTAL_AMOUNT, TOTAL_DUE, BILL_DATE FROM BILL_INFORMATION, PATIENT WHERE BILL_INFORMATION.PAT_ID = (SELECT PAT_ID FROM PATIENT WHERE PAT_MOBILENO = '" + mobileno.Value + "');";
                    db.Connection.Open();
                    SqlDataReader reader = db.Command.ExecuteReader();
                    int affectedRow = 0;
                    while (reader.Read())
                    {
                        affectedRow++;
                        amount.Value = reader["TOTAL_AMOUNT"].ToString();
                        ViewState["TOTAL_DUE"] = reader["TOTAL_DUE"].ToString();
                        string date = reader["BILL_DATE"].ToString();
                        entrydate.Value = date.Substring(0, 10);
                    }
                    if (affectedRow == 0)
                    {
                        string script = "alert(\"Mobile No is not Exists !\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        billno.Value = "";
                        entrydate.Value = "";
                        amount.Value = "";
                    }
                    db.Connection.Close();
                }
                else
                {
                    string script = "alert(\"Mobile No is not valid !\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    billno.Value = "";
                    mobileno.Value = "";
                }
            }
            if (billno.Value.Length > 0 && mobileno.Value.Length > 0)
            {
                string script = "alert(\"Enter either Mobile No or Bill No !\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                billno.Value = "";
                mobileno.Value = "";
            }
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            billno.Value = "";
            mobileno.Value = "";
            entrydate.Value = "";
            amount.Value = "";

            double totalDue = Convert.ToDouble(ViewState["TOTAL_DUE"].ToString());
            if (totalDue == 0)
            {
                string script = "alert(\"BILL ALREADY PAID !!!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                if (billno.Value.Length > 0)
                {
                    db.Command.CommandText = "UPDATE BILL_INFORMATION SET TOTAL_PAID = " + amount.Value + ", TOTAL_DUE = 0" +
                                             "WHERE BILL_NO = " + billno.Value + ";";
                    db.Connection.Open();
                    db.Command.ExecuteNonQuery();
                    db.Connection.Close();

                }
                else
                {
                    db.Command.CommandText = "UPDATE BILL_INFORMATION SET TOTAL_PAID = " + amount.Value + ", TOTAL_DUE = 0" +
                                             "WHERE PAT_ID = (SELECT PAT_ID FROM PATIENT WHERE PAT_MOBILENO = " + mobileno.Value + ");";
                    db.Connection.Open();
                    db.Command.ExecuteNonQuery();
                    db.Connection.Close();
                }
                
                string script = "alert(\"Successfully Paid !\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            
        }
    }
}