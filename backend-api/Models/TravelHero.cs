using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Models
{
    public class TravelHero
    {
        public int IdTravel { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Vehicle { get; set; }
        public bool State { get; set; }
    }
}
