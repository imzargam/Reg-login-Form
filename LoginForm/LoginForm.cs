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

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        static SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0MK4ON;Initial Catalog=register;Integrated Security=True");
        static SqlCommand scmd;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegBtn_Click(object sender, EventArgs e)
        {
            RegisterForm Reg = new RegisterForm();
            Reg.ShowDialog();
        }
        bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(UserTbox.Text) ||
              string.IsNullOrWhiteSpace(PassTbox.Text)
              )
                return false;
            else return true;
         }

        private void LogBtn_Click(object sender, EventArgs e)
        {
            bool isuserok = false, ispassok = false;
            if (!Authenticate())
            {
                MessageBox.Show("Do Not Keep Any Textbox Blank");
                return;
            }

            string query = "SELECT * FROM YUSERS WHERE username=@USER";
            con.Open();
            scmd = new SqlCommand(query, con);

            //adding parameters
            scmd.Parameters.Add("@USER", SqlDbType.VarChar);
            scmd.Parameters["@USER"].Value = UserTbox.Text;

            SqlDataReader sda = scmd.ExecuteReader();
            if(sda.HasRows)
            {
                isuserok = true;
            }
            con.Close();

            con.Open();
            query = "SELECT * FROM YUSERS WHERE username=@USER AND passcode=@PASS";
            scmd = new SqlCommand(query, con);
            //adding parameters
            scmd.Parameters.Add("@USER", SqlDbType.VarChar);
            scmd.Parameters["@USER"].Value = UserTbox.Text;

            scmd.Parameters.Add("@PASS", SqlDbType.VarChar);
            scmd.Parameters["@PASS"].Value = PassTbox.Text;

            sda = scmd.ExecuteReader();
            if (sda.HasRows)
            {
                ispassok = true;
            }
            if (isuserok == false)
            {
                MessageBox.Show("Username Does Not Exist!");
            }
            else if (isuserok == true && ispassok == false)
            {
                MessageBox.Show("Worng Password!");
            }
            else
            {
                appform app = new appform();
                app.ShowDialog();

            }
            con.Close();
        }
    }
}
