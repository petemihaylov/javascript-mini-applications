using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar4e.Models
{
    public class HouseViewModel
    {
        public IEnumerable<HouseRule> listRules { get; set; }

        public HouseRule houseRule { get; set; }
    }
}