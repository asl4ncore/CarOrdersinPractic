using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Models.Models.BaseTables
{
    public class BaseTable
    {
        public BaseTable()
        {
            AuditDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Дата/Время начала работ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy  hh:mm }", ApplyFormatInEditMode = true)]
        public DateTime AuditDate { get; set; }
    }
}
