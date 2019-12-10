using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;

namespace Shop
{
    public partial class MainForm : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            Label[] tytTable = new Label[4] { lPolTyt1, lPolTyt2, lPolTyt3, lPolTyt4};
            Label[] wykTable = new Label[4] { lPolWyk1, lPolWyk2, lPolWyk3, lPolWyk4 };
            Image[] imgTable = new Image[4] { iPol1, iPol2, iPol3, iPol4 };
            String value1;
            if (Session["username"] != null)
            {
                 value1 = Session["username"].ToString();
            }
            else
            {
                value1 = "User";
            }
            if(value1 != "" && value1 != null &&value1!="User")
            {
                btLogOut.Visible = true;
                btSignin.Visible = false;
                btKoszyk.Visible = true;
                lUserName.Text = value1;
                this.UserName = value1;
                if(value1 == "admin")
                {
                    btKoszyk.Visible = false;
                    imgTools.Visible = true;
                }
            }
            MySqlConnection connect()
            {
                string myconnection =
                   "SERVER= 127.0.0.1;" +
                   "DATABASE=music;" +
                   "UID=root;" +
                   "PASSWORD=;";

                MySqlConnection connection = new MySqlConnection(myconnection);

                try
                {

                    connection.Open();
                    Console.WriteLine("Connected");
                   // lInfo.Text = "Conneted";
                    return connection;

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    //lInfo.Text = "Error";
                    Console.WriteLine("Error");
                }
                return null;
               
            }
            MySqlConnection connIle = connect();
            MySqlCommand commandIle = connIle.CreateCommand();
            commandIle.CommandText = "SELECT COUNT(*) FROM produkty";
            int count = Convert.ToInt32(commandIle.ExecuteScalar());
            connIle.Close();
            int[] dodane = new int[4] { 0, 0, 0, 0 };
            var ktory = 0;
            while (ktory < 4)
            {
                Random rnd = new Random();
                int randomId = rnd.Next(1,count+1);
                Boolean dodany = false;
                for(int i = 0; i < 4; i++)
                {
                    if (dodane[i] == randomId)
                    {
                        dodany = true;
                    }
                }
                if(dodany == false)
                {
                    MySqlConnection conn = connect();
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "SELECT * FROM produkty WHERE id=" + randomId;
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tytTable[ktory].Text = reader.GetString("Tytul");
                        wykTable[ktory].Text = reader.GetString("Wykonawca");
                      
                        if (File.Exists(Server.MapPath("/img/" + reader.GetString("Tytul").Replace(' ', '_') + ".jpg")))
                        {
                            imgTable[ktory].ImageUrl = "~/img/" + reader.GetString("Tytul").Replace(' ', '_') + ".jpg";
                        }
                        else
                        {
                            imgTable[ktory].ImageUrl = "~/img/noimg.png";
                        }
                        imgTable[ktory].Width = 150;
                        imgTable[ktory].Height = 150;

                    }
                    conn.Close();
                    dodane[ktory] = randomId;
                    ktory++;
                }
                
            }


        }
        public string UserName = "User";

        protected void btSignin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?from=home");
        }

        protected void btMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx");
        }

        protected void btLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
           
            this.UserName = "User";
            Response.Redirect("MainForm.aspx");
        }

        protected void btAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produkty.aspx");

        }

        protected void btKoszyk_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Koszyk.aspx");
        }

        protected void imgTools_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void btSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sale.aspx");
        }
    }
}