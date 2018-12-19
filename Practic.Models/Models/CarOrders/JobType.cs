using Practic.Models.Models.BaseTables;
using System.Collections.Generic;

namespace Practic.Models
{
    public class JobType : BaseDictionary
    {
        public ICollection<Order> Orders { get; set; }
        public JobType()
        {
            Orders = new List<Order>();
        }
    }
}