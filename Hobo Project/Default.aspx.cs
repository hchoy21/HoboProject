using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml;

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
            currentTemperatureLabel.Text = currentTemperature + " °F";
            currentRHLabel.Text          = currentRh + "%";

            // resets votes everyday
            if (checkTime())
            {
                clearXML();
            }
        }

        protected void butVote_Click(object sender, EventArgs e)
        {
            if (radVote.SelectedItem == null)
                lblStatus.Text = "Please make your prediction";
            else if (Request.Cookies["Voted"] == null)
            {
                Response.Cookies["Voted"].Value = "True";

                int hoursLeft = 23 - DateTime.Now.Hour;
                int minutesLeft = 59 - DateTime.Now.Minute;
                int secondsLeft = 60 - DateTime.Now.Second;
                DateTime midnight = DateTime.Now.AddHours(hoursLeft);
                midnight = midnight.AddMinutes(minutesLeft);
                midnight = midnight.AddSeconds(secondsLeft);

                Response.Cookies["Voted"].Expires = midnight;
                countVote(radVote.SelectedItem.ToString());
            }
            else
                lblStatus.Text = "Only one vote per day please.";
        }

        protected void countVote(string theVote)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(Server.MapPath("Poll.xml"));

                xmlDoc.Element("Poll").Add(new XElement("Vote", new XElement("Choice", theVote),
                    new XElement("Time", DateTime.Now.ToString())));

                xmlDoc.Save(Server.MapPath("Poll.xml"));
                lblStatus.Text = "Thank you for your vote.";
                readXML();
            }
            catch
            {
                lblStatus.Text = "Sorry, unable to process request. Please try again.";
            }
        }

        protected void readXML()
        {
            XDocument xmlDoc = XDocument.Load(Server.MapPath("Poll.xml"));

            var votes = from vote in xmlDoc.Descendants("Vote")
                        select new
                        {
                            Vote = vote.Element("Choice").Value,
                        };

            string[] weather = { "Clear Skies", "Light rain", "Heavy rain",
                                "Cloudy hot", "Cloudy warm", "Cloudy cold",
                                "Sunny and Warm", "Hot and humid", "Sunny and cold",
                                "Foggy", "Thunderstorm", "Windy hot",
                                "Windy cold", "Windy"};
            int[] count = new int[14];

            for (int i = 0; i < count.Count(); i++)
            {
                foreach (var vote in votes)
                {
                    if (vote.Vote == weather[i])
                        count[i]++;
                }
            }

            int total = xmlDoc.Element("Poll").Elements("Vote").Count();
            double theTotal = total;
            double[] percent = new double[14];

            if (theTotal != 0)
            {
                for (int i = 0; i < percent.Count(); i++)
                {
                    percent[i] = (count[i] / theTotal) * 100;
                }
            }

            litResults.Visible = true;
            litResults.Text = "<br />";
            for (int i = 0; i < weather.Count(); i++)
            {
                litResults.Text = litResults.Text + weather[i] + ": " + count[i] + " votes (" + percent[i] + "%).<br />";
            }
        }

        protected void clearXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("Poll.xml"));

            XmlNode poll = xmlDoc.SelectSingleNode("//Poll");
            XmlNodeList votes = poll.SelectNodes("Vote");

            for (int i = 0; i < votes.Count; i++)
            {
                poll.RemoveChild(votes[i]);
                xmlDoc.Save(Server.MapPath("Poll.xml"));
            }
        }

        protected bool checkTime()
        {
            XDocument xmlDoc = XDocument.Load(Server.MapPath("Poll.xml"));

            if (xmlDoc.Element("Poll").Element("Vote") == null)
            {
                return false;
            }

            char[] delimiterChars = { ' ', '/', ':' };
            string time = xmlDoc.Element("Poll").Element("Vote").Element("Time").Value;
            string[] date = time.Split(delimiterChars);

            int day = Convert.ToInt32(date[1]);
            int month = Convert.ToInt32(date[0]);
            int year = Convert.ToInt32(date[2]);

            if (day != DateTime.Now.Day || month != DateTime.Now.Month || year != DateTime.Now.Year)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void butResults_Click(object sender, EventArgs e)
        {
            if (butResults.Text == "Show Results")
            {
                readXML();
                butResults.Text = "Hide Results";
            }
            else
            {
                litResults.Visible = false;
                butResults.Text = "Show Results";
            }
        }
    }
}