namespace Mini_EMR.Models.Visits
{
    public class VisitResponseModel
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string ChiefComplaint { get; set; } = string.Empty;
        public string VisitNote { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public DateTime VisitDate { get; set; }
        public VitalsResponseModel Vitals { get; set; } = new();
        // Prescriptions


        public List<PrescriptionResponseModel>
            Prescriptions
        { get; set; } = [];
    }
}