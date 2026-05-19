namespace Mini_EMR.Models.Visits
{
    public class CreateVisitRequestModel
    {
        public int AppointmentId { get; set; }
        public string ChiefComplaint { get; set; } = string.Empty;
        public string VisitNote { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;

        // Vitals

        public decimal? HeightCm { get; set; }
        public decimal? WeightKg { get; set; }
        public int? BpSystolic { get; set; }
        public int? BpDiastolic { get; set; }
        public int? PulseBpm { get; set; }
        public decimal? TemperatureC { get; set; }
        public int? RespiratoryRate { get; set; }
        public decimal? BMI { get; set; }
        // Prescriptions
        public List<PrescriptionRequestModel>
            Prescriptions
        { get; set; } = [];
    }
}