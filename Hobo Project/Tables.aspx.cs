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

            List<DateTime> dateTime     = dbcon.readDateTime("dateTime");
            List<double> pressure       = dbcon.readData("pressure");
            List<double> temperature    = dbcon.readData("temperature");
            List<double> rh             = dbcon.readData("rh");


            for (int i = dateTime.Count()-1; i >= 0; i--)
            {
                readingsList.Add(new Readings()
                {
                    Time = dateTime[i],
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
            List<Readings> results = new List<Readings>();
            // 1 - check if both TextBox are filled
            if (!isEmptySearch())
            {
                try
                {
                    DateTime startDate = Convert.ToDateTime(searchDateBeginTB.Text);
                    DateTime endDate = Convert.ToDateTime(searchDateEndTB.Text);


                    for (int i = 0; i < readingsList.Count(); i++)
                    {
                        if (startDate.Date.CompareTo(readingsList[i].Time.Date) <= 0 &&
                            endDate.Date.CompareTo(readingsList[i].Time.Date) >= 0)
                        {
                            results.Add(readingsList[i]);
                        }
                    }

                }catch(FormatException){
                    searchStatusLabel.Text = "Incorrect Date Format, please try again";
                }

                

            }


            GridView1.DataSource = results;
            GridView1.DataBind();
            
        }

        protected Boolean isEmptySearch()
        {
            if (searchDateBeginTB == null || searchDateEndTB == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}