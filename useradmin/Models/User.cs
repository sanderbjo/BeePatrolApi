namespace useradmin.Models
{
    public class User
    {
        public long UserId { get; set; }
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public int? UserPhone {  get; set; }
    
    }
}
