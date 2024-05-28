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
    public partial class MakeUser : UserControl
    {
        public MakeUser()
        {
            InitializeComponent();
            emailbox.Font = new Font(emailbox.Font, FontStyle.Bold);
            Namebox.Font = new Font(Namebox.Font, FontStyle.Bold);
        }

        private void emailbox_TextChanged(object sender, EventArgs e)
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
