namespace WebApplication1.Models
{
    public class BicycleBrand
    {
        public int BicycleBrandID { get; set; }
        public int BrandTypeID { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public BrandType BrandType { get; set; }
    }
}
