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


            for (int i = 0; i < dateTime.Count(); i++)
            {
                readingsList.Add(new Readings()
                {
                    Time = dateTime[i],
                    Pressure = pressure[i],
                    Temperature = temperature[i],
                    RelativeHumidity = rh[i]
                });
            }


            displayPressureChart();
            displayTemperatureChart();
            displayRelativeHumidityChart();


        }

        private void displayPressureChart()
        {
            // set the chart
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("PressureChart")
                .SetXAxis(new XAxis
                {
                    Categories = this.setCategories(),
                    Title = new XAxisTitle { Text = "Time" },
                    Labels = new XAxisLabels { Enabled = false }
                })
                .SetYAxis(new YAxis
                {
                    Title = new YAxisTitle { Text = "Pressure" }
                })
                .SetLegend(new Legend
                {
                    Enabled = false
                })
                .SetSeries(new Series
                {
                    Data = new Data(this.setPressureData()),
                    Name = "Pressure"
                })
                .SetTitle(new Title { Text = "Pressure vs Time" });

            pressureChart.Text = chart.ToHtmlString();
        }

        private void displayTemperatureChart()
        {
            // set the chart
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("TemperatureChart")
                .SetXAxis(new XAxis
                {
                    Categories = this.setCategories(),
                    Title = new XAxisTitle { Text = "Time" },
                    Labels = new XAxisLabels { Enabled = false }
                })
                .SetYAxis(new YAxis
                {
                    Title = new YAxisTitle { Text = "Temperature" }
                })
                .SetLegend(new Legend
                {
                    Enabled = false
                })
                .SetSeries(new Series
                {
                    Data = new Data(this.setTemperatureData()),
                    Name = "Temperature"
                })
                .SetTitle(new Title { Text = "Temperature vs Time"});


            temperatureChart.Text = chart.ToHtmlString();
        }

        private void displayRelativeHumidityChart()
        {
            // set the chart
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("RHChart")
                .SetXAxis(new XAxis
                {
                    Categories = this.setCategories(),
                    Title = new XAxisTitle { Text = "Time" },
                    Labels = new XAxisLabels { Enabled = false }
                })
                .SetYAxis(new YAxis
                {
                    Title = new YAxisTitle { Text = "Relative Humidity" }
                })
                .SetLegend(new Legend
                {
                    Enabled = false
                })
                .SetSeries(new Series
                {
                    Data = new Data(this.setRelativeHumidityData()),
                    Name = "Relative Humidity"
                })
                .SetTitle(new Title { Text = "Relative Humidity vs Time" });

            rhChart.Text = chart.ToHtmlString();
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

        private object[] setPressureData()
        {
            object[] results = new object[readingsList.Count()];

            for (int i = 0; i < readingsList.Count(); i++)
            {
                results[i] = readingsList[i].Pressure;
            }

            return results;
        }

        private object[] setTemperatureData()
        {
            object[] results = new object[readingsList.Count()];

            for (int i = 0; i < readingsList.Count(); i++)
            {
                results[i] = readingsList[i].Temperature;
            }

            return results;
        }

        private object[] setRelativeHumidityData()
        {
            object[] results = new object[readingsList.Count()];

            for (int i = 0; i < readingsList.Count(); i++)
            {
                results[i] = readingsList[i].RelativeHumidity;
            }

            return results;
        }
    }
}