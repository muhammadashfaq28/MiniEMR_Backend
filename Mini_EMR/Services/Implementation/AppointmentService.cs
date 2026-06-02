using Mini_EMR.Mappings;
using Mini_EMR.Models.Appointments;
using Mini_EMR.Repositories.Implementation;
using Mini_EMR.Repositories.Interfaces;
using Mini_EMR.Services.Interfaces;

namespace Mini_EMR.Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAuthRepository _authRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository,
            IPatientRepository patientRepository,
            IAuthRepository authRepository)
        {
            _appointmentRepository = appointmentRepository;  
            _patientRepository = patientRepository;
            _authRepository = authRepository;
        }


        public async Task<List<AppointmentListModel>> GetAppointmentsByDateAsync(DateTime? date,string? status)
        {
            var appointments =
                await _appointmentRepository
                    .GetAppointmentsByDateAsync(
                        date,
                        status);

            var patients = await _patientRepository.GetAllAsync();

            var doctors =  await _authRepository.GetDoctorsAsync();

            var patientDict = patients.ToDictionary(p => p.Id);

            var doctorDict = doctors.ToDictionary(d => d.Id);

            return AppointmentMapper.ToListModelList(
                appointments,
                patientDict,
                doctorDict);
        }

        public async Task<List<DoctorAppointmentModel>> GetDoctorTodayAppointmentsAsync(int doctorId, DateTime date)
        {
            var appointments = await _appointmentRepository
                    .GetDoctorTodayAppointmentsAsync(
                        doctorId,
                        DateTime.Today);

            var patients =await _patientRepository.GetAllAsync();

            var patientDict = patients.ToDictionary(p => p.Id);

            return AppointmentMapper
                .ToDoctorAppointmentModelList(
                    appointments,
                    patientDict);
        }

        public async Task<AppointmentModel?>GetAppointmentByIdAsync(int id)
        {
            var appointment =await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                return null;
            }

            var patient = await _patientRepository.GetByIdAsync(appointment.PatientId);

            var doctor = await _authRepository.GetByIdAsync(appointment.DoctorId);

            if (patient == null || doctor == null)
            {
                return null;
            }

            return AppointmentMapper
                .ToAppointmentModel(
                    appointment,
                    patient,
                    doctor);
        }

        public async Task<AppointmentModel> BookAppointmentAsync(CreateAppointmentModel model,int createdById)
        {
            var isConflict =
                await _appointmentRepository
                    .ExistsConflictAsync(
                        model.DoctorId,
                        model.AppointmentDateTime);

            if (isConflict)
            {
                throw new Exception(
                    "Doctor already has an appointment at this time.");
            }

            var appointment =
                AppointmentMapper.ToEntity(model,createdById);

            await _appointmentRepository.CreateAsync(appointment);

            var patient = await _patientRepository.GetByIdAsync(appointment.PatientId);

            var doctor = await _authRepository.GetByIdAsync(appointment.DoctorId);

            return AppointmentMapper
                .ToAppointmentModel(
                    appointment,
                    patient!,
                    doctor!);
        }

        public async Task<bool> CheckInAppointmentAsync(int id,int updatedById)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                return false;
            }

            AppointmentMapper.UpdateForCheckIn(appointment,updatedById);

            await _appointmentRepository.UpdateAsync(appointment);

            return true;
        }

        public async Task<bool> CancelAppointmentAsync(int id,int updatedById)
        {
            var appointment =
                await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                return false;
            }

            AppointmentMapper.UpdateForCancel(appointment,updatedById);

            await _appointmentRepository.UpdateAsync(appointment);

            return true;
        }


        public async Task<AppointmentStatusCountsModel> GetStatusCountsByDateAsync(DateTime? date)
        {
            var counts =
                await _appointmentRepository.GetStatusCountsByDateAsync(date);

            return AppointmentMapper
                .ToStatusCountsModel(
                    counts.Total,
                    counts.Booked,
                    counts.CheckedIn,
                    counts.Completed,
                    counts.Cancelled);
        }








    }
}
