using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_EMR.Entities;

namespace Mini_EMR.EntityConfigurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.CNIC)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasIndex(x => x.CNIC)
                .IsUnique();

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.BloodGroup)
                .HasMaxLength(5);

            builder.Property(x => x.Address)
                .HasMaxLength(255);

            builder.Property(x => x.CreatedById)
                .IsRequired();

            builder.Property(x => x.UpdatedById);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UpdatedAt);


            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.CreatedPatients)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.UpdatedBy)
                .WithMany(x => x.UpdatedPatients)
                .HasForeignKey(x => x.UpdatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Appointments)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
