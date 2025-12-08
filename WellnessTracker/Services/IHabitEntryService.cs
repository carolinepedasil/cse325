using WellnessTracker.Models;

namespace WellnessTracker.Services
{
    public interface IHabitEntryService
    {
        Task<List<HabitEntry>> GetAllAsync(string userId, DateTime? startDate = null, DateTime? endDate = null);
        Task<HabitEntry?> GetByIdAsync(int id, string userId);
        Task AddAsync(HabitEntry entry);
        Task UpdateAsync(HabitEntry entry);
        Task DeleteAsync(int id, string userId);
    }
}
