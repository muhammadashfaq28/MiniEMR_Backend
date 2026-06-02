using Mini_EMR.Entities;
using Mini_EMR.Enums;
using Mini_EMR.Models.Appointments;

namespace Mini_EMR.Mappings
{
    // For Dashboard Appointment List 
    public static class AppointmentMapper
    {
        public static AppointmentListModel ToListModel(Appointment appointment, Patient patient, User doctor)
        {
            return new AppointmentListModel
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                PatientName = $"{patient.FirstName} {patient.LastName}",
                Age = CalculateAge(patient.DateOfBirth),
                Gender = patient.Gender,
                DoctorName = doctor.FullName,
                AppointmentDateTime = appointment.AppointmentDateTime,
                Status = appointment.Status.ToString()
            };
        }

        // For All Appointment Entity to Model 
        public static AppointmentModel ToAppointmentModel(Appointment appointment, Patient patient, User doctor)
        {
            return new AppointmentModel
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                PatientName = $"{patient.FirstName} {patient.LastName}",
                DoctorId = appointment.DoctorId,
                DoctorName = doctor.FullName,
                AppointmentDateTime = appointment.AppointmentDateTime,
                Status = appointment.Status.ToString(),
                Notes = appointment.Notes
            };
        }

        // For Doctor Today Appointments
        public static DoctorAppointmentModel ToDoctorAppointmentModel(Appointment appointment, Patient patient)
        {
            return new DoctorAppointmentModel
            {
                Id = appointment.Id,
                PatientName = $"{patient.FirstName} {patient.LastName}",
                AppointmentDateTime = appointment.AppointmentDateTime, 
                Status = appointment.Status.ToString()
            };
        }

        // For Status Count 
        public static AppointmentStatusCountsModel ToStatusCountsModel(
           int total, int booked, int checkedIn, int completed, int cancelled)
        {
            return new AppointmentStatusCountsModel
            {
                Total = total,
                Booked = booked,
                CheckedIn = checkedIn,
                Completed = completed,
                Cancelled = cancelled
            };
        }

        // For New Appointment 
        public static Appointment ToEntity(CreateAppointmentModel model, int createdById)
        {
            return new Appointment
            {
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                AppointmentDateTime = model.AppointmentDateTime,
                Status = AppointmentStatus.Booked,
                Notes = model.Notes,
                CreatedById = createdById,
                CreatedAt = DateTime.Now,
            };
        }


        // Check In Appointment
        public static void UpdateForCheckIn(Appointment appointment,int updatedById)
        {
            appointment.Status = AppointmentStatus.CheckedIn;

            appointment.UpdatedById = updatedById;

            appointment.UpdatedAt = DateTime.Now;
        }


        // For Status Complete Appointment
        public static void UpdateForComplete( Appointment appointment, int updatedById)
        {
            appointment.Status = AppointmentStatus.Completed;

            appointment.UpdatedById = updatedById;

            appointment.UpdatedAt = DateTime.Now;
        }

        public static void UpdateForCancel(Appointment appointment,int updatedById)
        {
            appointment.Status = AppointmentStatus.Cancelled;

            appointment.UpdatedById = updatedById;

            appointment.UpdatedAt = DateTime.Now;
        }


        // Dashboard Appointment List

        public static List<AppointmentListModel>
           ToListModelList(
               List<Appointment> appointments,
               Dictionary<int, Patient> patientDict,
               Dictionary<int, User> doctorDict)
        {
            var result = new List<AppointmentListModel>();

            foreach (var appointment in appointments)
            {
                var patient = patientDict.GetValueOrDefault(appointment.PatientId);

                var doctor = doctorDict.GetValueOrDefault(appointment.DoctorId);

                if (patient != null && doctor != null)
                {
                    result.Add(
                        ToListModel
                        (
                            appointment,
                            patient,
                            doctor)
                        );
                }
            }

            return result;
        }

        // Doctor Today's Appointments
        public static List<DoctorAppointmentModel>
            ToDoctorAppointmentModelList
            (
                List<Appointment> appointments,
                Dictionary<int, Patient> patientDict
            )
        {
            var result = new List<DoctorAppointmentModel>();

            foreach (var appointment in appointments)
            {
                var patient = patientDict.GetValueOrDefault(appointment.PatientId);

                if (patient != null)
                {
                    result.Add(ToDoctorAppointmentModel
                        (
                            appointment,
                            patient
                        ));
                }
            }

            return result;
        }


        private static int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }


    }
}
