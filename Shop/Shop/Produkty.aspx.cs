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
    public partial class Produkty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //powrót do miejsca kliknięcia
            //MaintainScrollPositionOnPostBack = true;
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
            commandIle.CommandText = "SELECT COUNT(*) FROM produkty";
            int count = Convert.ToInt32(commandIle.ExecuteScalar());
            connIle.Close();
            double ilosc = Convert.ToDouble(count);
            double ileStron = ilosc/12;
            double celing = Math.Ceiling(ileStron);
            Table tablePagin = new Table();
            TableRow rowPagin = new TableRow();
            for (int j = 0; j < Convert.ToInt32(celing); j++)
            {
                TableCell cell = new TableCell();
                Button btn = new Button();
                btn.Text = j.ToString();
                btn.Click += new EventHandler(this.pag_click);
                cell.Controls.Add(btn);
                rowPagin.Cells.Add(cell);
            }
            tablePagin.Rows.Add(rowPagin);
            pPaginacja.Controls.Add(tablePagin);

            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();

            string pag = Request.QueryString["pag"];
            command.CommandText = "SELECT * FROM produkty LIMIT 12 OFFSET 0";

            int count2 = 12;
            if (pag == null)
            {
                command.CommandText = "SELECT * FROM produkty LIMIT 12 OFFSET 0";
            }
            else
            {
                int licznik = Convert.ToInt32(pag);
                int offset = 12 * licznik;
                command.CommandText = "SELECT * FROM produkty LIMIT 12 OFFSET "+offset;
                
                count2 = 0;
                MySqlConnection conn3 = connect();
                MySqlCommand command3 = conn.CreateCommand();
                command3.CommandText = "SELECT * FROM produkty LIMIT 12 OFFSET " + offset;
                MySqlDataReader reader2 = command3.ExecuteReader();
                while (reader2.Read())
                {
                    count2++;
                }
                reader2.Close();
                conn3.Close();




            }
            MySqlDataReader reader = command.ExecuteReader();

            Table table = new Table();
            TableRow row = new TableRow();
            int ile = 1;
            while (reader.Read())
            {
               
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
                kup.ImageUrl = "~/img/buy.png";
                kup.Width = 40;
                kup.Height = 40;
                kup.ID = reader.GetString("id");
                kup.Click += new ImageClickEventHandler(this.kup_click);
                
                
                


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
                if(Session["username"] != null && Session["username"].ToString() != "admin")
                {
                    cell.Controls.Add(kup);
                }
                

                //cell.Text = string.Format("<br />");
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);

                if ((ile % 4 == 0 && ile != 0) || ile == count2)
                {
                    table.Rows.Add(row);
                    row = new TableRow();
                }
                ile++;
            }
            conn.Close();
            pItems.Controls.Add(table);
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
        public String UserName = "User";
        protected void btLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            this.UserName = "User";
            Response.Redirect("MainForm.aspx");
        }

        protected void btSignin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?from=all");
        }

        protected void btMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx");
        }

        protected void btAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produkty.aspx");
        }


        public void pag_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Response.Redirect("Produkty.aspx?pag="+btn.Text.ToString());
        }

        public void kup_click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            string idS = btn.ID;
            int id = Convert.ToInt32(idS);
            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            try
            {
                command.CommandText = "INSERT INTO `"+Session["username"].ToString()+"` (idUser, produkt_id) VALUES (NULL ," + id + ")";

                command.ExecuteNonQuery();
              
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
               
            }

            conn.Close();
            //zrobic paginację 
            // czyszczenie zawartości panel - pItems.Controls.Clear();
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