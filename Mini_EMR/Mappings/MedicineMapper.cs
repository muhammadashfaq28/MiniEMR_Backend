using Mini_EMR.Entities;
using Mini_EMR.Models.Medicines;

namespace Mini_EMR.Mappings
{
    public static class MedicineMapper
    {
        public static MedicineModel ToModel(
            Medicine medicine)
        {
            return new MedicineModel
            {
                Id = medicine.Id,
                Name = medicine.Name,
                GenericName = medicine.GenericName,
                Strength = medicine.Strength
            };
        }
    }
}