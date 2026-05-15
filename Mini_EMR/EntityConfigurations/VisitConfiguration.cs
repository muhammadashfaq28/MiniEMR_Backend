using Microsoft.EntityFrameworkCore;
using Mini_EMR.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mini_EMR.EntityConfigurations
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.ToTable("Visits");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.AppointmentId)
                .IsRequired();

            builder.Property(x => x.ChiefComplaint)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.VisitNote)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.Diagnosis)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.HeightCm)
                .HasColumnType("decimal(5,2)");

            builder.Property(x => x.WeightKg)
                .HasColumnType("decimal(5,2)");

            builder.Property(x => x.BpSystolic);

            builder.Property(x => x.BpDiastolic);

            builder.Property(x => x.PulseBpm);

            builder.Property(x => x.TemperatureC)
                .HasColumnType("decimal(4,1)");

            builder.Property(x => x.RespiratoryRate);

            builder.Property(x => x.BMI)
                .HasColumnType("decimal(4,2)");

            builder.Property(x => x.VisitDate)
                .HasDefaultValueSql("GETDATE()");



            builder.HasOne(x => x.Appointment)
               .WithOne(x => x.Visit)
               .HasForeignKey<Visit>(x => x.AppointmentId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Prescriptions)
                .WithOne(x => x.Visit)
                .HasForeignKey(x => x.VisitId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
