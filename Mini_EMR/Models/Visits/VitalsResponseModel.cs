namespace Mini_EMR.Models.Visits
{
    public class VitalsResponseModel
    {
        public decimal? HeightCm { get; set; }
        public decimal? WeightKg { get; set; }
        public decimal? BpSystolic { get; set; }
        public decimal? BpDiastolic { get; set; }
        public decimal? PulseBpm { get; set; }
        public decimal? TemperatureF { get; set; }
        public decimal? RespiratoryRate { get; set; }
        public decimal? BMI {  get; set; }
    }
}