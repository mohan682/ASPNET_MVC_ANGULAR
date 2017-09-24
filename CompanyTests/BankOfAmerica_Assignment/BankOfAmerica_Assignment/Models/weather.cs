using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankOfAmerica_Assignment.Models
{
    public class weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string iconUrl { get { return AppConstants.str_BaseUrl + "/img/w/" + icon + ".png"; } }
    }
}