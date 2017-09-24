using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankOfAmerica_Assignment.Models
{
    public class openWeatherResponse
    {
        //public string cod { get; set; }
        public double message { get; set; }
        //public int cnt { get; set; }
        public IEnumerable<forecast> list { get; set; }
        public city city { get; set; }
    }

    #region Unused code

    //public class Clouds
    //{
    //    public int all { get; set; }
    //}

    //public class Wind
    //{
    //    public double speed { get; set; }
    //    public double deg { get; set; }
    //}

    //public class Sys
    //{
    //    public string pod { get; set; }
    //}

    //public class Rain
    //{
    //    public double __invalid_name__3h { get; set; }
    //}

    //public class Snow
    //{
    //    public double __invalid_name__3h { get; set; }
    //}



    //public class Coord
    //{
    //    public double lat { get; set; }
    //    public double lon { get; set; }
    //}
    #endregion
}