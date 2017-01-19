namespace YasService.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Permission")]
    public class Permission
    {
        [Key]
        public string Id { get; set; }
        public string Service { get; set; }
    }
}