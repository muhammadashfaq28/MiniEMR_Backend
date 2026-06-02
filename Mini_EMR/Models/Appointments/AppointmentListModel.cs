namespace Mini_EMR.Models.Appointments
{
    public class AppointmentListModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string DoctorName { get; set; } = string.Empty;

        public DateTime AppointmentDateTime { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}