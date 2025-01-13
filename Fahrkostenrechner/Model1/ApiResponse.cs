using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrkostenrechner.Model1
{
    public class ApiResponse
    {
        public bool Ok { get; set; }
        public string License { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
        public List<Station> Stations { get; set; }
    }
}
