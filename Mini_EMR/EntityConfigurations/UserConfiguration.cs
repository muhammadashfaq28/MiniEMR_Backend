using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_EMR.Entities;



namespace Mini_EMR.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder) {

            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Username)
                 .IsRequired()
                 .HasMaxLength(50);

            builder.HasIndex(x => x.Username)
              .IsUnique();

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength (100);

            builder.Property(x => x.Role)
              .IsRequired()
              .HasMaxLength(20);

            builder.Property(x => x.Specialization)
                .HasMaxLength(80);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETDATE()");



            builder.HasMany(x => x.DoctorAppointments)
               .WithOne(x => x.Doctor)
               .HasForeignKey(x => x.DoctorId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.CreatedAppointments)
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.UpdatedAppointments)
                .WithOne(x => x.UpdatedBy)
                .HasForeignKey(x => x.UpdatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.CreatedPatients)
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.UpdatedPatients)
                .WithOne(x => x.UpdatedBy)
                .HasForeignKey(x => x.UpdatedById)
                .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
