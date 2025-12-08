using WellnessTracker.Models;

namespace WellnessTracker.Services
{
    public interface IGoalService
    {
        Task<List<Goal>> GetAllAsync(string userId);
        Task<Goal?> GetByIdAsync(int id, string userId);
        Task AddAsync(Goal goal);
        Task UpdateAsync(Goal goal);
        Task DeleteAsync(int id, string userId);
    }
}
