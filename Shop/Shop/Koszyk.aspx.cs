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
    public partial class Koszyk : System.Web.UI.Page
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
                lUserName.Text = value1;
                this.UserName = value1;
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
            ///----------------
            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT produkty.*,"+this.UserName+".idUser FROM `"+this.UserName.ToLower()+"`,`produkty` WHERE produkty.id="+this.UserName.ToLower()+".produkt_id ";
            MySqlDataReader reader = command.ExecuteReader();


            MySqlConnection connIle = connect();
            MySqlCommand commandIle = connIle.CreateCommand();
            commandIle.CommandText = "SELECT COUNT(*) FROM `" + this.UserName.ToLower() + "`,`produkty` WHERE produkty.id=" + this.UserName.ToLower() + ".produkt_id ";
            int count = Convert.ToInt32(commandIle.ExecuteScalar());
            connIle.Close();
            Table table = new Table();
            TableRow row = new TableRow();


            int ile = 1;
            float suma = 0;
            while (reader.Read())
            {
               
              

                float cenaF = reader.GetFloat("Cena");
                suma += cenaF;

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
                Label cena = new Label();
                cena.Text = reader.GetString("Cena") + " zł";

                ImageButton kup = new ImageButton();
                kup.ImageUrl = "~/img/del.png";
                kup.Width = 40;
                kup.Height = 40;
                kup.ID = reader.GetString("idUser");
                kup.Click += new ImageClickEventHandler(this.del_click);

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

                cell.Controls.Add(cena);
                Literal lt3 = new Literal();
                lt3.Text = "<br />";
                cell.Controls.Add(lt3);

                cell.Controls.Add(kup);

                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);

                if ((ile % 4 == 0 && ile != 0) || ile == count)
                {
                    table.Rows.Add(row);
                    row = new TableRow();
                }
                ile++;
            }
            conn.Close();
            table.Rows.Add(row);
            pItems.Controls.Add(table);
            lSuma.Text = "Wartość koszyka wynosi " + suma+" zł";


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


        public string UserName = "User";

        protected void btMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx");
        }

        protected void btAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produkty.aspx");
        }

        protected void btLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            this.UserName = "User";
            Response.Redirect("MainForm.aspx");
        }
        public void del_click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            string idS = btn.ID;
            int id = Convert.ToInt32(idS);
            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM `"+this.UserName.ToLower()+ "` WHERE `" + this.UserName.ToLower() + "`.`idUser` = "+id;
            command.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Koszyk.aspx");
            //DELETE FROM `wiktor` WHERE `wiktor`.`id` = 3"
        }

        protected void btnDelAll_Click(object sender, ImageClickEventArgs e)
        {
            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM `" + this.UserName.ToLower() ;
            command.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Koszyk.aspx");
        }

        protected void btSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sale.aspx");
        }
    }
}