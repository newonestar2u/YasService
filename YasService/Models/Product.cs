﻿namespace YasService.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
    }
}