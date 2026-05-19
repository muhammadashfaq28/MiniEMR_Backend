using Mini_EMR.Models.Visits;

namespace Mini_EMR.Services.Interfaces
{
    public interface IVisitService
    {
        Task<VisitResponseModel?> GetByAppointmentIdAsync(int appointmentId);
        Task<VisitResponseModel> CreateVisitAsync(CreateVisitRequestModel model);
    }
}