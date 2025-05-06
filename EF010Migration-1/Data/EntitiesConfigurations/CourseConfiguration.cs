using System.Runtime.Intrinsics.X86;
using EF010Migration_1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010Migration_1.Data.EntitiesConfigurations;

public class CourseConfiguration: IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever();
        
        builder.Property(c => c.CourseName)
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(C => C.Price)
            .HasPrecision(15, 2);
        
        builder.ToTable("Courses");
        builder.HasData(LoadCourses());
    }

    private static List<Course> LoadCourses()
    {
        return
        [
            new Course { Id = 1, CourseName = "Mathematics", Price = 1000m },
            new Course { Id = 2, CourseName = "Physics", Price = 2000m },
            new Course { Id = 3, CourseName = "Chemistry", Price = 1500m },
            new Course { Id = 4, CourseName = "Biology", Price = 1200m },
            new Course { Id = 5, CourseName = "CS-50", Price = 3000m }
        ];
    }
}