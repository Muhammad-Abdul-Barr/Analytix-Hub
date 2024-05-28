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
    public partial class OwnerForm : Form
    {
        private AboutUs aboutUs = new AboutUs();
        private MakeUser makeUser = new MakeUser();
        private ViewRequests viewRequests = new ViewRequests();
        public OwnerForm()
        {
            InitializeComponent();
            panel3.Controls.Add(aboutUs);
            panel3.Controls.Add(makeUser);
            panel3.Controls.Add(viewRequests);
            aboutUs.Visible = true;
            makeUser.Visible = false;

        }

        private void addBooks_btn_Click(object sender, EventArgs e)
        {
            aboutUs.Visible = false;
            makeUser.Visible = true;
            viewRequests.Visible = false;
        }

        private void returnBooks_btn_Click(object sender, EventArgs e)
        {
            LocalMainForm.ActiveForm.Show();
            this.Hide();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            aboutUs.Visible = true;
            viewRequests.Visible = false;
            makeUser.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            viewRequests.Visible = true;
            aboutUs.Visible = false;
            makeUser.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
