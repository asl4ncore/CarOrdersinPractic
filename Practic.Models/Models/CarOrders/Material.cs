using Practic.Models.Models.BaseTables;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practic.Models
{
    public class Material: BaseDictionary
    { 
        public ICollection<Order> Orders { get; set; }
        [Display(Name = "Тип работ")]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public Material()
        {
            Orders = new List<Order>();
        }
    }
}