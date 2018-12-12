using System.Collections.Generic;
using Practic.Models.Models.BaseTables;

namespace Practic.Models
{
    public class RouteType: BaseDictionary
    {
        public ICollection<Order> Orders { get; set; }
        public RouteType()
        {
            Orders = new List<Order>();
        }
    }
}