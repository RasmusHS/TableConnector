using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WinFormsProgramName //Change this to match your projects namespace
{
    public class TableConnector
    {
        private string strconn = @""; //Insert your connection string here

        public object tableBinder(string sqlStatement)
        {
            SqlConnection conn = new SqlConnection(strconn); //Encapsulates conn string in an object
            conn.Open(); //opens connection to database

            string sqlS = sqlStatement; //SQL statement sent from the form
            SqlCommand cmd = new SqlCommand(sqlS, conn); //Encapsulates SQL statement in an object

            SqlDataAdapter sqlDA = new SqlDataAdapter(); //Bridge between data source (the SQL server) and the data table
            sqlDA.SelectCommand = cmd; //Assigns the SQL command to the data adapter

            DataTable dt = new DataTable(); //Creates a data table to hold the data
            sqlDA.Fill(dt); //Fills the data table with data from the data source (the SQL server) using the SQL command

            BindingSource bSource = new BindingSource(); //Creates a binding source object to hold the data table
            bSource.DataSource = dt; //Assigns the data table to the binding source object
            conn.Close(); //Closes the connection to the database
            sqlDA.Update(dt); //Updates the data grid view if INSERT, UPDATE or DELETE statements were made
            return bSource; //returns the binding source object back to the form that called the method
        }
    }
}
