using WellnessTracker.Models;

namespace WellnessTracker.Services
{
    public interface IHabitEntryService
    {
        Task<List<HabitEntry>> GetAllAsync();
        Task AddAsync(HabitEntry entry);
    }
}
