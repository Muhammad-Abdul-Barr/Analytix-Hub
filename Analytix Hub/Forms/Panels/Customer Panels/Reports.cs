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

namespace Analytix_Hub.Forms.Panels.Customer_Panels
{
    public partial class Reports : UserControl
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(guna2ComboBox1.SelectedItem.ToString() == "PostHashtagCaptionLength")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT DISTINCT Country, SUM(MaxLikeReactionCount) AS TotalLikes, SUM(MaxLoveReactionCount) AS TotalLoves, SUM(MaxLaughReactionCount) AS TotalLaughs, SUM(MaxWowReactionCount) AS TotalWows, SUM(MaxSadReactionCount) AS TotalSads, SUM(MaxAngryReactionCount) AS TotalAngrys, SUM(MaxNegativeCommentCount) AS TotalNegativeComments, SUM(MaxNeutralCommentCount) AS TotalNeutralComments FROM (SELECT fu.Country, fia.PostID, MAX(fia.LikeReactionCount) AS MaxLikeReactionCount, MAX(fia.LoveReactionCount) AS MaxLoveReactionCount, MAX(fia.LaughReactionCount) AS MaxLaughReactionCount, MAX(fia.WowReactionCount) AS MaxWowReactionCount, MAX(fia.SadReactionCount) AS MaxSadReactionCount, MAX(fia.AngryReactionCount) AS MaxAngryReactionCount, MAX(fia.NegativeCommentCount) AS MaxNegativeCommentCount, MAX(fia.NeutralCommentCount) AS MaxNeutralCommentCount FROM FB_User fu JOIN FB_Post fp ON fu.UserID = fp.UserID JOIN FB_InteractionAnalysis fia ON fp.PostID = fia.PostID GROUP BY fu.Country, fia.PostID) AS PostInteractions WHERE MaxLikeReactionCount IS NOT NULL AND MaxLoveReactionCount IS NOT NULL AND MaxLaughReactionCount IS NOT NULL AND MaxWowReactionCount IS NOT NULL AND MaxSadReactionCount IS NOT NULL AND MaxAngryReactionCount IS NOT NULL AND MaxNegativeCommentCount IS NOT NULL AND MaxNeutralCommentCount IS NOT NULL GROUP BY Country ORDER BY Country", connection))
                        {
                           // command.Parameters.AddWithValue("@value", 1004);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:\Users\AL-FATAH LAPTOP\OneDrive\Desktop\4th Semester\dbfinalpid-3\Analytix Hub\Reporting\PostHashtagCaptionLength.rpt";
                                string fpath = Path.Combine(path, reportpath);

                                reportDocument.Load(fpath);
                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            else if(guna2ComboBox1.SelectedItem.ToString() == "HashtagCount")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT P.PageID, HP.HashtagCount, AVG(IA.PositiveCommentCount) AS AvgPositiveComments, AVG(IA.NegativeCommentCount) AS AvgNegativeComments, AVG(IA.NeutralCommentCount) AS AvgNeutralComments FROM Page P INNER JOIN FB_Post FP ON P.PageID = FP.PageID INNER JOIN HashtagPost HP ON FP.PostID = HP.PostID INNER JOIN FB_InteractionAnalysis IA ON FP.PostID = IA.PostID WHERE P.PageID = @value GROUP BY P.PageID, HP.HashtagCount order by hp.hashtagCount", connection))
                        {
                             command.Parameters.AddWithValue("@value", 1);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:/Users/AL-FATAH LAPTOP/OneDrive/Desktop/4th Semester/dbfinalpid-3/Analytix Hub/Reporting/HashtagCount.rpt";
                                string fpath = Path.Combine(path, reportpath);

                                reportDocument.Load(fpath);

                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            else if(guna2ComboBox1.SelectedItem.ToString() == "PageCategoryOnAverageUserSentiment")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();


                        using (SqlCommand command = new SqlCommand("SELECT P.PageCategory, AVG(IA.PositiveCommentCount) AS AvgPositiveComments, AVG(IA.NegativeCommentCount) AS AvgNegativeComments, AVG(IA.NeutralCommentCount) AS AvgNeutralComments FROM SentimentAnalysis.dbo.Page P INNER JOIN Fb_Post FP ON P.PageID = FP.PageID INNER JOIN FB_InteractionAnalysis IA ON FP.PostID = IA.PostID GROUP BY P.PageCategory", connection))
                        {
                            // Add parameters if needed
                            //command.Parameters.AddWithValue("@value", 1);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:\Users\AL-FATAH LAPTOP\OneDrive\Desktop\4th Semester\dbfinalpid-3\Analytix Hub\Reporting\PageCategoryOnAverageUserSentiment.rpt";
                                string fpath = Path.Combine(path, reportpath);

                                reportDocument.Load(fpath);

                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            else if (guna2ComboBox1.SelectedItem.ToString() == "PostFormatEffectOnAveragePostSentiment")
            {
                try
                {
                    // Define your connection string
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    // Create a SqlConnection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT P.PageID, FP.Format, AVG(IA.PositiveCommentCount) AS AvgPositiveComments, AVG(IA.NegativeCommentCount) AS AvgNegativeComments, AVG(IA.NeutralCommentCount) AS AvgNeutralComments FROM SentimentAnalysis.dbo.Page P INNER JOIN SentimentAnalysis.dbo.FB_Post FP ON P.PageID = FP.PageID INNER JOIN SentimentAnalysis.dbo.FB_InteractionAnalysis IA ON FP.PostID = IA.PostID GROUP BY P.PageID, FP.Format", connection))
                        {
                            command.Parameters.AddWithValue("@value", 1);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:/Users/AL-FATAH LAPTOP/OneDrive/Desktop/4th Semester/dbfinalpid-3/Analytix Hub/Reporting/PostFormatEffectOnAveragePostSentiment.rpt";
                                string fpath = Path.Combine(path, reportpath);

                                reportDocument.Load(fpath);
                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            else if(guna2ComboBox1.SelectedItem.ToString() == "UserSentimentTrendonPostsbyTimeofDay")
            {
                try
                {
                    // Define your connection string
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    // Create a SqlConnection
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT P.PageID, DATEPART(HOUR, FP.TimePosted) AS HourPosted, AVG(IA.PositiveCommentCount) AS AvgPositiveComments, AVG(IA.NegativeCommentCount) AS AvgNegativeComments, AVG(IA.NeutralCommentCount) AS AvgNeutralComments FROM SentimentAnalysis.dbo.Page P INNER JOIN SentimentAnalysis.dbo.FB_Post FP ON P.PageID = FP.PageID INNER JOIN SentimentAnalysis.dbo.FB_InteractionAnalysis IA ON FP.PostID = IA.PostID GROUP BY P.PageID, DATEPART(HOUR, FP.TimePosted)", connection))
                        {
                            //command.Parameters.AddWithValue("@value", 1);

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:/Users/AL-FATAH LAPTOP/OneDrive/Desktop/4th Semester/dbfinalpid-3/Analytix Hub/Reporting/UserSentimentTrendonPostsbyTimeofDay.rpt";
                                string fpath = Path.Combine(path, reportpath);

                                reportDocument.Load(fpath);
                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            else if(guna2ComboBox1.SelectedItem.ToString() == "FollowersGenderAnalysis")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT U.UserGender, COUNT(I.ReactionType) AS PositiveInteractions FROM SentimentAnalysis.dbo.Page P INNER JOIN SentimentAnalysis.dbo.FB_Post FP ON P.PageID = FP.PageID INNER JOIN SentimentAnalysis.dbo.FB_Interaction I ON FP.PostID = I.PostID INNER JOIN SentimentAnalysis.dbo.Fb_User U ON I.UserID = U.UserID WHERE I.ReactionType = 11 OR I.ReactionType = 12 OR I.ReactionType = 13 OR I.ReactionType = '14' OR I.ReactionType = '15' GROUP BY U.UserGender ORDER BY PositiveInteractions DESC", connection))
                        {
                            command.Parameters.AddWithValue("@value", 1);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:/Users/AL-FATAH LAPTOP/OneDrive/Desktop/4th Semester/dbfinalpid-3/Analytix Hub/Reporting/FollowersGenderAnalysis.rpt";
                                string fpath = Path.Combine(path, reportpath);
                                reportDocument.Load(fpath);

                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            else if (guna2ComboBox1.SelectedItem.ToString() == "ImpactofCurrentSeasononPostSentiment")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT P.PageID, CASE WHEN MONTH(FP.TimePosted) IN (12, 1, 2) THEN 'Winter' WHEN MONTH(FP.TimePosted) IN (3, 4, 5) THEN 'Spring' WHEN MONTH(FP.TimePosted) IN (6, 7, 8) THEN 'Summer' WHEN MONTH(FP.TimePosted) IN (9, 10, 11) THEN 'Autumn' END AS Season, AVG(IA.PositiveCommentCount) AS AvgPositiveComments, AVG(IA.NegativeCommentCount) AS AvgNegativeComments, AVG(IA.NeutralCommentCount) AS AvgNeutralComments FROM SentimentAnalysis.dbo.Page P INNER JOIN SentimentAnalysis.dbo.FB_Post FP ON P.PageID = FP.PageID INNER JOIN SentimentAnalysis.dbo.FB_InteractionAnalysis IA ON FP.PostID = IA.PostID GROUP BY P.PageID, CASE WHEN MONTH(FP.TimePosted) IN (12, 1, 2) THEN 'Winter' WHEN MONTH(FP.TimePosted) IN (3, 4, 5) THEN 'Spring' WHEN MONTH(FP.TimePosted) IN (6, 7, 8) THEN 'Summer' WHEN MONTH(FP.TimePosted) IN (9, 10, 11) THEN 'Autumn' END Order By PageID ASC", connection))
                        {
                            command.Parameters.AddWithValue("@value", 1);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:\Users\AL-FATAH LAPTOP\OneDrive\Desktop\dbfinalpid-3\Analytix Hub\Reporting\ImpactofCurrentSeasononPostSentiment.rpt";
                                string fpath = Path.Combine(path, reportpath);
                                reportDocument.Load(fpath);

                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }


            else if (guna2ComboBox1.SelectedItem.ToString() == "UserAgeImpactOnPostSentiment")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT DISTINCT  P.PageID, CASE WHEN DATEDIFF(YEAR, U.DoB, GETDATE()) BETWEEN 18 AND 24 THEN '18-24' WHEN DATEDIFF(YEAR, U.DoB, GETDATE()) BETWEEN 25 AND 34 THEN '25-34' WHEN DATEDIFF(YEAR, U.DoB, GETDATE()) BETWEEN 35 AND 44 THEN '35-44' WHEN DATEDIFF(YEAR, U.DoB, GETDATE()) BETWEEN 45 AND 54 THEN '45-54' ELSE '55+' END AS AgeRange, COUNT(CASE WHEN (I.ReactionType = 11 OR I.ReactionType = 12 OR I.ReactionType = 13 OR I.ReactionType = 14 OR I.ReactionType = 15) THEN 1 ELSE NULL END) AS PositiveInteractions FROM SentimentAnalysis.dbo.Page P INNER JOIN SentimentAnalysis.dbo.FB_Post FP ON P.PageID = FP.PageID INNER JOIN SentimentAnalysis.dbo.FB_Interaction I ON FP.PostID = I.PostID INNER JOIN SentimentAnalysis.dbo.Fb_User U ON I.UserID = U.UserID GROUP BY P.PageID, CASE WHEN DATEDIFF(YEAR, U.DoB, GETDATE()) BETWEEN 18 AND 24 THEN '18-24' WHEN DATEDIFF(YEAR, U.DoB, GETDATE()) BETWEEN 25 AND 34 THEN '25-34' WHEN DATEDIFF(YEAR, U.DoB, GETDATE()) BETWEEN 35 AND 44 THEN '35-44' WHEN DATEDIFF(YEAR, U.DoB, GETDATE()) BETWEEN 45 AND 54 THEN '45-54' ELSE '55+' END ORDER BY P.PageID, AgeRange", connection))
                        {
                            command.Parameters.AddWithValue("@value", 1);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:\Users\AL-FATAH LAPTOP\OneDrive\Desktop\dbfinalpid-3\Analytix Hub\Reporting\UserAgeImpactOnPostSentiment.rpt";
                                string fpath = Path.Combine(path, reportpath);
                                reportDocument.Load(fpath);

                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }


            else if (guna2ComboBox1.SelectedItem.ToString() == "TrendOfInteractionOnPageOverTime")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT P.PageID, FP.TimePosted AS Time, SUM(IA.LikeReactionCount + IA.LoveReactionCount + IA.LaughReactionCount + IA.WowReactionCount + IA.SadReactionCount + IA.AngryReactionCount) AS TotalReactions, SUM(IA.PositiveCommentCount + IA.NegativeCommentCount + IA.NeutralCommentCount) AS TotalComments FROM SentimentAnalysis.dbo.Page P INNER JOIN SentimentAnalysis.dbo.FB_Post FP ON P.PageID = FP.PageID INNER JOIN SentimentAnalysis.dbo.FB_InteractionAnalysis IA ON FP.PostID = IA.PostID GROUP BY P.PageID, FP.TimePosted ORDER BY P.PageID, Time", connection))
                        {
                            command.Parameters.AddWithValue("@value", 1);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:\Users\AL-FATAH LAPTOP\OneDrive\Desktop\dbfinalpid-3\Analytix Hub\Reporting\TrendOfInteractionOnPageOverTime.rpt";
                                string fpath = Path.Combine(path, reportpath);
                                reportDocument.Load(fpath);

                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else if(guna2ComboBox1.SelectedItem.ToString() == "UserSentimentTrendOnSubredditOvertime")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT SR.SubredditID, RIA.TimeStamp AS Time, SUM(RIA.UpVoteCount + RIA.DownVoteCount) AS TotalVotes, SUM(RIA.PositiveCommentCount + RIA.NegativeCommentCount + RIA.NeutralCommentCount) AS TotalComments FROM Subreddit SR INNER JOIN Reddit_Post RP ON SR.SubredditID = RP.SubredditID INNER JOIN Reddit_InteractionAnalysis RIA ON RP.PostID = RIA.PostID GROUP BY SR.SubredditID, RIA.TimeStamp ORDER BY SR.SubredditID, RIA.TimeStamp", connection))
                        {
                            command.Parameters.AddWithValue("@value", 1);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:\Users\AL-FATAH LAPTOP\OneDrive\Desktop\dbfinalpid-3\Analytix Hub\Reporting\UserSentimentTrendOnSubredditOvertime.rpt";
                                string fpath = Path.Combine(path, reportpath);
                                reportDocument.Load(fpath);

                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }


            else if (guna2ComboBox1.SelectedItem.ToString() == "RedditUserSentimentTrendOnPostsByTimeOfDay")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT RP.SubredditID, RP.TimePosted AS TimeOfDay, SUM(RIA.UpVoteCount + RIA.DownVoteCount) AS TotalVotes, SUM(RIA.PositiveCommentCount + RIA.NegativeCommentCount + RIA.NeutralCommentCount) AS TotalComments FROM Reddit_Post RP INNER JOIN Reddit_InteractionAnalysis RIA ON RP.PostID = RIA.PostID GROUP BY RP.SubredditID, RP.TimePosted ORDER BY RP.SubredditID, RP.TimePosted", connection))
                        {
                            command.Parameters.AddWithValue("@value", 1);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:\Users\AL-FATAH LAPTOP\OneDrive\Desktop\dbfinalpid-3\Analytix Hub\Reporting\RedditUserSentimentTrendOnPostsByTimeOfDay.rpt";
                                string fpath = Path.Combine(path, reportpath);
                                reportDocument.Load(fpath);

                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            
            else if (guna2ComboBox1.SelectedItem.ToString() == "RedditPostEditImpactOnUserSentiment")
            {
                try
                {
                    string connectionString = @"Data Source=(local);Initial Catalog=SentimentAnalysis;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT RP.SubredditID, CASE WHEN RP.TimeEdited IS NOT NULL THEN 'Edited' ELSE 'Not Edited' END AS PostEditStatus, AVG(RIA.UpVoteCount + RIA.DownVoteCount) AS AvgTotalVotes, AVG(RIA.PositiveCommentCount + RIA.NegativeCommentCount + RIA.NeutralCommentCount) AS AvgTotalComments FROM Subreddit SR INNER JOIN Reddit_Post RP ON SR.SubredditID = RP.SubredditID INNER JOIN Reddit_InteractionAnalysis RIA ON RP.PostID = RIA.PostID GROUP BY RP.SubredditID, CASE WHEN RP.TimeEdited IS NOT NULL THEN 'Edited' ELSE 'Not Edited' END ORDER BY RP.SubredditID, PostEditStatus", connection))
                        {
                            command.Parameters.AddWithValue("@value", 1);
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                ReportDocument reportDocument = new ReportDocument();
                                string path = Application.StartupPath;
                                string reportpath = @"C:\Users\AL-FATAH LAPTOP\OneDrive\Desktop\dbfinalpid-3\Analytix Hub\Reporting\RedditPostEditImpactOnUserSentiment.rpt";
                                string fpath = Path.Combine(path, reportpath);
                                reportDocument.Load(fpath);

                                reportDocument.SetDataSource(dataTable);

                                crystalReportViewer1.ReportSource = reportDocument;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            PopulateComboBox(guna2ComboBox1, new string[] { "PostHashtagCaptionLength", "HashtagCount", "PageCategoryOnAverageUserSentiment", "PostFormatEffectOnAveragePostSentiment", "UserSentimentTrendonPostsbyTimeofDay", "FollowersGenderAnalysis", "ImpactofCurrentSeasononPostSentiment" , "UserAgeImpactOnPostSentiment", "TrendOfInteractionOnPageOverTime", "UserSentimentTrendOnSubredditOvertime", "RedditUserSentimentTrendOnPostsByTimeOfDay","RedditImpactOfCurrentSeasonOnPostSentiment", "RedditPostEditImpactOnUserSentiment" });
        }
        private void PopulateComboBox(System.Windows.Forms.ComboBox cb, string[] items)
        {
            cb.Items.Clear();
            foreach (string item in items)
            {
                cb.Items.Add(item);
            }
        }
    }
}
