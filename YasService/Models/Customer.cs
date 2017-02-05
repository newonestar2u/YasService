namespace YasService.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customer")]
    public class Customer : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerId { get; set; }
        public string DoorNo { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Contact { get; set; }
        public decimal Balance { get; set; }
        public decimal CreditLimit { get; set; }
        public bool IsActive { get; set; }
    }
}