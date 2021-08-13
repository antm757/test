using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {

            string id, pw;
            string adminid="admin", adminpw="1234";
            bool login = false;
            bool admin = false;

            try
            {
                Connection c = new Connection();
                id = textBox1.Text; pw = textBox2.Text;
                c.command();
                c.cmd.CommandText = "select id,pw from usertbl where id = '" + id + "' and pw='" + pw + "'";
                c.conn.Open();
                SqlDataReader sdr = c.cmd.ExecuteReader();

                while (sdr.Read()) {
                    if (adminid == (string)sdr["id"] && adminpw == (string)sdr["pw"])
                    {
                        admin = true;
                        if (admin == true)
                        {
                            MessageBox.Show("관리자 로그인.", "로그인");
                            this.Hide();
                            adminform adminform = new adminform();
                            adminform.ShowDialog();
                            this.Close();
                            c.conn.Close();
                        }

                    }
                    else if (id == (string)sdr["id"] && pw == (string)sdr["pw"])
                    {                                          
                        login = true;
                        if (login == true)
                        {
                            string msg = string.Format("{0}님 환영합니다.]", (string)sdr["id"]);
                            MessageBox.Show(msg, "로그인");
                            this.Hide();
                            Mainform mainform = new Mainform();
                            mainform.ShowDialog();
                            this.Close();
                            c.conn.Close();
                        }                   

                    }
                }   
                if(login == false)
                    MessageBox.Show("아이디 혹은 패스워드를 확인해주세요.", "로그인");
                c.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void Loginform_Pw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

 

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup signup = new signup();
            signup.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IDserch iserch = new IDserch();
            iserch.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PWserch iserch = new PWserch();
            iserch.ShowDialog();
        }
    }
}
