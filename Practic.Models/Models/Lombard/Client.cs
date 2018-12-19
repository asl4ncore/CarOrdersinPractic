using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practic.Models.Models.Lombard
{
    public class Client
    {
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        public Client()
        {
            Operations = new List<Operation>();
        }
        public ICollection<Operation> Operations { get; set; }
    }
}