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

        public Task AddAsync(HabitEntry entry)
        {
            entry.Id = _nextId++;
            _entries.Add(entry);
            return Task.CompletedTask;
        }
    }
}
