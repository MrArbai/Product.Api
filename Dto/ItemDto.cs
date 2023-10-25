using Dapper.Contrib.Extensions;
using Product.Api.Models;

namespace Product.Api.Dto
{
    public class ItemDto : BaseModel
    {
        [ExplicitKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Cheklist CheklistID { get; set; }
    }
}
