using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csaa_jo
{
    internal class Database
    {
        MySqlConnection connection = null;
        MySqlCommand sqlCommand = null;

        public Database()
        {



            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "csaa";
            connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                sqlCommand = connection.CreateCommand();
                connection.Close();
            }

            catch (MySqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private void Nyit()
        {

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        private void Zar()
        {


            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        public List<Dolgozok> getDolgozok()
        {
            List<Dolgozok> dolgozok = new List<Dolgozok>();
            sqlCommand.CommandText = "SELECT * FROM `user_details`";
            try
            {
                Nyit();
                using (MySqlDataReader dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dolgozok dolgozoks = new Dolgozok(dr.GetInt32("userid"), dr.GetString("firstname"), dr.GetString("lastname"));
                        dolgozok.Add(dolgozoks);
                    }
                }
                Zar();
                return dolgozok;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dolgozok;

        }
        public List<Food> getFood()
        {
            List<Food> food = new List<Food>();
            sqlCommand.CommandText = "SELECT * FROM `food`";
            try
            {
                Nyit();
                using (MySqlDataReader dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Food foods = new Food(dr.GetInt32("price"), dr.GetString("name"));
                        food.Add(foods);
                    }
                }
                Zar();
                return food;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return food;

        }
    }
}
