using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderForm.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [DisplayName("Номер заказа")]
        public Guid OrderId { get; set; }
        
        [DisplayName("Город отправителя")]
        [Required (ErrorMessage = "Не указан город отправителя")]
        public string SenderCity { get; set; }
        
        [DisplayName("Адрес отправителя")]
        [Required (ErrorMessage = "Не указан адрес отправителя")]
        public string SenderAddress { get; set; }
        
        [DisplayName("Город получателя")]
        [Required (ErrorMessage = "Не указан город получателя")]
        public string ReceiverCity { get; set; }
        
        [DisplayName("Адрес получателя")]
        [Required (ErrorMessage = "Не указан адрес получателя")]
        public string ReceiverAddress { get; set; }
        
        [DisplayName("Вес груза")]
        [Required (ErrorMessage = "Не указан вес груза")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Минимальный вес - 0.01")]
        public double Weight { get; set; }
        
        [DisplayName("Дата забора груза")]
        [Required (ErrorMessage = "Не указана дата забора груза")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}