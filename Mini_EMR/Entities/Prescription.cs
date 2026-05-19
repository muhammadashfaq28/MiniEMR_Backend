using Mini_EMR.Entities;

public class Prescription
{
    public int Id { get; set; }

    public int VisitId { get; set; }

    public int MedicineId { get; set; }

    public string Dosage { get; set; } = string.Empty;

    public string Frequency { get; set; } = string.Empty;

    public int DurationDays { get; set; }

    public string? Instructions { get; set; }

    public Visit? Visit { get; set; }

    public Medicine? Medicine { get; set; }
}