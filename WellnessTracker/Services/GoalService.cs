using Microsoft.EntityFrameworkCore;
using WellnessTracker.Data;
using WellnessTracker.Models;

namespace WellnessTracker.Services
{
    public class GoalService : IGoalService
    {
        private readonly ApplicationDbContext _db;

        public GoalService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Goal>> GetAllAsync(string userId)
        {
            return await _db.Goals
                .Where(g => g.UserId == userId && g.IsActive)
                .OrderByDescending(g => g.CreatedAt)
                .ToListAsync();
        }

        public async Task<Goal?> GetByIdAsync(int id, string userId)
        {
            return await _db.Goals
                .FirstOrDefaultAsync(g => g.Id == id && g.UserId == userId);
        }

        public async Task AddAsync(Goal goal)
        {
            _db.Goals.Add(goal);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Goal goal)
        {
            _db.Goals.Update(goal);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var existing = await GetByIdAsync(id, userId);
            if (existing is not null)
            {
                _db.Goals.Remove(existing);
                await _db.SaveChangesAsync();
            }
        }
    }
}
