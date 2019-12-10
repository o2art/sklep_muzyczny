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
    public partial class Admin : System.Web.UI.Page
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
            MySqlConnection connIle = connect();
            MySqlCommand commandIle = connIle.CreateCommand();
            commandIle.CommandText = "SELECT COUNT(*) FROM produkty";
            int count = Convert.ToInt32(commandIle.ExecuteScalar());
            connIle.Close();

            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * FROM produkty";
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
                kup.ImageUrl = "~/img/del.png";
                kup.Width = 30;
                kup.Height = 30;
                kup.ID = reader.GetString("id");
                kup.Click += new ImageClickEventHandler(this.del_click);

                ImageButton edit = new ImageButton();
                edit.ImageUrl = "~/img/edit.png";
                edit.Width = 30;
                edit.Height = 30;
                edit.ID = "E"+reader.GetString("id");
                edit.Click += new ImageClickEventHandler(this.edit_click);


                ImageButton sale = new ImageButton();
                sale.ImageUrl = "~/img/procent.png";
                sale.Width = 30;
                sale.Height = 30;
                sale.ID = "S" + reader.GetString("id");
                sale.Click += new ImageClickEventHandler(this.sale_click);



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
                cell.Controls.Add(edit);
                cell.Controls.Add(sale);



                //cell.Text = string.Format("<br />");
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
            pDel.Controls.Add(table);


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
        string UserName = "User";
        protected void btLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            this.UserName = "User";
            Response.Redirect("MainForm.aspx");
        }

        protected void btMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainForm.aspx");
        }

        protected void btAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produkty.aspx");
        }

        protected void imgTools_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            pAdd.Visible = true;
            pDel.Visible = false;
        }

        protected void btnZapiszAdd_Click(object sender, EventArgs e)
        {
            string tyt = tbTyt.Text.ToString();
            string gat = tbGat.Text.ToString();
            string wyk = tbWyk.Text.ToString();
            string cenaS = tbCen.Text.Replace(",", ".");
                                   //  double cena = Convert.ToDouble(cenaS);
           //s float cena = 0;
            MySqlConnection conn = connect();

            MySqlCommand command = conn.CreateCommand();
            try
            {
                command.CommandText = "INSERT INTO `produkty` (id, Tytul, Wykonawca, Gatunek,Cena) VALUES (NULL ,'" + tyt + "', '" + wyk + "', '" + gat + "','" + cenaS + "')";
                command.ExecuteNonQuery();
                lInfoAlert.Text = "Dodano produkt";
                pAdd.Visible = false;
                string uploadFolder = Request.PhysicalApplicationPath + "img\\";
                if (fuOkl.HasFile)
                {
                    string extension = Path.GetExtension(fuOkl.PostedFile.FileName);
                    fuOkl.SaveAs(uploadFolder + tyt.Replace(" ", "_") + extension);
                    // lInfoAlert.Text = " file uploader";
                    lInfoAlert.Text = "Dodano produkt";
                }
                else
                {
                    lInfoAlert.Text = "Nie dodano okładki";
                }
                tbTyt.Text = "";
                tbWyk.Text = "";
                tbGat.Text = "";
                tbCen.Text = "";
            }
            catch
            {
                lInfoAlert.Text = "Błąd nie udało się dodać do bazy";
                pAdd.Visible = false;
                tbTyt.Text = "";
                tbWyk.Text = "";
                tbGat.Text = "";
                tbCen.Text = "";
                
            }
            pDel.Visible = true;
            conn.Close();
            Response.Redirect("Admin.aspx");
        }

  


            public void del_click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            string idS = btn.ID;
            int id = Convert.ToInt32(idS);
            lId.Text = idS;
            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM `produkty` WHERE `id`="+idS;
            command.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Admin.aspx");

        }
        public void edit_click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            string idS = btn.ID;
            //    int id = Convert.ToInt32(idS);
            string id = idS.Substring(1, idS.Length -1);
            idS = idS.Substring(1, 1) + " edit";
            btnAdd.Visible = false;
            pUpdate.Visible = true;
            pDel.Visible = false;

           // lId.Text = id;
            //command.ExecuteNonQuery();
            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM produkty WHERE id="+id;
          
            MySqlDataReader reader = command.ExecuteReader();
          
            while (reader.Read())
            {
                lUpdate.Text  = "Update "+ reader.GetString("Tytul");
               
                tbTytU.Text = reader.GetString("Tytul");
                tbWykU.Text = reader.GetString("Wykonawca");
                tbGatU.Text = reader.GetString("Gatunek");
                tbCenU.Text = reader.GetString("Cena").Replace(".", ",");
                lidU.Text = id;
                lidU.Visible = false;
            }
            conn.Close();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string tyt = tbTytU.Text.ToString();
            string gat = tbGatU.Text.ToString();
            string wyk = tbWykU.Text.ToString();
            string cenaS = tbCenU.Text.Replace(",", ".");
            string id = lidU.Text;

            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE `produkty` SET `Tytul`='"+tyt+"',`Wykonawca`='"+wyk+"',`Gatunek`='"+gat+"',`Cena`='"+cenaS+"' WHERE `id`="+id;
           
            try
            {

                command.ExecuteNonQuery();
                lInfoAlert.Text = "Zaktualizowano produkt";

            }
            catch
            {
                lInfoAlert.Text = "Błąd nie udało się zaktualizować elementu";
                pUpdate.Visible = false;
                tbTytU.Text = "";
                tbWykU.Text = "";
                tbGatU.Text = "";
                tbCenU.Text = "";
            }
            conn.Close();
            Response.Redirect("Admin.aspx");
        }

        protected void btSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sale.aspx");
        }

        public void sale_click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            string idS = btn.ID;
            string id = idS.Substring(1, idS.Length - 1);
            lIdSale.Text = id.ToString();
            pSale.Visible = true;
            btnAdd.Visible = false;
            pDel.Visible = false;
           // lId.Text = "jeje";
            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT Cena FROM `produkty` WHERE `id`=" + id;
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                lCenaOld.Text = reader.GetString("Cena");
                lCenaOld.ForeColor = System.Drawing.Color.Red;
            }
                conn.Close();
           // Response.Redirect("Admin.aspx");

        }

        protected void btSaleOk_Click(object sender, EventArgs e)
        {
            string cena = tbSale.Text.Replace(",",".");
            string id = lIdSale.Text;
            MySqlConnection conn1 = connect();
            MySqlCommand command1 = conn1.CreateCommand();
            command1.CommandText = "SELECT COUNT(*) FROM sale WHERE idProdukt=" + id ;
            int count = Convert.ToInt32(command1.ExecuteScalar());
           
            
            conn1.Close();
           // lId.Text = count.ToString();
            if(count > 0)
            {
                MySqlConnection connD = connect();
                MySqlCommand commandD = connD.CreateCommand();
                commandD.CommandText = "DELETE FROM `sale` WHERE `idProdukt`=" + id;
                commandD.ExecuteNonQuery();
                connD.Close();
            }
            MySqlConnection conn = connect();
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO `sale` (idSale, idProdukt, obnizka) VALUES (NULL, '" + id + "', '" + cena + "')";
            command.ExecuteNonQuery();
            conn.Close();
           Response.Redirect("Admin.aspx");
        }
    }
}