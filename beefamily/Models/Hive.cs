namespace beefamily.Models
{
    public class Hive
    {

        public string HiveId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int NumberOfBoxes { get; set; }
        public DateTime? LastJournalNote { get; set; } 
        public string? TodoId { get; set; }
        public bool? CameraIsWorking { get; set;}
        public int? MiteCountMin { get; set; }
        public int? MiteCountMax { get; set; }
    }
}
