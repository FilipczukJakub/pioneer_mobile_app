using System;
using System.Collections.Generic;
using System.Text;

namespace PracaInzynierska.Models
{
    public class Twist
    {
        public Dictionary<String,double> Linear { get; set; }
        public Dictionary<String, double> Angular { get; set; }
        public Twist()
        {
            Linear = new Dictionary<String, double>
            {
                {"x",0.0 },
                {"y",0.0},
                {"z",0.0},
            };
            Angular = new Dictionary<String, double> {
                {"x",0.0},
                {"y",0.0},
                {"z",0.0}
            };
        }

        public Twist(double lx, double ly, double lz, double ax, double ay, double az)
        {
            Linear = new Dictionary<String, double>
            {
                {"x",lx },
                {"y",ly},
                {"z",lz},
            };
            Angular = new Dictionary<String, double> {
                {"x",ax},
                {"y",ay},
                {"z",az}
            };
        }
    }
}
