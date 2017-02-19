namespace YasService.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Invoice")]
    public class Invoice : BaseModel
    {
        public string CustomerId { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderdOn { get; set; }
        public DateTime DeliveredOn { get; set; }
        public Decimal Amount { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
    }
}