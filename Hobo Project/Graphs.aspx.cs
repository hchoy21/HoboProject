using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }
    }
}