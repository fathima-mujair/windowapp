using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Windowapp
{
    public partial class profile : Form
    {
        Connectionclass con = new Connectionclass();
        public profile()
        {
            InitializeComponent();
        }

        private void profile_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Login.A.P1);
            string s = "select * from windowapp where id=" + id + "";
            SqlDataReader dr = con.Fn_Reader(s);
            while(dr.Read())
            {
                label5.Text = dr["name"].ToString();
                label6.Text= dr["address"].ToString();
                label7.Text= dr["Gender"].ToString();
                label8.Text= dr["state"].ToString();
            }

            DataSet ds = con.Fn_Dataset(s);
            dataGridView1.DataSource = ds.Tables[0];

            DataTable dt = con.Fn_DataTable(s);
            dataGridView2.DataSource = dt;
        }
    }
}
