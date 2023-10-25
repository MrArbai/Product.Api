using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Api.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("TblItem")]
    public class Item : BaseModel
    {
        [ExplicitKey]
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CheklistID { get; set; }
    }
}
