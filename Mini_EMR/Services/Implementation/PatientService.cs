using Mini_EMR.Mappings;
using Mini_EMR.Models.Patients;
using Mini_EMR.Models.Visits;
using Mini_EMR.Repositories.Implementation;
using Mini_EMR.Repositories.Interfaces;
using Mini_EMR.Services.Interfaces;

namespace Mini_EMR.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        public PatientService(IPatientRepository repository) {
            _repository = repository;
        }

        public async Task<List<PatientModel>> GetAllPatientsAsync()
        {
            var patients = await _repository.GetAllAsync();

            return patients
                .Select(PatientMapper.ToPatientModel)
                .ToList();
        }

        public async Task<PatientModel?> GetPatientByIdAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient == null)
            {
                return null;
            }

            return PatientMapper.ToPatientModel(patient);
        }

        public async Task<PatientModel> CreatePatientAsync(CreatePatientModel model, int CreatedById)
        {
            var patient = PatientMapper.ToEntity(model, CreatedById);
            await _repository.CreateAsync(patient);
            return PatientMapper.ToPatientModel(patient) ;
        }

        public async Task<bool> UpdatePatientAsync(int id, UpdatePatientModel model, int UpdatedById)
        {
            var patient = await _repository.GetByIdAsync(id);
            if(patient == null)
            {
                return false;
            }

            PatientMapper.UpdateEntity(patient, model, UpdatedById);
            await _repository.UpdateAsync(patient);
            return true;
        }
        public async Task<List<VisitResponseModel>> GetVisitsByPatientIdAsync(int patientId)
        {
            var visits = await _repository.GetVisitsByPatientIdAsync(patientId);
            return visits.Select(VisitMapper.ToResponseModel).ToList();
        }


    }
}
