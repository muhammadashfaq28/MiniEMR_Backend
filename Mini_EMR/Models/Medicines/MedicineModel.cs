namespace Mini_EMR.Models.Medicines
{
    public class MedicineModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GenericName { get; set; } = string.Empty;
        public string Strength { get; set; } = string.Empty;
    }
}