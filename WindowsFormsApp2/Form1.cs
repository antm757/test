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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Connection()
        {
            string dbcon = "Server=.\\SQLEXPRESS; Uid=jw_seo;Pwd =1234; database=windowform; ";
            try
            {
                SqlConnection conn = new SqlConnection(dbcon);
                
                SqlCommand cmd = new SqlCommand();

                conn.Open();

                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Connection();
            MessageBox.Show("연결성공");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection();
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Uid=jw_seo;Pwd =1234; database=windowform; ");           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from usertbl";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "usertbl");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "usertbl";
        }
    }
}
