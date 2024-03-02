using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
{
    public void Configure(EntityTypeBuilder<Bootcamp> builder)
    {
        builder.ToTable("Bootcamps").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.InstructorId).HasColumnName("InstructorId").IsRequired();
        builder.Property(x => x.BootcampStateId).HasColumnName("BootcampStateId").IsRequired();
        builder.Property(x => x.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(x => x.EndDate).HasColumnName("EndDate").IsRequired();

        builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
        builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");
        builder.Property(x => x.DeleteDate).HasColumnName("DeleteDate");
        builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted");

        builder.HasOne(b => b.Instructor);
        builder.HasOne(p => p.BootcampState);
        builder.HasMany(p => p.Applications);
        //builder.HasMany(x => x.Images);

    }
}
