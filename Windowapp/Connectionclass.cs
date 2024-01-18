using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Windowapp
{
    public class Connectionclass
    {
        SqlCommand cmd;
        SqlConnection con;
        public Connectionclass()
        {
            con = new SqlConnection(@"server=DESKTOP-3HUC9PM\SQLEXPRESS;database=Windowapp;Integrated security=true");

        }
        public int Fn_Nonquery(string sqlquery)//insert,delete,update
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public string Fn_Scalar(string sqlquery)//scalar function
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;
        }
        public SqlDataReader Fn_Reader(string sqlquery)//insert,delete.update
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;//here we can't close the connection

        }
        public DataSet Fn_Dataset(string sqlquery)//here use data set(collection of datatable
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataSet ds = new DataSet();//collection of data tables
            da.Fill(ds);
            return ds;

        }
        //here we can use datables(here we directly use datatable from dataset
        public DataTable Fn_DataTable(string sqlquery)//insert,delete.update
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataTable dt = new DataTable();//collection of data tables
            //we can substiyute "data table"instead of data set
            da.Fill(dt);//
            return dt;//here we can't close the connection

        }
    }
}
