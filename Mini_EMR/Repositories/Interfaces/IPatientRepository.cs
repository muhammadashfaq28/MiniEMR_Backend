using Mini_EMR.Models.Patients;
using Mini_EMR.Entities;

namespace Mini_EMR.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task CreateAsync(Patient patient);
        Task UpdateAsync (Patient patient);
    }
}
