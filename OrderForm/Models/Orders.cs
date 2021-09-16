using System;
using System.ComponentModel.DataAnnotations;

namespace OrderForm.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverAddress { get; set; }
        public double Weight { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}