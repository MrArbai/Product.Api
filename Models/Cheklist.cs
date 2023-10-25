using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Api.Models
{
    [Table("Tblcheklist")]
    public class Cheklist : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
