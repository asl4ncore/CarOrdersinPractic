using Practic.Models.Models.BaseTables;
using System.Collections.Generic;

namespace Practic.Models
{
    public  class Machine : BaseDictionary
    {
        public string Type { get; set; }
        public string Driver { get; set; }
        public string Manufactor { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Machine()
        {
            Orders = new List<Order>();
        }

    }
}
