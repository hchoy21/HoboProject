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

            List<DateTime> dateTime = dbcon.readDateTime("dateTime");
            List<double> pressure = dbcon.readData("pressure");
            List<double> temperature = dbcon.readData("temperature");
            List<double> rh = dbcon.readData("rh");


            for (int i = dateTime.Count() - 1; i >= 0; i--)
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
            results = readingsList.ToList();

            searchStatusLabel.Text = "";
            bool flag = true;

            if (!String.IsNullOrWhiteSpace(searchDateBeginTB.Text) && !String.IsNullOrWhiteSpace(searchDateEndTB.Text))
            {
                results = date_Search(results);
                flag = false;
            }
            else if (String.IsNullOrWhiteSpace(searchDateBeginTB.Text) ^ String.IsNullOrWhiteSpace(searchDateEndTB.Text))
            {
                String error = "Please fill in both fields for " + searchDateLabel.Text + ".<br />";
                print_Error(error);
            }

            if (!String.IsNullOrWhiteSpace(searchPressureBeginTB.Text) && !String.IsNullOrWhiteSpace(searchPressureEndTB.Text))
            {
                results = pressure_Search(results);
                flag = false;
            }
            else if (String.IsNullOrWhiteSpace(searchPressureBeginTB.Text) ^ String.IsNullOrWhiteSpace(searchPressureEndTB.Text))
            {
                String error = "Please fill in both fields for " + searchPressureLabel.Text + ".<br />";
                print_Error(error);
            }

            if (!String.IsNullOrWhiteSpace(searchTempBeginTB.Text) && !String.IsNullOrWhiteSpace(searchTempEndTB.Text))
            {
                results = temp_Search(results);
                flag = false;
            }
            else if (String.IsNullOrWhiteSpace(searchTempBeginTB.Text) ^ String.IsNullOrWhiteSpace(searchTempEndTB.Text))
            {
                String error = "Please fill in both fields for " + searchTempLabel.Text + ".<br />";
                print_Error(error);
            }

            if (!String.IsNullOrWhiteSpace(searchRhBeginTB.Text) && !String.IsNullOrWhiteSpace(searchRhEndTB.Text))
            {
                results = rh_Search(results);
                flag = false;
            }
            else if (String.IsNullOrWhiteSpace(searchRhBeginTB.Text) ^ String.IsNullOrWhiteSpace(searchRhEndTB.Text))
            {
                String error = "Please fill in both fields for " + searchRhLabel.Text + ".<br />";
                print_Error(error);
            }

            if (!String.IsNullOrWhiteSpace(searchStatusLabel.Text) || flag)
            {
                results = readingsList;
            }
            GridView1.DataSource = results;
            GridView1.DataBind();
        }

        protected List<Readings> date_Search(List<Readings> results)
        {
            try
            {
                DateTime startDate = Convert.ToDateTime(searchDateBeginTB.Text);
                DateTime endDate = Convert.ToDateTime(searchDateEndTB.Text);

                if (startDate.Date.CompareTo(endDate) > 0)
                {
                    string error = "Invalid range of dates, please try again.<br />";
                    print_Error(error);
                    return readingsList;
                }

                for (int i = 0; i < readingsList.Count(); i++)
                {
                    if (startDate.Date.CompareTo(readingsList[i].Time.Date) <= 0 &&
                        endDate.Date.CompareTo(readingsList[i].Time.Date) >= 0)
                    {
                        results.Add(readingsList[i]);
                    }
                }
            }
            catch (FormatException)
            {
                string error = "Incorrect Date Format, please try again.<br />";
                print_Error(error);
                return readingsList;
            }

            return results;
        }

        protected List<Readings> pressure_Search(List<Readings> results)
        {
            double beginPressure = 0;
            double endPressure = 0;
            List<Readings> res = new List<Readings>();

            if (double.TryParse(searchPressureBeginTB.Text, out beginPressure) &&
                double.TryParse(searchPressureEndTB.Text, out endPressure))
            {
                if (beginPressure > endPressure)
                {
                    string error = "Invalid pressure range.<br />";
                    print_Error(error);
                    return readingsList;
                }
                for (int i = 0; i < results.Count(); i++)
                {
                    if (results[i].Pressure >= beginPressure &&
                        results[i].Pressure <= endPressure)
                    {
                        res.Add(results[i]);
                    }
                }
                return res;
            }
            else
            {
                string error = "Invalid pressure, please enter another number.<br />";
                print_Error(error);
                return readingsList;
            }
        }

        protected List<Readings> temp_Search(List<Readings> results)
        {
            double beginTemp = 0;
            double endTemp = 0;
            List<Readings> res = new List<Readings>();

            if (double.TryParse(searchTempBeginTB.Text, out beginTemp) &&
                double.TryParse(searchTempEndTB.Text, out endTemp))
            {
                if (beginTemp > endTemp)
                {
                    string error = "Invalid temperature range.<br />";
                    print_Error(error);
                    return readingsList;
                }
                for (int i = 0; i < results.Count(); i++)
                {
                    if (results[i].Temperature >= beginTemp &&
                        results[i].Temperature <= endTemp)
                    {
                        res.Add(results[i]);
                    }
                }
                return res;
            }
            else
            {
                string error = "Invalid temperature, please enter another number.<br />";
                print_Error(error);
                return readingsList;
            }
        }

        protected List<Readings> rh_Search(List<Readings> results)
        {
            double beginRh = 0;
            double endRh = 0;
            List<Readings> res = new List<Readings>();

            if (double.TryParse(searchRhBeginTB.Text, out beginRh) &&
                double.TryParse(searchRhEndTB.Text, out endRh))
            {
                if (beginRh > endRh)
                {
                    string error = "Invalid relative humidity range.<br />";
                    print_Error(error);
                    return readingsList;
                }
                for (int i = 0; i < results.Count(); i++)
                {
                    if (results[i].RelativeHumidity >= beginRh &&
                        results[i].RelativeHumidity <= endRh)
                    {
                        res.Add(results[i]);
                    }
                }
                return res;
            }
            else
            {
                string error = "Invalid relative humidity, please enter another number.<br />";
                print_Error(error);
                return readingsList;
            }
        }

        protected void print_Error(string error)
        {
            searchStatusLabel.Text = searchStatusLabel.Text + error;
        }

    }
}