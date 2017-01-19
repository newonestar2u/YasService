namespace YasService.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TeamPermission")]
    public class TeamPermission
    {
        [Key]
        public string Team { get; set; }
        public string Descirption { get; set; }
        public int Permission { get; set; }
    }
}