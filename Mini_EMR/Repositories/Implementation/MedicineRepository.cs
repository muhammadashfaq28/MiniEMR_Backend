using Microsoft.EntityFrameworkCore;
using Mini_EMR.Data;
using Mini_EMR.Entities;
using Mini_EMR.Repositories.Interfaces;

namespace Mini_EMR.Repositories.Implementation
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicineRepository(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Medicine>> GetAllAsync()
        {
            return await _context.Medicines
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}