using Mini_EMR.Models.Appointments;

namespace Mini_EMR.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<AppointmentListModel>> GetAppointmentsByDateAsync(DateTime date, string? status);
        Task<List<DoctorAppointmentModel>> GetDoctorTodayAppointmentsAsync(int doctorId,DateTime date);
        Task<AppointmentModel?> GetAppointmentByIdAsync(int id);
        Task<AppointmentModel> BookAppointmentAsync(CreateAppointmentModel model, int createdById);
        Task<bool> CheckInAppointmentAsync(int id, int updatedById);
        Task<bool> CancelAppointmentAsync(int id, int updatedById);
        Task<AppointmentStatusCountsModel> GetStatusCountsByDateAsync(DateTime date);
    }
}
