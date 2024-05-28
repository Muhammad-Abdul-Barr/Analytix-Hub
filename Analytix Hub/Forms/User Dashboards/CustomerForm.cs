using Analytix_Hub.Forms.Panels.Customer_Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analytix_Hub
{
    public partial class CustomerForm : Form
    {
        private AboutUs aboutUs = new AboutUs();
        private Reports reports = new Reports();
        private Analysis analysis = new Analysis();


        public CustomerForm()
        {
            InitializeComponent();
            panel3.Controls.Add(aboutUs);
            panel3.Controls.Add(reports);
            panel3.Controls.Add(analysis);
            aboutUs.Visible = true;
            reports.Visible = false;
            analysis.Visible = false;
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            aboutUs.Visible = true;
            reports.Visible = false;
            analysis.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            analysis.Visible = true;
            aboutUs.Visible = false;
            reports.Visible = false;
        }

        private void returnBooks_btn_Click(object sender, EventArgs e)
        {
            LocalMainForm.ActiveForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reports.Visible = true;
            aboutUs.Visible = false;
            analysis.Visible = false;

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
