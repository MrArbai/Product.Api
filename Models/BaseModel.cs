namespace Product.Api.Models
{
    public class BaseModel
    {
        public bool Isactive { get; set; } = true;

        public string Createdby { get; set; }
        public DateTime? Createddate { get; set; } = DateTime.Now;
        public string Lastupdatedby { get; set; }
        public DateTime? Lastupdateddate { get; set; }
    }
}
