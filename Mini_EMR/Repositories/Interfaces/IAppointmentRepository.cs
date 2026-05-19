using Mini_EMR.Entities;

namespace Mini_EMR.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointmentsByDateAsync(DateTime date, string? Status);
        Task<List<Appointment>> GetDoctorTodayAppointmentsAsync(int doctorId , DateTime date);
        Task<Appointment?> GetByIdAsync(int id);
        Task CreateAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task<bool> ExistsConflictAsync(int doctorId, DateTime appointmentDateTime);


        Task<(int Total,
              int Booked,
              int CheckedIn,
              int Completed,
              int Cancelled)>
        GetStatusCountsByDateAsync(DateTime date);

        //Task<int> GetTotalCountAsync(DateTime date);
        //Task<int> GetBookedCountAsync(DateTime date);
        //Task<int> GetCheckedInCountAsync(DateTime date);
        //Task<int> GetCompletedCountAsync(DateTime date);
        //Task<int> GetCancelledCountAsync(DateTime date);


    }
}
