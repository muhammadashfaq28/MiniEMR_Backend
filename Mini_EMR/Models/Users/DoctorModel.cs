namespace Mini_EMR.Models.Users
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Specialization { get; set; }
    }
}
