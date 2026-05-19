namespace Mini_EMR.Models.Appointments
{
    public class AppointmentModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public int DoctorId { get; set; }

        public string DoctorName { get; set; } = string.Empty;

        public DateTime AppointmentDateTime { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Notes { get; set; }
    }
}