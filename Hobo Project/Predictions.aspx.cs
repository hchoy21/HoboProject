using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;

namespace Hobo_Project
{
    public partial class Predictions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            int rainCount;
            int clearCount;
            int sunnyCount;
            rainCount = 0;
            clearCount = 0;
            sunnyCount = 0;

            foreach (var vote in votes)
            {
                if (vote.Vote == "Rain")
                    rainCount++;
                else if (vote.Vote == "Clear Skies")
                    clearCount++;
                else if (vote.Vote == "Sunny")
                    sunnyCount++;
            }

            double theTotal;
            theTotal = rainCount + clearCount + sunnyCount;
            double rainPercent;
            double clearPercent;
            double sunnyPercent;
            if (theTotal != 0)
            {
                rainPercent = (rainCount / theTotal) * 100;
                clearPercent = (clearCount / theTotal) * 100;
                sunnyPercent = (sunnyCount / theTotal) * 100;
            }
            else
            {
                rainPercent = 0;
                clearPercent = 0;
                sunnyPercent = 0;
            }

            litResults.Visible = true;
            litResults.Text = "Rain: " + rainCount + " votes (" + rainPercent + "%).<br />";
            litResults.Text = litResults.Text + "Clear Skies: " + clearCount + " votes (" + clearPercent + "%).<br />";
            litResults.Text = litResults.Text + "Sunny: " + sunnyCount + " votes (" + sunnyPercent + "%).<br /><br />";
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