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
    public partial class deleteuser : Form
    {
        public deleteuser()
        {
            InitializeComponent();
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
            
            string nationality = Nationality(radioButton1.Checked);
            if (textBox1.Text == "")
            {
                MessageBox.Show("이름를 입력해주세요", "이름");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("아이디를 입력해주세요", "아이디");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("휴대폰번호를 입력해주세요", "휴대폰번호");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("주소를 입력해주세요", "주소");
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("국적을 선택해주세요", "국적");
            }
            else
            {
                string msg = string.Format("삭제하는 회원 정보를 확인해주세요.\r{0}\r{1}\r{2}\r{3}\r{4}",
               textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, nationality);

                DialogResult dr1 = MessageBox.Show(msg, "회원삭제", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr1 == DialogResult.OK)
                {


                    try
                    {
                        Connection c = new Connection();
                        c.conn.Open();
                        c.command();
                        c.cmd.CommandText = "delete from usertbl where name ='" + textBox1.Text + "' and id = '" + textBox2.Text + "' and  phone = '" + textBox3.Text + "'" +
                            "and address1 = '" + textBox4.Text + "'and nationality = '" + nationality + "'";
                        c.cmd.ExecuteNonQuery();
                        MessageBox.Show("회원삭제 완료", "회원삭제");
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
                    MessageBox.Show("취소되었습니다.", "취소");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("취소하시겠습니까?.", "취소", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.OK)
            {
                MessageBox.Show("취소되었습니다다", "취소");
                Close();
            }            
        }
    }
}
