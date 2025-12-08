using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WellnessTracker.Models
{
    public class HabitEntry
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser? User { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Range(0, 600)]
        public int ExerciseMinutes { get; set; }

        [Range(0, 24)]
        public double SleepHours { get; set; }

        [Range(0, 20)]
        public double WaterLiters { get; set; }

        [MaxLength(100)]
        public string Mood { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}
