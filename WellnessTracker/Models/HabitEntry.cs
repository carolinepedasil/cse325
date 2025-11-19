namespace WellnessTracker.Models
{
    public class HabitEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ExerciseMinutes { get; set; }
        public double SleepHours { get; set; }
        public double WaterLiters { get; set; }
        public string Mood { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
