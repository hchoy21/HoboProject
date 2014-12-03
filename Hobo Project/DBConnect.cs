using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Hobo_Project
{
    public class DBConnect
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "satnet.fgcu.edu";
            database = "hobo";
            uid = "nmlv2";
            password = "";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" +
                password + ";";

            conn = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                conn.Close();
                conn.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        Console.Write("Cannot connect to server.");
                        break;
                    
                    case 1045:
                        Console.Write("Invalid user/pass");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
                return false;
            }
        }

        public string getLastData(string colName)
        {
            string query = "SELECT " + colName + " FROM test"
                + " ORDER BY " + colName + " DESC";
            
            string result = "n/a";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    result = dataReader[colName].ToString();
                }

                dataReader.Close();
                this.CloseConnection();

                return result;
            }
            else
            {
                return result;
            }
        }


        public List<double> readData(string colName)
        {
            string query = "SELECT " + colName + " FROM test";

            List<double> results = new List<double>();


            // connect to mysql database and table
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // loop through table to read
                while (dataReader.Read())
                {
                    // convert entry to a string
                    string entry = dataReader[colName].ToString();
                    results.Add(Convert.ToDouble(entry));
                }

                dataReader.Close();
                this.CloseConnection();

                return results;
            }
            else
            {
                return results;
            }
        }

        public List<DateTime> readDateTime(string colName)
        {
            string query = "SELECT " + colName + " FROM test";

            List<DateTime> results = new List<DateTime>();


            // connect to mysql database and table
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // loop through table to read
                while (dataReader.Read())
                {
                    // convert entry to a string
                    string entry = dataReader[colName].ToString();

                    // convert to type DateTime
                    DateTime theDateTime = DateTime.ParseExact(entry, "MM/dd/yy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    // add to List results
                    results.Add(theDateTime);

                }

                dataReader.Close();
                this.CloseConnection();

                return results;
            }
            else
            {
                return results;
            }
        }

        
    }
}