using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Windowapp
{
    public partial class Login : Form
    {
        Connectionclass con = new Connectionclass();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "select count(id) from windowapp where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
            string i = con.Fn_Scalar(s);
            if (i == "1")
            {

                string selid = "select id from windowapp where username = '" + textBox1.Text + "'and password = '" + textBox2.Text + "'";
                string id = con.Fn_Scalar(selid);
                int uid = Convert.ToInt32(id);

                A.P1 = uid;
                profile obj = new profile();
                obj.Show();
                this.Hide();
            }
            else
                label3.Text = "invalid username and password";
        }
        public static class A
        {
            public static int P1

            {
                set;
                get;
            }        }
    }
    
}
