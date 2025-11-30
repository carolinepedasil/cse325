using WellnessTracker.Models;

namespace WellnessTracker.Services
{
    public class InMemoryHabitEntryService : IHabitEntryService
    {
        private readonly List<HabitEntry> _entries = new();
        private int _nextId = 1;

        public Task<List<HabitEntry>> GetAllAsync()
        {
            var result = _entries
                .OrderByDescending(e => e.Date)
                .ToList();

            return Task.FromResult(result);
        }

        public Task<HabitEntry?> GetByIdAsync(int id)
        {
            var entry = _entries.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(entry);
        }

        public Task AddAsync(HabitEntry entry)
        {
            entry.Id = _nextId++;
            _entries.Add(entry);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(HabitEntry entry)
        {
            var existing = _entries.FirstOrDefault(e => e.Id == entry.Id);
            if (existing is null) return Task.CompletedTask;

            existing.Date = entry.Date;
            existing.ExerciseMinutes = entry.ExerciseMinutes;
            existing.SleepHours = entry.SleepHours;
            existing.WaterLiters = entry.WaterLiters;
            existing.Mood = entry.Mood;
            existing.Notes = entry.Notes;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var existing = _entries.FirstOrDefault(e => e.Id == id);
            if (existing != null)
            {
                _entries.Remove(existing);
            }
            return Task.CompletedTask;
        }
    }
}
