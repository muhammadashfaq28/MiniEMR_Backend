namespace Mini_EMR.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Notes { get; set; } 
        public int CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Patient? Patient { get; set; }
        public User? Doctor { get; set; }
        public User? CreatedBy { get; set; }
        public User? UpdatedBy { get; set; }
        public Visit? Visit { get; set; }
    }
}
