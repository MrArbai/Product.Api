using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Api.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Tblcheklist")]
    public class Cheklist : BaseModel
    {
        [ExplicitKey]
        //public int Id { get; set; }?
        public string Name { get; set; }

    }
}
