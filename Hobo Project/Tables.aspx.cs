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
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnect();

            List<string> dateTime       = dbcon.readData("dateTime");
            List<string> pressure       = dbcon.readData("pressure");
            List<string> temperature    = dbcon.readData("temperature");
            List<string> rh             = dbcon.readData("rh");


            List<Readings> readingsList = new List<Readings>();
            for (int i = 0; i < dateTime.Count(); i++)
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
        
    }
}