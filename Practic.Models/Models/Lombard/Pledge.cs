using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practic.Models.Models.Lombard
{
    public class Pledge
    {
        public int Id { get; set; }
        [Display(Name = "Залог")]
        public string Name { get; set; }
        [Display(Name = "Проба")]
        public int Sampling { get; set; }
        [Display(Name = "Чистый вес")]
        public double NetWeight { get; set; }
        [Display(Name = "Общий вес")]
        public double TotalWeight { get; set; }
        [Display(Name = "Тип залога")]

        public int PledgeTypeId { get; set; }
        public PledgeType PledgeType { get; set; }

        public Pledge()
        {
            Operations = new List<Operation>();
        }
        public ICollection<Operation> Operations { get; set; }
    }
}
