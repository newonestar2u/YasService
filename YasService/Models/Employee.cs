namespace YasService.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public class Employee : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
    }
}