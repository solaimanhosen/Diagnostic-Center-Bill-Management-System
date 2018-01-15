using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystemApp
{
    public class DataBase
    {
        public SqlConnection Connection;
        public SqlCommand Command;

        public DataBase()
        {
            Connection = new SqlConnection();
            Command = new SqlCommand();
            //Connection.ConnectionString = ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString;
            Connection.ConnectionString = "Server=DESKTOP-OE85NNT\\SQLEXPRESS;Database=DiagnosticCenterDB;Trusted_Connection=True;";
            Command.Connection = Connection;
        }
    }
}