using Analytix_Hub.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analytix_Hub
{
    public partial class LoginForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(local);Initial Catalog=SentimentApplication;Integrated Security=True");

        public LoginForm()
        {
            InitializeComponent();
            login_username.Font = new Font(login_username.Font, FontStyle.Bold);
            login_password.Font = new Font(login_password.Font, FontStyle.Bold);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();

                        String selectData
                            = "SELECT * FROM users WHERE username = @username AND password = @password";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", login_username.Text);
                            cmd.Parameters.AddWithValue("@password", login_password.Text);

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Login Successfully!", "Information Message"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoggedInUser.UserName = login_username.Text;
                                LoggedInUser.Password = login_password.Text;
                                LoggedInUser.UserID = Convert.ToInt32(table.Rows[0]["UserID"]);
                                int role = Convert.ToInt32(table.Rows[0]["role"]);
                                if (role == 1)
                                {
                                    LoggedInUser.Role = 1;
                                    LocalMainForm.ActiveForm.Hide();
                                    OwnerForm ownerForm = new OwnerForm();
                                    ownerForm.Show();
                                    this.Hide();
                                }
                                else if (role == 2)
                                {
                                    LoggedInUser.Role = 2;
                                    LocalMainForm.ActiveForm.Hide();
                                    AdminForm aForm = new AdminForm();
                                    aForm.Show();
                                    this.Hide();
                                }
                                else if (role == 3)
                                {
                                    LoggedInUser.Role = 3;
                                    LocalMainForm.ActiveForm.Hide();
                                    CustomerForm cForm = new CustomerForm();
                                    cForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Error In role!", "Information Message"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username/Password", "Error Message"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting Database: " + ex, "Error Message"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {
            if (login_username.Text == "")
            {
                login_username.Font = new Font(login_username.Font, FontStyle.Bold);
            }
            else
            {
                login_username.Font = new Font(login_username.Font, FontStyle.Regular);
            }
        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {
            if (login_password.Text == "")
            {
                login_password.Font = new Font(login_password.Font, FontStyle.Bold);
            }
            else
            {
                login_password.Font = new Font(login_password.Font, FontStyle.Regular);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
