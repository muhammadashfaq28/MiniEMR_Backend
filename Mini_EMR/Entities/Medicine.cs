namespace Mini_EMR.Entities
{
    public class Medicine
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string GenericName { get; set; } = string.Empty;

        public string Strength { get; set; } = string.Empty;


        public ICollection<Prescription>? Prescriptions { get; set; } 
    }
}
