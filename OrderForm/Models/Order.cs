using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderForm.Models
{
    public class Order
    {
        [DisplayName("Номер заказа")]
        public int Id { get; init; }
        
        [DisplayName("Город отправителя")]
        [Required (ErrorMessage = "Не указан город отправителя")]
        public string SenderCity { get; init; }
        
        [DisplayName("Адрес отправителя")]
        [Required (ErrorMessage = "Не указан адрес отправителя")]
        public string SenderAddress { get; init; }
        
        [DisplayName("Город получателя")]
        [Required (ErrorMessage = "Не указан город получателя")]
        public string ReceiverCity { get; init; }
        
        [DisplayName("Адрес получателя")]
        [Required (ErrorMessage = "Не указан адрес получателя")]
        public string ReceiverAddress { get; init; }
        
        [DisplayName("Вес груза")]
        [Required (ErrorMessage = "Не указан вес груза")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Минимальный вес - 0.01")]
        public double Weight { get; init; }
        
        [DisplayName("Дата забора груза")]
        [Required (ErrorMessage = "Не указана дата забора груза")]
        [DataType(DataType.Date)]
        public DateTime Date { get; init; }
    }
}