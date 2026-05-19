namespace Mini_EMR.Models.Appointments
{
    public class AppointmentStatusCountsModel
    {
        public int Total { get; set; }

        public int Booked { get; set; }

        public int CheckedIn { get; set; }

        public int Completed { get; set; }

        public int Cancelled { get; set; }
    }
}