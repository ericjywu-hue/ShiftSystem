namespace ShiftSystem.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public override string ToString() => $"{Name} ({StartTime}~{EndTime})";
    }
}
