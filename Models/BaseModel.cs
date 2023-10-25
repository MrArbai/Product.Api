namespace Product.Api.Models
{
    public class BaseModel
    {
        public bool Isactive { get; set; } = true;

        public string Createdby { get; set; }
        public DateTime? Createddate { get; set; } = DateTime.Now;
        public string Last_updated_by { get; set; }
        public DateTime? Last_updated_date { get; set; }
    }
}
