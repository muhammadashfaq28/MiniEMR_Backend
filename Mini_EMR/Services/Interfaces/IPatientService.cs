using Mini_EMR.Models.Patients;

namespace Mini_EMR.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientModel>> GetAllPatientsAsync();
        Task<PatientModel?> GetPatientByIdAsync(int id); 
        Task<PatientModel> CreatePatientAsync(CreatePatientModel patient, int CreatedById);
        Task<bool> UpdatePatientAsync(int id, UpdatePatientModel patient, int UpdatedById);
    }
}
