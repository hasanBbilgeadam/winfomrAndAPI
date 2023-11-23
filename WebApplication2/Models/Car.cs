namespace WebApplication2.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Renk { get; set; }
        public int Fiyat { get; set; }
        public int ModelYil { get; set; }
        public string Model { get; set; } 

    }
    public class AppLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
        public DateTime LogTime { get; set; }
    }
}
