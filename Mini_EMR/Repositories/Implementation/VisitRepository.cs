using Microsoft.EntityFrameworkCore;
using Mini_EMR.Data;
using Mini_EMR.Entities;
using Mini_EMR.Repositories.Interfaces;

namespace Mini_EMR.Repositories.Implementation
{
    public class VisitRepository : IVisitRepository
    {
        private readonly ApplicationDbContext _context;

        public VisitRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Visit?> GetByAppointmentIdAsync(
             int appointmentId)
        {
            return await _context.Visits
                .Include(v => v.Prescriptions!)
                .ThenInclude(p => p.Medicine)
                .FirstOrDefaultAsync(v =>
                    v.AppointmentId == appointmentId);
        }
        public async Task CreateAsync(Visit visit)
        {
            await _context.Visits.AddAsync(visit);

            await _context.SaveChangesAsync();
        }
    }
}