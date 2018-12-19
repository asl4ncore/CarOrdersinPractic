using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practic.Models.Models.Lombard
{
    public class Operation
    {
        public int Id { get; set; }
        [Display(Name = "Клиент")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [Display(Name = "Залог")]

        public int PledgeId { get; set; }
        public Pledge Pledge { get; set; }
        [Display(Name = "Цена за грамм")]
        public int PriceGram { get; set; }
        [Display(Name = "Цена за изделия")]
        public int PriceProducts { get; set; }
        [Display(Name = "Цена возврата")]
        public int PriceRefund { get; set; }
        [Display(Name = "Процент комиссии")]
        public double CommissionPercentage { get; set; }
        [Display(Name = "День хранение")]
        public DateTime StorageDay { get; set; }
        [Display(Name = "День оплаты")]
        public DateTime PaymentDay { get; set; }
        [Display(Name = "День операции")]
        public DateTime OperationDay { get; set; }
        [Display(Name = "Имя оператора")]
        public string OperatorName { get; set; }
    }
}