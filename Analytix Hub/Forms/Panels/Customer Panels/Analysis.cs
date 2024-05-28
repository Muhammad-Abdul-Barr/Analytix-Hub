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

namespace Analytix_Hub.Forms.Panels.Customer_Panels
{
    public partial class Analysis : UserControl
    {
        public Analysis()
        {
            InitializeComponent();
        }

        private void Analysis_Load(object sender, EventArgs e)
        {
            //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True");
            //    sqlConnection.Open();
            //    string query = "SELECT H.HashtagCount,  COUNT(I.InteractionID) AS TotalInteractions FROM (   SELECT DISTINCT PostID   FROM HashtagPost) AS idpost JOIN HashtagPost H ON idpost.PostID = H.PostID JOIN FB_Interaction I ON H.PostID = I.PostID GROUP BY H.HashtagCount";
            //    SqlCommand cmd = new SqlCommand(query, sqlConnection);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    chart1.DataSource = dt;
            //    chart1.Series["Series1"].XValueMember = "HashtagCount";
            //    chart1.Series["Series1"].YValueMembers = "TotalInteractions";
            //    chart1.DataBind();
            //    sqlConnection.Close();

            //    SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True");
            //    sqlConnection.Open();
            //    string query1 = "SELECT fu.Country, COUNT(fi.InteractionID) AS TotalInteractions FROM FB_User fu JOIN FB_Interaction fi ON fu.UserID = fi.UserID GROUP BY fu.Country";
            //    SqlCommand cmd1 = new SqlCommand(query1, sqlConnection);
            //    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            //    DataTable dt1 = new DataTable();
            //    da1.Fill(dt1);
            //    chart2.DataSource = dt1;
            //    chart2.Series["Series1"].XValueMember = "Country";
            //    chart2.Series["Series1"].YValueMembers = "TotalInteractions";
            //    chart2.DataBind();
            //    sqlConnection.Close();

            //    SqlConnection sqlConnection3 = new SqlConnection(@"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True");
            //    sqlConnection.Open();
            //    string query3 = "SELECT u.Country, SUM(fia.LikeReactionCount + fia.LoveReactionCount + fia.LaughReactionCount + fia.WowReactionCount) AS TotalPositiveSentiments FROM FB_User u JOIN FB_InteractionAnalysis fia ON u.UserID = fia.PostID GROUP BY u.Country ORDER BY COUNTRY DESC, TotalPositiveSentiments DESC\r\n";
            //    SqlCommand cmd3 = new SqlCommand(query3, sqlConnection);
            //    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            //    DataTable dt3 = new DataTable();
            //    da3.Fill(dt3);
            //    chart3.DataSource = dt3;
            //    chart3.Series["Series1"].XValueMember = "Country";
            //    chart3.Series["Series1"].YValueMembers = "TotalPositiveSentiments";
            //    chart3.DataBind();
            //    sqlConnection.Close();

            //    SqlConnection sqlConnection4 = new SqlConnection(@"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True");
            //    sqlConnection.Open();
            //    string query4 = "SELECT lu.Data AS UserGender, COUNT(fi.InteractionID) AS TotalInteractions FROM FB_Interaction fi JOIN FB_User fu ON fi.UserID = fu.UserID JOIN Lookup lu ON fu.UserGender = lu.ID GROUP BY lu.Data;\r\n";
            //    SqlCommand cmd4 = new SqlCommand(query4, sqlConnection);
            //    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            //    DataTable dt4 = new DataTable();
            //    da4.Fill(dt4);
            //    chart4.DataSource = dt4;
            //    chart4.Series["Series1"].XValueMember = "UserGender";
            //    chart4.Series["Series1"].YValueMembers = "TotalInteractions";
            //    chart4.DataBind();
            //    sqlConnection.Close();
            //}
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
