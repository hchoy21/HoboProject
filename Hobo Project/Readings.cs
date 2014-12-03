using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hobo_Project
{
    public class Readings
    {
        public DateTime Time { get; set; }

        public double Pressure { get; set; }

        public double Temperature { get; set; }

        public double RelativeHumidity { get; set; }
    }
}