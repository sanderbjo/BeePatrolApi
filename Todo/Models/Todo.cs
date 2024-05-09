namespace Todo.Models
{
    public class Todo
    {
        public int TodoId { get; set; }
        public int UserId { get; set; }
        public int HiveId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; } 
        public string Title { get; set; }
        public string Freetext { get; set; }
        public bool Done { get; set; }
        public bool SmsReminder { get; set; }
        public bool EmailReminder { get; set; }
        public bool PushReminder { get; set; }
    
    }
}
