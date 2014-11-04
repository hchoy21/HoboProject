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

        //Insert statement
        public void Insert()
        {
            // not needed for this project
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }


        public List<string> readData(string colName)
        {
            string query = "SELECT " + colName + " FROM readouts";

            List<string> results = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    results.Add(dataReader[colName] + "");
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

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM readouts";

            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

            //open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // read data and store in list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["dateTime"] + "");
                    list[1].Add(dataReader["pressure"] + "");
                    list[2].Add(dataReader["temperature"] + "");
                    list[3].Add(dataReader["rh"] + "");
                }

                // close datareader and connection
                dataReader.Close();
                this.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }


        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}