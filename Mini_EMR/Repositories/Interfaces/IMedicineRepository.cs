using Mini_EMR.Entities;

namespace Mini_EMR.Repositories.Interfaces
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAllAsync();
    }
}