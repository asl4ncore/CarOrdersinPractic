using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Practic.Models.Models.BaseTables;

namespace Practic.Models
{
    public class Route: BaseDictionary
    {
        public ICollection<Order> Orders { get; set; }
        public Route()
        {
            Orders = new List<Order>();
        }
    }
}