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
    public partial class RegisterForm : Form
    {
        static SqlConnection con = new SqlConnection("Data Source=DESKTOP-U0MK4ON;Initial Catalog=register;Integrated Security=True");
        static SqlCommand scmd;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(UserTbox.Text) ||
              string.IsNullOrWhiteSpace(PassTbox.Text) ||
              string.IsNullOrWhiteSpace(NameTbox.Text)
              )
            return false;
            else return true;


        }

        private void RegBtn_Click(object sender, EventArgs e)
        {
           if (!Authenticate())
                {
                MessageBox.Show("Do Not Keep Any Textbox Blank");
            }
            string query = "INSERT INTO Yusers Values(@USER,@PASS,@NAME,@GENDER,@DOB)";
            con.Open();
            scmd = new SqlCommand(query, con);

            //adding parameters

            scmd.Parameters.Add("@USER", SqlDbType.VarChar);
            scmd.Parameters["@USER"].Value=UserTbox.Text;

            scmd.Parameters.Add("@PASS", SqlDbType.VarChar);
            scmd.Parameters["@PASS"].Value = PassTbox.Text;

            scmd.Parameters.Add("@NAME", SqlDbType.VarChar);
            scmd.Parameters["@NAME"].Value = NameTbox.Text;

            scmd.Parameters.Add("@GENDER", SqlDbType.VarChar);
            scmd.Parameters["@GENDER"].Value = GenderCbox.Text;

            scmd.Parameters.Add("@DOB", SqlDbType.VarChar);
            scmd.Parameters["@DOB"].Value = dateTimePicker1.Text;

            scmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
