using Mini_EMR.Models.Medicines;

namespace Mini_EMR.Services.Interfaces
{
    public interface IMedicineService
    {
        Task<List<MedicineModel>> GetAllAsync();
    }
}