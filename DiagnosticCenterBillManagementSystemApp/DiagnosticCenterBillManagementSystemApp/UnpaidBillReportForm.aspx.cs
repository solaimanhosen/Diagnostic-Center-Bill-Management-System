using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace DiagnosticCenterBillManagementSystemApp
{
    public partial class UnpaidBillReportForm : System.Web.UI.Page
    {
        private DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string GenerateInvoiceNo()
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

        protected void showButton_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(fromDateTextBox.Value);
            DateTime toDate = Convert.ToDateTime(toDateTextBox.Value);

            db.Command.CommandText = "SELECT BILL_NO, PAT_NAME, PAT_MOBILENO, TOTAL_DUE FROM BILL_INFORMATION, PATIENT" +
                                     " WHERE BILL_INFORMATION.PAT_ID = PATIENT.PAT_ID AND " +
                                     "BILL_INFORMATION.TOTAL_DUE > 0 AND " +
                                     "BILL_DATE BETWEEN '" + fromDate.Date.ToString("yyyy-MM-dd") + "' AND '" + toDate.Date.ToString("yyyy-MM-dd") +"';";
            db.Connection.Open();
            SqlDataReader reader = db.Command.ExecuteReader();

            int serial = 1;
            DataTable dt = new DataTable();

            dt.Columns.Add("SL", typeof(int));
            dt.Columns.Add("Bill Number", typeof(string));
            dt.Columns.Add("Contact No", typeof(string));
            dt.Columns.Add("Patient Name", typeof(string));
            dt.Columns.Add("Bill Amount", typeof(string));

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                row[0] = serial++;
                row[1] = reader["BILL_NO"].ToString();
                row[2] = reader["PAT_MOBILENO"].ToString();
                row[3] = reader["PAT_NAME"].ToString();
                row[4] = reader["TOTAL_DUE"].ToString();

                dt.Rows.Add(row);
            }
            db.Connection.Close();
            ViewState["unPaidBillReport"] = dt;
            unpaidBillGridView.DataSource = dt;
            unpaidBillGridView.DataBind();

            db.Command.CommandText = "WITH TOTAL_AM(BILL_NO, PAT_NAME, PAT_MOBILENO, TOTAL_DUE) AS ( SELECT BILL_NO, PAT_NAME, PAT_MOBILENO, TOTAL_DUE FROM BILL_INFORMATION, PATIENT" +
                                     " WHERE BILL_INFORMATION.PAT_ID = PATIENT.PAT_ID AND " +
                                     "BILL_INFORMATION.TOTAL_DUE > 0 AND " +
                                     "BILL_DATE BETWEEN '" + fromDate.Date.ToString("yyyy-MM-dd") + "' AND '" + toDate.Date.ToString("yyyy-MM-dd") + "' )" +
                                     "SELECT SUM(TOTAL_DUE) AS TOTAL FROM TOTAL_AM ;";
            db.Connection.Open();
            reader = db.Command.ExecuteReader();
            string totalBill = "";
            while (reader.Read())
            {
                totalBill = reader["TOTAL"].ToString();
                totalamount.Value = totalBill;
            }
            ViewState["totalbill"] = totalBill;
            db.Connection.Close();
            
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            string companyName = "MEDIPRO Diagnostic Center";
            int orderNo = Convert.ToInt32(GenerateInvoiceNo());
            DataTable dt = new DataTable();

            dt = (DataTable)ViewState["unPaidBillReport"];
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    //Generate Invoice (Bill) Header.
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append(
                        "<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>UnPaid Bill Report</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Invoice No: </b>");
                    sb.Append(orderNo);
                    sb.Append("</td><td align = 'right'><b>Date: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Company Name: </b>");
                    sb.Append(companyName);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");

                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<td>");
                        sb.Append(column.ColumnName);
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                    sb.Append("</table>");


                    //Generate Invoice (Bill) Items Grid.
                    sb.Append("<table border = '1'>");





                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>");
                            sb.Append(row[column]);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("<tr><td align = 'right' colspan = '");
                    sb.Append(dt.Columns.Count - 1);
                    sb.Append("'>Total</td>");
                    sb.Append("<td>");
                    string str = ViewState["totalbill"].ToString();
                    sb.Append(str);
                    //sb.Append(dt.Compute("sum(Total_Amount)", ""));
                    sb.Append("</td>");
                    sb.Append("</tr></table>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + orderNo + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}