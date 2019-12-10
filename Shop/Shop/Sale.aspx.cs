using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class Sale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String value1;
            if (Session["username"] != null)
            {
                value1 = Session["username"].ToString();
            }
            else
            {
                value1 = "User";
            }
            if (value1 != "" && value1 != null && value1 != "User")
            {
                btLogOut.Visible = true;
                btSignin.Visible = false;
                btKoszyk.Visible = true;
                lUserName.Text = value1;
                this.UserName = value1;
                if (value1 == "admin")
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
            commandIle.CommandText = "SELECT COUNT(*) FROM sale";
            int count = Convert.ToInt32(commandIle.ExecuteScalar());
            connIle.Close();
            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT produkty.*,sale.* FROM `produkty`,`sale` WHERE produkty.id=sale.idProdukt ";
            MySqlDataReader reader = command.ExecuteReader();
            Table table = new Table();
            TableRow row = new TableRow();
            int ile = 1;
            while (reader.Read())
            {
                if (reader.GetFloat("obnizka") != 0)
                {


                    float cenaP = reader.GetFloat("Cena");
                    float obnizka = reader.GetFloat("obnizka");

                    float sale = cenaP - obnizka;

                    TableCell cell = new TableCell();
                    cell.Style.Add("padding", "20px 50px");
                    Label tyt = new Label();
                    tyt.Text = reader.GetString("Tytul");
                    Image img = new Image();
                    if (File.Exists(Server.MapPath("/img/" + reader.GetString("Tytul").Replace(' ', '_') + ".jpg")))
                    {
                        img.ImageUrl = "~/img/" + reader.GetString("Tytul").Replace(' ', '_') + ".jpg";
                    }
                    else
                    {
                        img.ImageUrl = "~/img/noimg.png";
                    }
                    img.Width = 150;
                    img.Height = 150;
                    Label wykon = new Label();
                    wykon.Text = reader.GetString("Wykonawca");
                    Label cena1 = new Label();
                    cena1.Text = reader.GetString("Cena") + " zł";
                    cena1.ForeColor = System.Drawing.Color.Red;
                    cena1.Font.Strikeout = true;
                    Label cena = new Label();
                    cena.Text = sale.ToString("0.00") + " zł";
                    cena.ForeColor = System.Drawing.Color.Green;



                    cell.Controls.Add(tyt);
                    //new line
                    Literal lt = new Literal();
                    lt.Text = "<br />";
                    cell.Controls.Add(lt);

                    cell.Controls.Add(img);
                    Literal lt1 = new Literal();
                    lt1.Text = "<br />";
                    cell.Controls.Add(lt1);

                    cell.Controls.Add(wykon);
                    Literal lt2 = new Literal();
                    lt2.Text = "<br />";
                    cell.Controls.Add(lt2);

                    cell.Controls.Add(cena1);
                    Literal lt3 = new Literal();
                    lt3.Text = "<br />";
                    cell.Controls.Add(lt3);
                    cell.Controls.Add(cena);


                    cell.HorizontalAlign = HorizontalAlign.Center;
                    row.Cells.Add(cell);


                    if ((ile % 4 == 0 && ile != 0) || ile == count)
                    {
                        table.Rows.Add(row);
                        row = new TableRow();
                    }
                    ile++;
                }

            }
            conn.Close();
            table.Rows.Add(row);
            pItems.Controls.Add(table);
        }
        public String UserName = "User";


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

                return connection;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //lInfo.Text = "Error";
                Console.WriteLine("Error");
            }
            return null;

        }


        protected void btMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx");
        }

        protected void btAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produkty.aspx");
        }

        protected void btSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sale.aspx");
        }

        protected void btSignin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?from=sale");
        }

        protected void btLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            this.UserName = "User";
            Response.Redirect("MainForm.aspx");
        }

        protected void btKoszyk_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Koszyk.aspx");
        }

        protected void imgTools_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}