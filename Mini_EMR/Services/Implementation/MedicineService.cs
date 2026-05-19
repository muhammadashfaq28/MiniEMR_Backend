using Mini_EMR.Mappings;
using Mini_EMR.Models.Medicines;
using Mini_EMR.Repositories.Interfaces;
using Mini_EMR.Services.Interfaces;

namespace Mini_EMR.Services.Implementation
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repository;

        public MedicineService(
            IMedicineRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MedicineModel>>
            GetAllAsync()
        {
            var medicines =
                await _repository.GetAllAsync();

            return medicines
                .Select(MedicineMapper.ToModel)
                .ToList();
        }
    }
}