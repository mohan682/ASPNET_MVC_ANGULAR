using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankOfAmerica_Assignment.Models
{
    public class forecast
    {
        public int dt { get; set; }
        public main main { get; set; }
        public IEnumerable<weather> weather { get; set; }
        //public Clouds clouds { get; set; }
        //public Wind wind { get; set; }
        //public Sys sys { get; set; }
        public string dt_txt { get; set; }
        //public Rain rain { get; set; }
        //public Snow snow { get; set; }
    }
}