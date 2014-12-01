using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Hobo_Project
{
    public partial class Tables : System.Web.UI.Page
    {
        DBConnect dbcon;
        List<Readings> readingsList = new List<Readings>();

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnect();

            List<string> dateTime       = dbcon.readData("dateTime");
            List<string> pressure       = dbcon.readData("pressure");
            List<string> temperature    = dbcon.readData("temperature");
            List<string> rh             = dbcon.readData("rh");


            for (int i = dateTime.Count()-1; i >= 0; i--)
            {
                readingsList.Add(new Readings()
                {
                    DateTime = dateTime[i],
                    Pressure = pressure[i],
                    Temperature = temperature[i],
                    RelativeHumidity = rh[i]
                });
            }
            GridView1.DataSource = readingsList;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Date and Time";
                e.Row.Cells[1].Text = "Pressure (Hg)";
                e.Row.Cells[2].Text = "Temperature (°F)";
                e.Row.Cells[3].Text = "Relative Humidity ";
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            List<Readings> tempReadingsList = new List<Readings>();
            int startPosition = 0;
            int endPosition = 0;
            if (searchDateBeginTB.Text == null || searchDateEndTB.Text == null)
            {
                // print ERROR message
            }
            else
            {
                // run through original list
                // get the index of the matching date entry (begin)
                for (int i = 0; i <= readingsList.Count(); i++)
                {
                    if (searchDateEndTB.Text.Equals(readingsList[i].DateTime.Remove(8)))
                    {
                        startPosition = i;
                        break;
                    }
                }


                // get the index of the matching date entry (end)
                bool flag = false;
                for (int i = 0; i <= readingsList.Count(); i++)
                {
                    if (searchDateBeginTB.Text.Equals(readingsList[i].DateTime.Remove(8)))
                    {
                        // set flag once the end date has been matched
                        // run until the date no longer matches (next day)
                        flag = true;
                        continue;
                    }
                    else if ((!searchDateBeginTB.Text.Equals(readingsList[i].DateTime.Remove(8))) && flag)
                    {
                        endPosition = i;
                        break;
                    }
                }

                for (int i = startPosition; i <= endPosition - 1; i++)
                {
                    tempReadingsList.Add(new Readings()
                    {
                        DateTime = readingsList[i].DateTime,
                        Pressure = readingsList[i].Pressure,
                        Temperature = readingsList[i].Temperature,
                        RelativeHumidity = readingsList[i].RelativeHumidity
                    });
                }
            }

            string searchBegin = searchDateBeginTB.Text;
            string searchEnd   = searchDateEndTB.Text;




            // update the table
            GridView1.DataSource = tempReadingsList;
            GridView1.DataBind();
        }
        
    }
}