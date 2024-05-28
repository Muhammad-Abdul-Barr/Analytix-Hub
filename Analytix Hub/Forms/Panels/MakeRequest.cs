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

namespace Analytix_Hub
{
    public partial class MakeRequest : UserControl
    {
        public MakeRequest()
        {
            InitializeComponent();
            emailbox.Font = new Font(emailbox.Font, FontStyle.Bold);
            organizbox.Font = new Font(organizbox.Font, FontStyle.Bold);
            usernamebox.Font = new Font(usernamebox.Font, FontStyle.Bold);
            Namebox.Font = new Font(Namebox.Font, FontStyle.Bold);
            guna2TextBox1.Font = new Font(guna2TextBox1.Font, FontStyle.Bold);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(local);Initial Catalog=SentimentApplication;Integrated Security=True");
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    String insertData = "INSERT INTO AnalysisRequests values (@time, @platform, @name, @email, @number, @org, @status, @username)";
                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@time", DateTime.Now);
                        int plat = DatabaseValues.FetchLookUpID(guna2ComboBox1.SelectedItem.ToString());
                        if (plat != -1)
                        {
                            cmd.Parameters.AddWithValue("@platform", plat);
                            cmd.Parameters.AddWithValue("@name", Namebox.Text);
                            cmd.Parameters.AddWithValue("@email", emailbox.Text);
                            cmd.Parameters.AddWithValue("@number", guna2TextBox1.Text);
                            cmd.Parameters.AddWithValue("@org", organizbox.Text);
                            cmd.Parameters.AddWithValue("@status", 6);
                            cmd.Parameters.AddWithValue("@username", usernamebox.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Request Genrated Successfully. We will contact you on mail Shortly.", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Platform", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        guna2ComboBox1.SelectedItem = 0;
                        usernamebox.Text = "";
                        emailbox.Text = "";
                        guna2TextBox1.Text = "";
                        organizbox.Text = "";
                        Namebox.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void usernamebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void organizbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void contactbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MakeRequest_Load(object sender, EventArgs e)
        {


        }

        private void emailbox_TextChanged_1(object sender, EventArgs e)
        {
            if (emailbox.Text == "")
            {
                emailbox.Font = new Font(emailbox.Font, FontStyle.Bold);
            }
            else
            {
                emailbox.Font = new Font(emailbox.Font, FontStyle.Regular);
            }
        }

        private void organizbox_TextChanged_1(object sender, EventArgs e)
        {
            if (organizbox.Text == "")
            {
                organizbox.Font = new Font(organizbox.Font, FontStyle.Bold);
            }
            else
            {
                organizbox.Font = new Font(organizbox.Font, FontStyle.Regular);
            }
        }

        private void usernamebox_TextChanged_1(object sender, EventArgs e)
        {
            if (usernamebox.Text == "")
            {
                usernamebox.Font = new Font(usernamebox.Font, FontStyle.Bold);
            }
            else
            {
                usernamebox.Font = new Font(usernamebox.Font, FontStyle.Regular);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                guna2TextBox1.Font = new Font(guna2TextBox1.Font, FontStyle.Bold);
            }
            else
            {
                guna2TextBox1.Font = new Font(guna2TextBox1.Font, FontStyle.Regular);
            }
        }

        private void Namebox_TextChanged(object sender, EventArgs e)
        {
            if (Namebox.Text == "")
            {
                Namebox.Font = new Font(Namebox.Font, FontStyle.Bold);
            }
            else
            {
                Namebox.Font = new Font(Namebox.Font, FontStyle.Regular);
            }

        }
    }
}
