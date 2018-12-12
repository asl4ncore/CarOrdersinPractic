using Practic.Models.Models.BaseTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practic.Models
{

    public class Order:BaseTable
    {
        public Order()
        {
            Weights = new HashSet<Weigh>();

        }
        [Display(Name = "Машина подрядчика")]
        public bool MachineContractor { get; set; }
        [Display(Name = "№ машины")]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        [Range(0, 100, ErrorMessage = "Неверное количество партии!")]
        [Display(Name = "Партии")]
        public int Consignment { get; set; }
        [Display(Name = "ТипМаршрута")]
        public int RouteTypeId { get; set; }
        public RouteType RouteType { get; set; }
        [Display(Name = "Материал")]
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        [Display(Name = "Маршрут")]
        public int RouteId { get; set; }
        public Route Route { get; set; }
        //public int RouteToId { get; set; }
        [Display(Name = "Определение тары")]
        public int DetermineId { get; set; }
        public Determine Determine { get; set; }
        [Display(Name = "Тип работ")]
        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public ICollection<Weigh> Weights { get; set; }
    }
}
