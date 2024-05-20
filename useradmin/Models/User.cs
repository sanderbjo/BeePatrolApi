namespace useradmin.Models
{
    public class User
    {
        public string UserId { get; set; }
        public required string UserName { get; set; }
        public string Password { get; set; }
        public required string UserEmail { get; set; }
        public int? UserPhone {  get; set; }
    
    }
}
