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
    public partial class Regform : Form
    {
        Connectionclass con = new Connectionclass();
        public Regform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            if(radioButton1.Checked)
            {
                s = radioButton1.Text;
            }
            else if(radioButton2.Checked)
            {
                s = radioButton2.Text;
            }
            string d = "";
            foreach(string i in checkedListBox1.CheckedItems)
            {
                d = d + i + ",";
            }
            string newdt = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()).ToString("yyyy-MM-dd");
            string str = "insert into windowapp values('" + textBox1.Text + "','" + richTextBox1.Text + "','" + s + "','" + comboBox1.SelectedItem.ToString() + "','" + newdt + "','" + d + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            int il = con.Fn_Nonquery(str);
            if (il != 0)
                label9.Text = "inserted";
        }
    }
}
