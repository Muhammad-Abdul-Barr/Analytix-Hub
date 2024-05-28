using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Data.SqlClient;

namespace Analytix_Hub
{
    public partial class PopulateDB : UserControl
    {
        private List<string> sheetNames;
        public PopulateDB()
        {
            InitializeComponent();
            Namebox.Font = new Font(Namebox.Font, FontStyle.Bold);
            sheetNames = new List<string>();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; 

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Browse Excel File";
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                Namebox.Text = selectedFilePath;
                sheetNames.Clear();

                try
                {
                    using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(selectedFilePath)))
                    {
                        foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                        {
                            sheetNames.Add(worksheet.Name);
                        }

                        guna2ComboBox2.DataSource = sheetNames;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading sheet names: " + ex.Message);
                }
            }
        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            string tableName = guna2ComboBox1.SelectedItem.ToString();
            string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";
            // Open a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Create a SQL command to disable identity insert for the selected table
                    using (SqlCommand disableIdentityCommand = new SqlCommand())
                    {
                        disableIdentityCommand.Connection = connection;
                        disableIdentityCommand.CommandText = $"SET IDENTITY_INSERT {tableName} ON";
                        disableIdentityCommand.ExecuteNonQuery();
                    }

                    // Get the column names for the selected table
                    var columnNames = new List<string>();
                    using (SqlCommand getColumnNamesCommand = new SqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'", connection))
                    {
                        using (SqlDataReader reader = getColumnNamesCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                columnNames.Add(reader.GetString(0));
                            }
                        }
                    }

                    // Double loop to iterate through rows and columns of DataGridView
                    for (int i = 1; i < guna2DataGridView1.Rows.Count; i++)
                    {
                        DataGridViewRow dgvRow = guna2DataGridView1.Rows[i];

                        // Create the SQL INSERT command with explicit column names
                        string insertCommand = $"INSERT INTO {tableName} ({string.Join(",", columnNames)}) VALUES (";

                        foreach (DataGridViewCell cell in dgvRow.Cells)
                        {
                            // Add cell value to INSERT command
                            insertCommand += $"'{cell.Value}',";
                        }

                        // Remove trailing comma and close the values list
                        insertCommand = insertCommand.TrimEnd(',') + ")";

                        // Create a SQL command to insert data into the selected table
                        using (SqlCommand command = new SqlCommand(insertCommand, connection))
                        {
                            // Execute the SQL command
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data inserted successfully!");

                    // Create a SQL command to enable identity insert for the selected table
                    using (SqlCommand enableIdentityCommand = new SqlCommand())
                    {
                        enableIdentityCommand.Connection = connection;
                        enableIdentityCommand.CommandText = $"SET IDENTITY_INSERT {tableName} OFF";
                        enableIdentityCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string filePath = Namebox.Text;
            string selectedSheet = guna2ComboBox2.SelectedItem as string;

            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(selectedSheet))
            {
                MessageBox.Show("Please select an Excel file and sheet first.");
                return;
            }

            try
            {
                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[selectedSheet];
                    DataTable dt = new DataTable();

                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        dt.Columns.Add(firstRowCell.Text);
                    }

                    for (int rowNum = 2; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                    {
                        ExcelRange wsRow = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.End.Column];
                        DataRow row = dt.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }

                    guna2DataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading sheet data: " + ex.Message);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
