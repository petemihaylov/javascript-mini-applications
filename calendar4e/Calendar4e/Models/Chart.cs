using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar4e.Models
{
    public class Chart
    {
     public Chart(double count, string text)
        {
            y = count;
            label = text;
        }
      public double y { get; set; }
      public string label { get; set; }
    }
}