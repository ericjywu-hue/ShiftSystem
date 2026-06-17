namespace ShiftSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }

        public override string ToString() => Name;
    }
}
