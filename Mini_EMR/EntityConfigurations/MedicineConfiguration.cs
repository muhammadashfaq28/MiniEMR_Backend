using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mini_EMR.Entities;

namespace Mini_EMR.EntityConfigurations
{
    public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable("Medicines");

            builder.HasKey("Id");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.GenericName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Strength)
                .IsRequired()
                .HasMaxLength(40);

            builder.HasIndex(x => new { x.Name, x.Strength })
                .IsUnique();
        }
    }
}
