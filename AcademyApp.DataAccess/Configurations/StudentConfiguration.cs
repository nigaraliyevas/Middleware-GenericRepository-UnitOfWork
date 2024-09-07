using AcademyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyApp.DataAccess.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(g => g.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(g => g.FileName).IsRequired(true);
            builder.Property(g => g.Email).IsRequired(true).HasMaxLength(100);
            builder
                .HasOne(s => s.Group)
                .WithMany()
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
