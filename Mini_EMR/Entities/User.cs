namespace Mini_EMR.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
         public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? Specialization { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Appointment>? DoctorAppointments { get; set; }
        public ICollection<Appointment>? CreatedAppointments { get; set; }

        public ICollection<Appointment>? UpdatedAppointments { get; set; }
        public ICollection<Patient>? CreatedPatients { get; set; }
        public ICollection<Patient>? UpdatedPatients {  get; set; }

    }
}
