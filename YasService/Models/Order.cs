namespace YasService.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Order")]
    public class Order : BaseModel
    {
        //public Order()
        //{
        //    //OrderLines = new HashSet<OrderLine>();
        //}

        public string CustomerId { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderBy { get; set; }
        public string SalesBy { get; set; }
        public decimal Discount { get; set; }
        public string DiscountReason { get; set; }
        public bool Approved { get; set; }
        public decimal Balance { get; set; }
        public decimal Payment { get; set; }
        public string PaymentType { get; set; }

        //[Required]
        //[ForeignKey("Id")]
        //public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}