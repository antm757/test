using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class IDserch : Form
    {
        public IDserch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string phone = textBox2.Text;

            Connection c = new Connection();            
            c.command();
            c.cmd.CommandText = "select id from usertbl where name = '" + name + "' and phone = '" + phone + "'";

            SqlDataAdapter da = new SqlDataAdapter(c.cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertbl");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "usertbl";

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Loginform_Pw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}
