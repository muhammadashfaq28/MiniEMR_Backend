using Microsoft.EntityFrameworkCore;
using Mini_EMR.Data;
using Mini_EMR.Entities;
using Mini_EMR.Enums;
using Mini_EMR.Repositories.Interfaces;

namespace Mini_EMR.Repositories.Implementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Appointment>> GetAppointmentsByDateAsync(DateTime? date,string? status)
        {
            IQueryable<Appointment> query =
                _context.Appointments;

            if (date.HasValue)
            {
                query = query.Where(a =>
                    a.AppointmentDateTime.Date
                    == date.Value.Date);
            }
            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<AppointmentStatus>(
                    status,
                    true,
                    out var parsedStatus))
                {
                    query = query.Where(a =>
                        a.Status == parsedStatus);
                }
            }
            return await query
                .OrderByDescending(a =>
                    a.AppointmentDateTime)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Appointment>> GetDoctorTodayAppointmentsAsync(int doctorId, DateTime date)
        {
            return await _context.Appointments
                .Where(a =>
                    a.DoctorId == doctorId &&
                    a.AppointmentDateTime.Date == date.Date)
                .OrderBy(a => a.AppointmentDateTime)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task CreateAsync(Appointment appointment)
        {
            await _context.Appointments
                .AddAsync(appointment);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments
                .Update(appointment);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsConflictAsync(int doctorId, DateTime appointmentDateTime)
        {
            return await _context.Appointments
                .AnyAsync(a =>
                    a.DoctorId == doctorId &&
                    a.AppointmentDateTime == appointmentDateTime &&
                    a.Status != AppointmentStatus.Cancelled);
        }


        public async Task<
    (int Total,
     int Booked,
     int CheckedIn,
     int Completed,
     int Cancelled)>
    GetStatusCountsByDateAsync(DateTime? date)
        {
            IQueryable<Appointment> query =
                _context.Appointments;

            if (date.HasValue)
            {
                query = query.Where(a =>
                    a.AppointmentDateTime.Date
                    == date.Value.Date);
            }

            var appointments =
                await query
                    .AsNoTracking()
                    .ToListAsync();

            return
            (
                Total: appointments.Count,

                Booked: appointments.Count(a =>
                    a.Status == AppointmentStatus.Booked),

                CheckedIn: appointments.Count(a =>
                    a.Status == AppointmentStatus.CheckedIn),

                Completed: appointments.Count(a =>
                    a.Status == AppointmentStatus.Completed),

                Cancelled: appointments.Count(a =>
                    a.Status == AppointmentStatus.Cancelled)
            );
        }
    }
}
