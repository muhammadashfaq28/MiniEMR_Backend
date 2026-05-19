namespace Mini_EMR.Models.Patients
{
    public class CreatePatientModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string CNIC { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? BloodGroup { get; set; }
        public string? Address { get; set; }

    }
}
