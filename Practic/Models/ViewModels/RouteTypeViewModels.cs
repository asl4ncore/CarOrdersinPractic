using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practic.Models.ViewModels
{
    public class RouteTypeViewModels
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Тип маршрута")]
        public string Name { get; set; }
    }
}