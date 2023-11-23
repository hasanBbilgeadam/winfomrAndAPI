namespace WebApplication2.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public int Limit { get; set; } = 100;
        public DateTime? EndDate { get; set; }
    }
}
