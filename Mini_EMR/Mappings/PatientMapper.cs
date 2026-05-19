using Mini_EMR.Entities;
using Mini_EMR.Models.Patients;

namespace Mini_EMR.Mappings
{
    public static class PatientMapper
    {
        public static PatientModel ToPatientModel(Patient patient)
        {
            return new PatientModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                CNIC = patient.CNIC,
                PhoneNumber = patient.PhoneNumber,
                BloodGroup = patient.BloodGroup,
                Address = patient.Address,
            };
        }

        public static Patient ToEntity( CreatePatientModel model,int createdById)
        {
            return new Patient
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                CNIC = model.CNIC,
                PhoneNumber = model.PhoneNumber,
                BloodGroup = model.BloodGroup,
                Address = model.Address,
                CreatedById = createdById,
                CreatedAt = DateTime.Now
            };
        }

        public static void UpdateEntity(Patient patient,UpdatePatientModel model,int updatedById)
        {
               patient.FirstName = model.FirstName;
               patient.LastName = model.LastName;
               patient.DateOfBirth = model.DateOfBirth;
               patient.Gender = model.Gender;
               patient.CNIC = model.CNIC;
               patient.PhoneNumber = model.PhoneNumber;
               patient.BloodGroup = model.BloodGroup;
               patient.Address = model.Address;
               patient.UpdatedById = updatedById;
               patient.UpdatedAt = DateTime.Now;
        }
    }

    
}