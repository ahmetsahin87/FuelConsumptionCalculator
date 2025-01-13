using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrkostenrechner.Model
{
    internal class CarData
    {
        public int ModelYear { get; set; }
        public string Division { get; set; }
        public string Carline { get; set; }
        public double City { get; set; }
        public double Hwy { get; set; }
        public double Comb { get; set; }
    }
}
