using Mini_EMR.Entities;

namespace Mini_EMR.Repositories.Interfaces
{
    public interface IVisitRepository
    {
        Task<Visit?> GetByAppointmentIdAsync(
            int appointmentId);

        Task CreateAsync(Visit visit);
    }
}