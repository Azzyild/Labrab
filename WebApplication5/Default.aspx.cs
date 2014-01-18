using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Collections;

namespace WebApplication5
{
    class OurText
    {
        public int id;
        public string ourtext;
    }

    public partial class Default : System.Web.UI.Page
    {
        ArrayList aL = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            string myConnectionString = "Server=tcp:a1eah8svsr.database.windows.net,1433;Database=DB;User ID=VOVA@a1eah8svsr;Password=1qazse432!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                string sqlQuery = "select * from IldTable";
                SqlCommand command = new SqlCommand(sqlQuery, connection, transaction);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OurText newitem = new OurText();
                    newitem.id = reader.GetInt32(0);
                    newitem.ourtext = reader.GetString(1);
                    aL.Add(newitem);
                }
                reader.Close();
                transaction.Commit();
                connection.Close();
            }

            for (int i = 0; i < aL.Count; i++)
            {
                OurText OT = (OurText)aL[aL.Count-i-1];

                Label textLabel = new Label();
                textLabel.Text = (aL.Count - i) + ". " + OT.ourtext;
                textLabel.CssClass = "blogCssClass";

                Label stringLabel = new Label();
                stringLabel.CssClass = "blogCssClass1";
                stringLabel.Text = "****************************************************************************************************";
                ContentPlaceHolder.Controls.Add(stringLabel);

                ContentPlaceHolder.Controls.Add(textLabel);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id;
            string myConnectionString = "Server=tcp:a1eah8svsr.database.windows.net,1433;Database=DB;User ID=VOVA@a1eah8svsr;Password=1qazse432!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                string sqlQuery = "select Id from IldTable";
                SqlCommand command = new SqlCommand(sqlQuery, connection, transaction);
                var reader = command.ExecuteReader();
                id = 1;
                while (reader.Read())
                {
                    id = reader.GetInt32(0)+1;
                }
                reader.Close();
                transaction.Commit();
                connection.Close();
            }
            
            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();

                string sqlQuery = "insert into IldTable (Id, ourtext) values ("+id+","+"'"+TextBox1.Text+"');";
                SqlCommand command = new SqlCommand(sqlQuery, connection, transaction);
                var reader = command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
            }
            Page.Response.Redirect("~/Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text != "")
            {
                try
                {
                    int number=Convert.ToInt32(TextBox2.Text);
                    if (aL.Count < number)
                    {
                        Label1.Text = "Number that you have typed is not valid.";
                    }
                    else
                    {
                        OurText OT=(OurText)aL[number-1];
                        string myConnectionString = "Server=tcp:a1eah8svsr.database.windows.net,1433;Database=DB;User ID=VOVA@a1eah8svsr;Password=1qazse432!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                        using (SqlConnection connection = new SqlConnection(myConnectionString))
                        {
                            connection.Open();
                            var transaction = connection.BeginTransaction();

                            string sqlQuery = "delete from IldTable where Id="+OT.id;
                            SqlCommand command = new SqlCommand(sqlQuery, connection, transaction);
                            var reader = command.ExecuteNonQuery();
                            transaction.Commit();
                            connection.Close();
                        }
                        Page.Response.Redirect("~/Default.aspx");
                    }
                }
                catch
                {
                    Label1.Text = "You must type the number, not letters!";
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
         {
            if (TextBox4.Text != "")
            {
                try
                {
                    int number=Convert.ToInt32(TextBox4.Text);
                    if (aL.Count < number)
                    {
                        Label2.Text = "Number that you have typed is not valid.";
                    }
                    else
                    {
                        OurText OT = (OurText)aL[number - 1];
                        string myConnectionString = "Server=tcp:a1eah8svsr.database.windows.net,1433;Database=DB;User ID=VOVA@a1eah8svsr;Password=1qazse432!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                        using (SqlConnection connection = new SqlConnection(myConnectionString))
                        {
                            connection.Open();
                            var transaction = connection.BeginTransaction();

                           string sqlQuery = "update IldTable set OurText='"+TextBox3.Text+"' Where Id=" + OT.id+';';
                            SqlCommand command = new SqlCommand(sqlQuery, connection, transaction);
                            var reader = command.ExecuteNonQuery();
                            transaction.Commit();
                            connection.Close();
                        }
                        Page.Response.Redirect("~/Default.aspx");
                    }
                }
                catch
                {
                    Label2.Text = "You must type the number, not letters!";
                }
            }
        }

        }
    }
