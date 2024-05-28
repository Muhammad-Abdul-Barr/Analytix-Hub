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
    public partial class LocalMainForm : Form
    {
        public static Form ActiveForm = null;
        private AboutUs aboutUs = new AboutUs();
        private MakeRequest makeRequest = new MakeRequest();
        public LocalMainForm()
        {
            ActiveForm = this;
            InitializeComponent();
            panel3.Controls.Add(aboutUs);
            panel3.Controls.Add(makeRequest);
            aboutUs.Visible = true;
            makeRequest.Visible = false;
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            aboutUs.Visible = true;
            makeRequest.Visible = false;
        }

        private void addBooks_btn_Click(object sender, EventArgs e)
        {
            aboutUs.Visible = false;
            makeRequest.Visible = true;
        }

        private void returnBooks_btn_Click(object sender, EventArgs e)
        { 
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
