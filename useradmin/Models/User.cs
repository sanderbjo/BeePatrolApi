namespace useradmin.Models
{
    public class User
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int? Tlf {  get; set; }
    
    }
}
