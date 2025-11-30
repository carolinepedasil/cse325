using WellnessTracker.Models;

namespace WellnessTracker.Services
{
    public interface IHabitEntryService
    {
        Task<List<HabitEntry>> GetAllAsync();
        Task<HabitEntry?> GetByIdAsync(int id);
        Task AddAsync(HabitEntry entry);
        Task UpdateAsync(HabitEntry entry);
        Task DeleteAsync(int id);
    }
}
