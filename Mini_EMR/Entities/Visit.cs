using System.Collections;

namespace Mini_EMR.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string ChiefComplaint { get; set; } = string.Empty;

        public string VisitNote { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public decimal? HeightCm { get; set; }
        public decimal? WeightKg { get; set; } 
        public int? BpSystolic { get; set; } 
        public int? BpDiastolic { get; set; }
        public int? PulseBpm { get; set; }
        public decimal? TemperatureC { get; set; }
        public int? RespiratoryRate { get; set; }
        public decimal? BMI {  get; set; }
        public DateTime VisitDate { get; set; }

        public Appointment? Appointment { get; set; }
        public ICollection<Prescription>? Prescriptions { get; set; }

    }
}
