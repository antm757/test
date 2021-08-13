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
    public partial class adminform : Form
    {
        public string Sex(bool a)
        {
            string male = "남성";
            string female = "여성";

            if (a == true)
                return male;
            else
                return female;
        }
        public string Nationality(bool a)
        {
            string korean = "내국인";
            string foreigner = "외국인";
            if (a == true)
            {
                return korean;
            }
            else
                return foreigner;
        }
        public adminform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection c = new Connection();
            c.cmd = new SqlCommand();
            c.command();
            c.cmd.CommandText = "select * from usertbl order by name";

            SqlDataAdapter da = new SqlDataAdapter(c.cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertbl");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "usertbl";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Hide();
                login loginform = new login();
                loginform.ShowDialog();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            Connection c = new Connection();
            c.cmd = new SqlCommand();
            c.command();
            c.cmd.CommandText = "select * from usertbl where name = '" + name + "'order by name";

            SqlDataAdapter da = new SqlDataAdapter(c.cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertbl");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "usertbl";

            c.conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;

            Connection c = new Connection();
            c.cmd = new SqlCommand();
            c.command();
            c.cmd.CommandText = "select * from usertbl where id = '" + id + "'";

            SqlDataAdapter da = new SqlDataAdapter(c.cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertbl");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "usertbl";

            c.conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string phone = textBox3.Text;
           
            Connection c = new Connection();
            c.cmd = new SqlCommand();
            c.command();
            c.cmd.CommandText = "select * from usertbl where phone = '" + phone + "'order by name";
            SqlDataAdapter da = new SqlDataAdapter(c.cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertbl");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "usertbl";

            c.conn.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string address = textBox4.Text;
            

            Connection c = new Connection();
            c.cmd = new SqlCommand();
            c.command();
            c.cmd.CommandText = "select * from usertbl where address1 = '" + address + "'order by name";
            SqlDataAdapter da = new SqlDataAdapter(c.cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertbl");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "usertbl";

            c.conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sex = Sex(radioButton1.Checked);

            Connection c = new Connection();
            c.cmd = new SqlCommand();
            c.command();
            c.cmd.CommandText = "select * from usertbl where sex = '" + sex + "'order by name";

            SqlDataAdapter da = new SqlDataAdapter(c.cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertbl");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "usertbl";

            c.conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string nationality = Nationality(radioButton3.Checked);

            Connection c = new Connection();
            c.cmd = new SqlCommand();
            c.command();
            c.cmd.CommandText = "select * from usertbl where nationality = '" + nationality + "'order by name";

            SqlDataAdapter da = new SqlDataAdapter(c.cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertbl");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "usertbl";
            c.conn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            signup signup = new signup();
            signup.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            adminpw adminpw = new adminpw();
            adminpw.ShowDialog();
        }
    }
}

      