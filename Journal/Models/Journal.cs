namespace Journal.Models
{
    public class Journal
    {
        public int JournalId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string? HiveId { get; set; }
        public bool HaveGivenSugar { get; set; } = false;
        public int? ExpandedBox { get; set; }
        public bool AcidTreated { get; set; } = false;
        public bool DroneCutting { get; set; } = false;
        public bool QueenSwapped { get; set; } = false;
        public string? FreeText { get; set; }
        public int? BeeMoodLevel { get; set; }

    }
}
