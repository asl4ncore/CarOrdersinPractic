using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practic.Models.Models.Lombard
{
    public class PledgeType
    {
        public int Id { get; set; }
        [Display(Name = "Тип Залога")]
        public string Name { get; set; }

        public PledgeType()
        {
            Pledges = new List<Pledge>();
        }
        public ICollection<Pledge> Pledges { get; set; }
    }
}
