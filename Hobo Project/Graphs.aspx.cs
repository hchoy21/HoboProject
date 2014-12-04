using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;

namespace Hobo_Project
{
    public partial class Graphs : System.Web.UI.Page
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



            // set the graph
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
                .SetXAxis(new XAxis
                {
                    /******* TODO: I think this is where the chart label options are set  *******/
                    // 1 - delete the x/y axis data labels
                    // 2 - add axis titles
                    // 3 - make the graph larger to be easier to see
                    Categories = this.setCategories()
                })
                .SetSeries(new Series
                {
                    Data = new Data(this.setData())
                });

            chart.SetTitle(new Title { Text = "Pressure vs Time" });
            ltrChart.Text = chart.ToHtmlString();


        }


        // set categories
        private string[] setCategories()
        {
            string[] results = new string[readingsList.Count()];

            for (int i = 0; i < readingsList.Count(); i++)
            {
                results[i] = readingsList[i].Time.ToString();
            }

            return results;

        }

        private object[] setData()
        {
            object[] results = new object[readingsList.Count()];

            for (int i = 0; i < readingsList.Count(); i++)
            {
                results[i] = readingsList[i].Pressure;
            }

            return results;
        }
    }
}