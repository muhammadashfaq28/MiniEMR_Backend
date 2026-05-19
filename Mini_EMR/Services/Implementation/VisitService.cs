using Microsoft.EntityFrameworkCore;
using Mini_EMR.Data;
using Mini_EMR.Entities;
using Mini_EMR.Mappings;
using Mini_EMR.Models.Visits;
using Mini_EMR.Repositories.Interfaces;
using Mini_EMR.Services.Interfaces;

namespace Mini_EMR.Services.Implementation
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;

        private readonly IAppointmentRepository _appointmentRepository;

        private readonly ApplicationDbContext _context;

        public VisitService(
            IVisitRepository visitRepository,
            IAppointmentRepository appointmentRepository,
            ApplicationDbContext context)
        {
            _visitRepository = visitRepository;
            _appointmentRepository = appointmentRepository;
            _context = context;
        }

        public async Task<VisitResponseModel?>
            GetByAppointmentIdAsync(int appointmentId)
        {
            var visit =
                await _visitRepository.GetByAppointmentIdAsync(appointmentId);

            if (visit == null)
            {
                return null;
            }

            return VisitMapper.ToResponseModel(visit);

        }

        public async Task<VisitResponseModel> CreateVisitAsync(CreateVisitRequestModel model)
        {

            var appointment = await _appointmentRepository.GetByIdAsync(model.AppointmentId);


            if (appointment == null)
            {
                throw new Exception(
                    "Appointment not found.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
              

                var visit = VisitMapper.ToEntity(model);

                visit.Prescriptions =
                    VisitMapper.ToPrescriptionEntities( model.Prescriptions);
         
                await _visitRepository.CreateAsync(visit);

                AppointmentMapper
                    .UpdateForComplete(
                        appointment,
                        appointment.DoctorId);

                await _appointmentRepository
                    .UpdateAsync(appointment);

                await transaction.CommitAsync();

                return VisitMapper.ToResponseModel(visit);
            }
            catch
            {

                await transaction.RollbackAsync();

                throw;
            }
        }
    }
}