using Microsoft.EntityFrameworkCore;
using WellnessTracker.Data;
using WellnessTracker.Models;

namespace WellnessTracker.Services
{
    public class HabitEntryService : IHabitEntryService
    {
        private readonly ApplicationDbContext _db;

        public HabitEntryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<HabitEntry>> GetAllAsync(string userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _db.HabitEntries
                .Where(e => e.UserId == userId);

            if (startDate.HasValue)
            {
                query = query.Where(e => e.Date >= startDate.Value.Date);
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.Date <= endDate.Value.Date);
            }

            return await query
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }

        public async Task<HabitEntry?> GetByIdAsync(int id, string userId)
        {
            return await _db.HabitEntries
                .FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId);
        }

        public async Task AddAsync(HabitEntry entry)
        {
            _db.HabitEntries.Add(entry);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(HabitEntry entry)
        {
            _db.HabitEntries.Update(entry);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var existing = await GetByIdAsync(id, userId);
            if (existing is not null)
            {
                _db.HabitEntries.Remove(existing);
                await _db.SaveChangesAsync();
            }
        }
    }
}
