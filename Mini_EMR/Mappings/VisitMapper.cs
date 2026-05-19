using Mini_EMR.Entities;
using Mini_EMR.Models.Visits;

namespace Mini_EMR.Mappings
{
    public static class VisitMapper
    {
        //  CREATE VISIT ENTITY

        public static Visit ToEntity(
            CreateVisitRequestModel model)
        {
            return new Visit
            {
                AppointmentId = model.AppointmentId,

                ChiefComplaint = model.ChiefComplaint,

                VisitNote = model.VisitNote,

                Diagnosis = model.Diagnosis,

                HeightCm = model.HeightCm,

                WeightKg = model.WeightKg,

                BpSystolic = model.BpSystolic,

                BpDiastolic = model.BpDiastolic,

                PulseBpm = model.PulseBpm,

                TemperatureC = model.TemperatureC,

                RespiratoryRate = model.RespiratoryRate,

                BMI = model.BMI,

                VisitDate = DateTime.Now
            };
        }

        // CREATE PRESCRIPTIONS

        public static List<Prescription>
            ToPrescriptionEntities(
                List<PrescriptionRequestModel> models)
        {
            return models.Select(model =>
                new Prescription
                {
                    MedicineId = model.MedicineId,

                    Dosage = model.Dosage,

                    Frequency = model.Frequency,

                    DurationDays = model.DurationDays,

                    Instructions = model.Instructions
                })
                .ToList();
        }

        //  RESPONSE MODEL 

        public static VisitResponseModel
            ToResponseModel(Visit visit)
        {
            return new VisitResponseModel
            {
                Id = visit.Id,

                AppointmentId = visit.AppointmentId,

                ChiefComplaint = visit.ChiefComplaint,

                VisitNote = visit.VisitNote,

                Diagnosis = visit.Diagnosis,

                HeightCm = visit.HeightCm,

                WeightKg = visit.WeightKg,

                BpSystolic = visit.BpSystolic,

                BpDiastolic = visit.BpDiastolic,

                PulseBpm = visit.PulseBpm,

                TemperatureC = visit.TemperatureC,

                RespiratoryRate = visit.RespiratoryRate,

                BMI = visit.BMI,

                VisitDate = visit.VisitDate,

                Prescriptions =
                    visit.Prescriptions?
                        .Select(p =>
                            new PrescriptionResponseModel
                            {
                                Id = p.Id,

                                MedicineId = p.MedicineId,

                                Dosage = p.Dosage,

                                Frequency = p.Frequency,

                                DurationDays = p.DurationDays,

                                Instructions = p.Instructions,

                                MedicineName =
                                    p.Medicine?.Name
                                    ?? string.Empty,

                                Strength =
                                    p.Medicine?.Strength
                                    ?? string.Empty
                            })
                        .ToList()

                    ?? []
            };
        }
    }
}