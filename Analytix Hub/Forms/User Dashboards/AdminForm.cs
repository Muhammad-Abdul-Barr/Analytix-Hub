using Analytix_Hub.Forms.Panels.Admin_Panels;
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
    public partial class AdminForm : Form
    {
        private MakeAnalysis makeAnalysis = new MakeAnalysis();
        private PopulateDB populateDB = new PopulateDB();
        private ViewRequests viewRequests = new ViewRequests();
        private AboutUs aboutUs = new AboutUs();
        public AdminForm()
        {
            InitializeComponent();
            panel3.Controls.Add(aboutUs);
            panel3.Controls.Add(makeAnalysis);
            panel3.Controls.Add(populateDB);
            panel3.Controls.Add(viewRequests);
            aboutUs.Visible = true;
            makeAnalysis.Visible = false;
            populateDB.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            aboutUs.Visible = true;
            makeAnalysis.Visible = false;
            populateDB.Visible = false;
            viewRequests.Visible = false;
        }

        private void addBooks_btn_Click(object sender, EventArgs e)
        {
            aboutUs.Visible = false;
            makeAnalysis.Visible = false;
            populateDB.Visible = true;
            viewRequests.Visible = false;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            aboutUs.Visible = false;
            makeAnalysis.Visible = true;
            populateDB.Visible = false;
            viewRequests.Visible = false;
        }

        private void returnBooks_btn_Click(object sender, EventArgs e)
        {
            LocalMainForm.ActiveForm.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            aboutUs.Visible = false;
            makeAnalysis.Visible = false;
            populateDB.Visible = false;
            viewRequests.Visible = true;
        }
    }
}
