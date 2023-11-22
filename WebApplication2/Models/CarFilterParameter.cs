namespace WebApplication2.Models
{
    public class CarFilterParameter
    {

        public string? Marka { get; set; }
        public string? Renk { get; set; }//
        public int MaxFiyat { get; set; }
        public int MinFiyat { get; set; }
        public int MaxModelYil { get; set; }
        public int MinModelYil { get; set; }
        public string? Model { get; set; }
    }
}
