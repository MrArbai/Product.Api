﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Api.Models
{
    [Table("TblItem")]
    public class Item : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
