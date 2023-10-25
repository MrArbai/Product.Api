using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Api.Models
{
    [Table("TblUser")]
    public class User : BaseModel
    {
        //public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string Token { get; set; }
        
    }
}
