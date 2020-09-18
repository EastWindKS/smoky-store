using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("StoreOrders", Schema = "Sales")]
    public class StoreOrder
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }
        public string TNumber { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public TobaccoProduct Product { get; set; }
    }
}