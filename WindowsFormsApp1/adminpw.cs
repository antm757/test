using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class adminpw : Form
    {
        public adminpw()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "1234")
                {
                    MessageBox.Show("확인되었습니다.", "비밀번호", MessageBoxButtons.OK);
                    this.Hide();
                    deleteuser de = new deleteuser();
                    de.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("잘못된 번호입니다.", "비밀번호", MessageBoxButtons.OK);
            }
        }
    }
}
