namespace YasService.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public class User : BaseModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool IsActive{ get; set; }
    }
}