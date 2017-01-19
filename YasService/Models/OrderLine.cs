namespace YasService.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.ComponentModel.DataAnnotations;

    [Table("Order_Ln")]
    public class OrderLine : BaseModel
    {
        //[ForeignKey("Order")]
        [Required]
        public int OrderNumber { get; set; }
        public DateTime DeliveredOn { get; set; }
        public string Product { get; set; }
        public decimal Quantity { get; set; }
        public string DeliveredBy { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }

        //[Required]
        //public virtual Order Order { get; set; }
    }
}