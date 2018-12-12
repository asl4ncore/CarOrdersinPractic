using Practic.Models.Models.BaseTables;
using System;
using System.Collections.Generic;

namespace Practic.Models
{
    public class Determine: BaseDictionary
    {
        public ICollection<Order> Orders { get; set; }

        public Determine()
        {
            Orders = new List<Order>();
            AuditDate = DateTime.Now;
        }
    }
}