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

namespace WindowsFormsApp1
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string sex = Sex(radioButton1.Checked);
            string nationality = Nationality(radioButton3.Checked);

           
            
            if (textBox5.Text == "")
            {
                MessageBox.Show("이름를 입력해주세요","이름");               
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("아이디를 입력해주세요","아이디");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("비밀번호를 입력해주세요","비밀번호");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("휴대폰번호를 입력해주세요","휴대폰번호");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("주소를 입력해주세요","주소");
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                
                MessageBox.Show("성별을 선택해주세요", "성별");
            }
            else if (radioButton3.Checked == false && radioButton4.Checked == false)
            {
                MessageBox.Show("국적을 선택해주세요", "국적");
            }
            else
            {
                string msg = string.Format("입력하신 정보를 확인해주세요.\r{0}\r{1}\r{2}\r{3}\r{4}\r{5}\r{6}",
               textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, sex, nationality);

                DialogResult dr1 = MessageBox.Show(msg,"회원가입", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr1 == DialogResult.OK)
                {
                    
                    
                    try
                    {
                        Connection c = new Connection();
                        c.conn.Open();
                        c.cmd = new SqlCommand();
                        c.command();
                        c.cmd.CommandText = "insert into usertbl(name ,id,pw,phone,address1,sex,nationality) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"
                            + textBox5.Text + "','" + sex + "','" + nationality + "')";                                               
                        c.cmd.ExecuteNonQuery();
                        MessageBox.Show("회원가입 완료", "회원가입");
                        c.conn.Close();                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("취소되었습니다.","취소");
                }                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("회원가입을 취소하시겠습니까?.", "취소", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

            if (dr == DialogResult.OK)
            {
                MessageBox.Show("회원가입이 취소됩니다","취소");
                Close();
            }
            if (dr == DialogResult.Cancel)
            {
                MessageBox.Show("취소되었습니다.","취소");
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox5.Checked == true)
                textBox3.PasswordChar = '*';
            else
                textBox3.PasswordChar = default(char);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr3 = MessageBox.Show("초기화 하시겠습니까?", "초기화",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (dr3 == DialogResult.OK)
            {
                MessageBox.Show("초기화 되었습니다.", "초기화");
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                checkBox5.Checked = false;
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id;
            bool idcheck = false;

            try
            {
               
                id = textBox2.Text;
                Connection c = new Connection();
                c.cmd = new SqlCommand();
                c.command();
                c.cmd.CommandText = "select id from usertbl where id = '" + id + "'";
                
                SqlDataReader sdr = c.cmd.ExecuteReader();
                
                while (sdr.Read())
                {
                    if (id == (string)sdr["id"])
                    {
                        idcheck = true;

                    }

                }
                if (idcheck == true)
                {
                    MessageBox.Show("이미 사용중인 ID입니다.", "회원가입");

                }
                else
                    MessageBox.Show("사용 가능한 ID입니다.", "회원가입");

                c.conn.Close();
            }
            catch (Exception ex)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("아이디를 입력해주세요", "아이디");
                }
                //MessageBox.Show(ex.ToString());

            }
        }
    }
}
