using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_EMR.Entities;

namespace Mini_EMR.EntityConfigurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.PatientId)
                .IsRequired();

            builder.Property(x => x.DoctorId)
                .IsRequired();

            builder.Property(x => x.AppointmentDateTime)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Notes)
                .HasMaxLength(500);

            builder.Property(x => x.CreatedById)
                .IsRequired();

            builder.Property(x => x.UpdatedById);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UpdatedAt);



            builder.HasIndex(x => new
            {
                x.DoctorId,
                x.AppointmentDateTime
            })
            .IsUnique();


            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.DoctorAppointments)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.CreatedAppointments)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.UpdatedBy)
                .WithMany(x => x.UpdatedAppointments)
                .HasForeignKey(x => x.UpdatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Visit)
                .WithOne(x => x.Appointment)
                .HasForeignKey<Visit>(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
