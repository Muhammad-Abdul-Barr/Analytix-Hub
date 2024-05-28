using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analytix_Hub.Forms.Panels.Admin_Panels
{
    public partial class ViewRequests : UserControl
    {
        public ViewRequests()
        {
            InitializeComponent();
            Namebox.Font = new Font(Namebox.Font, FontStyle.Bold);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ViewRequests_Load(object sender, EventArgs e)
        {

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT a.RequestID, l2.Data AS 'Platform', a.Username, a.RequestCreatedOn, a.Email, a.Email, a.OrganizationName, a.PersonName, l.Data AS 'Status' FROM AnalysisRequests a JOIN Lookup l ON a.Status = l.ID JOIN Lookup l2 ON a.Platform = l2.ID;\r\n", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            guna2DataGridView1.DataSource = dataTable;
                            // Assuming you have a DataGridView named dataGridView1

                            // Calculate the width of each column
                            int numColumns = guna2DataGridView1.Columns.Count;
                            int columnWidth = guna2DataGridView1.Width / numColumns;

                            // Set the width of each column
                            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
                            {
                                column.Width = columnWidth;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
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
