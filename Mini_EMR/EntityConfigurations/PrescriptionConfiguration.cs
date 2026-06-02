using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_EMR.Entities;

namespace Mini_EMR.EntityConfigurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure (EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.VisitId)
                .IsRequired();

            builder.Property(x => x.MedicineId)
                .IsRequired();

            builder.Property(x => x.Dosage)
                .IsRequired();

            builder.Property(x => x.Frequency)
                .IsRequired();

            builder.Property(x => x.DurationDays)
                .IsRequired();

            builder.Property(x => x.Instructions)
                .HasMaxLength(255);


            builder.HasOne(x => x.Visit)
                .WithMany(x => x.Prescriptions)
                .HasForeignKey(x => x.VisitId);


            builder.HasOne(x => x.Medicine)
               .WithMany(x => x.Prescriptions)
               .HasForeignKey(x => x.MedicineId)
               .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
