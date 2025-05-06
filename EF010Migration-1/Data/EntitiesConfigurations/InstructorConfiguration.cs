using EF010Migration_1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010Migration_1.Data.EntitiesConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(I => I.Id);
        builder.Property(I => I.Id)
            .ValueGeneratedNever();
        
        builder.Property(I => I.Name)
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();
        
        builder.ToTable("Instructors");
        builder.HasData(LoadInstructors());
    }

    private static List<Instructor> LoadInstructors()
    {
        return new List<Instructor>
        {
            new Instructor { Id = 1, Name = "Ahmed Abdullah" },
            new Instructor { Id = 2, Name = "Yasmeen Mohammed" },
            new Instructor { Id = 3, Name = "Khalid Hassan" },
            new Instructor { Id = 4, Name = "Nadia Ali" },
            new Instructor { Id = 5, Name = "Omar Ibrahim" },
        };
    }
}