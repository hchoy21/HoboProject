using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hobo_Project
{
    public partial class Default : System.Web.UI.Page
    {
        DBConnect dbcon;
        protected void Page_Load(object sender, EventArgs e)
        {
            // connect to database
            dbcon = new DBConnect();

            // get the latest data reading
            string currentPressure       = dbcon.getLastData("pressure");
            string currentTemperature    = dbcon.getLastData("temperature");
            string currentRh             = dbcon.getLastData("rh");

            // set the labels
            currentPressureLabel.Text    = currentPressure + " Hg";
            currentTemperatureLabel.Text = currentTemperature + " F";
            currentRHLabel.Text          = currentRh + "%";

        }
    }
}