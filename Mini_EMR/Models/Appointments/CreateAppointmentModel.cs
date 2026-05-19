namespace Mini_EMR.Models.Appointments
{
    public class CreateAppointmentModel
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string? Notes { get; set; }
    }
}