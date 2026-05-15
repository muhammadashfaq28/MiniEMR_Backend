namespace Mini_EMR.Entities
{
        public class Patient
        {
            public int Id { get; set; }

            public string FirstName { get; set; } = string.Empty;

            public string LastName { get; set; } = string.Empty;

            public DateTime DateOfBirth { get; set; }

            public string Gender { get; set; } = string.Empty;

            public string CNIC { get; set; } = string.Empty;

            public string PhoneNumber { get; set; } = string.Empty;

            public string? BloodGroup { get; set; }

            public string? Address { get; set; }

            public int CreatedById { get; set; }

            public int? UpdatedById { get; set; }

            public DateTime CreatedAt { get; set; }

            public DateTime? UpdatedAt { get; set; }




            public User? CreatedBy { get; set; }

            public User? UpdatedBy { get; set; }

            public ICollection<Appointment>? Appointments { get; set; }
        }
}
