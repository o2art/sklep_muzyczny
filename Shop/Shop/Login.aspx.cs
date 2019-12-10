using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String from = Request.QueryString["from"];
            if(from == null)
            {
                this.BackTo = "MainForm.aspx";
            }
            else
            {
                switch (from)
                {
                    case "home":
                        this.BackTo = "MainForm.aspx";
                        break;
                    case "all":
                        this.BackTo = "Produkty.aspx";
                        break;
                    case "sale":
                        this.BackTo = "Sale.aspx";
                        break;

                }
            }
        }
        public String BackTo = "MainForm.aspx";
       public MySqlConnection connect()
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
                Console.WriteLine("Error");
            }
            return null;
        }
        

        protected void btLogin_Click(object sender, EventArgs e)
        {
            string login = iLogin.Text;
            string password = iPassword.Text;

            
            if(login != "" && password != "")
            {

                MySqlConnection conn = connect();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT count(*) FROM users WHERE login='" + login + "'";
                int count = Convert.ToInt32(command.ExecuteScalar());
                lLoginError.Text = count.ToString();
                if (count > 0)
                {
                    int res = reader(password, login);
                    if (res > -1)
                    {
                        lLoginError.Text = "Logowanie powiodło się";
                        Session["username"] = login;
                        Response.Redirect(this.BackTo);
                    }
                    else
                    {
                        lLoginError.Text = "Błędne hasło  lub login";
                    }
                }
                else
                {
                    lLoginError.Text = "Brak podanego użytkownika";
                }
                conn.Close();
            }
            else
            {
                lLoginError.Text = "Pola login i hasło nie mogą być puste";
            }
            
        }

        public int reader(string password, string login)
        {
            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * FROM users WHERE login='" + login+"' AND password='"+password+"'";
            MySqlDataReader reader = command.ExecuteReader();
            
            
                while (reader.Read())
                {
                    return (int)reader["id"];
                }

            conn.Close();
            return -1;
        }

        public int Check(string login)
        {
            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * FROM users WHERE login='" + login + "'";
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                return (int)reader["id"];
            }
            conn.Close();
            return -1;
            
        }


            protected void btRegister_Click(object sender, EventArgs e)
        {
            lMail.Visible = true;
            btLogin.Visible = false;
            btRegister2.Visible = true;
            tbMail.Visible = true;
            btRegister.Visible = false;
            rfvMail.Visible = true;
            revMail.Visible = true;
        }


        public int Insert(string login, string password, string mail)
        {

            MySqlConnection conn = connect();
            if (conn == null) return -1;
            MySqlCommand command = conn.CreateCommand();
            try
            {
                command.CommandText = "INSERT INTO `users` (id, login, password, mail) VALUES (NULL ,'" + login + "', '" + password + "', '" + mail + "')";

                command.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                lLoginError.Text = "Wystąpił bład bazy danych" + ex;
                conn.Close();
                return -1;
            }

        }

        protected void btRegister2_Click(object sender, EventArgs e)
        {
            string login = iLogin.Text;
            string password = iPassword.Text;
            string mail = tbMail.Text;
            if(login !="" && password !="" && mail != "")
            {
                int istnieje = Check(login);
                if(istnieje > -1)
                {
                    lLoginError.Text = "Podany login już istnieje";
                }
                else
                {
                    int res = Insert(login, password, mail);
                    if (res > -1)
                    {
                        lLoginError.Text = "Rejestracja powiodła się";
                        //tworzenie tabeli dla nowego użytkownika
                        MySqlConnection conn = connect();
                        MySqlCommand command = conn.CreateCommand();
                        command.CommandText = "CREATE TABLE `music`.`"+login+"` ( `idUser` INT NOT NULL AUTO_INCREMENT , `produkt_id` INT NOT NULL , PRIMARY KEY (`idUser`), KEY `produkt_id` (`produkt_id`)) ENGINE = InnoDB;";

                        command.ExecuteNonQuery();
                        //CREATE TABLE `music`.`wiktor` ( `id` INT NOT NULL AUTO_INCREMENT , `produkt_id` INT NOT NULL , PRIMARY KEY (`id`), KEY `produkt_id` (`produkt_id`)) ENGINE = InnoDB;
                        
                        
                        //koszyk - pobranie relacjami
                        //SELECT produkty.* FROM `wiktor`,`produkty` WHERE produkty.id=wiktor.produkt_id 

                        Session["username"] = login;
                        Response.Redirect(this.BackTo);
                        conn.Close();
                    }
                    else
                    {
                         lLoginError.Text = "Rejestracja nie powiodła się";
                    }
                }
               
            }
            else
            {
                lLoginError.Text = "Poniższe pola są wymagane !";
            }

        }
    }
}