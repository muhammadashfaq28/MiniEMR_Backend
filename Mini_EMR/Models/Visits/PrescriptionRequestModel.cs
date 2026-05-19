namespace Mini_EMR.Models.Visits
{
    public class PrescriptionRequestModel
    {
        public int MedicineId { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public int DurationDays { get; set; }
        public string? Instructions { get; set; }
    }
}