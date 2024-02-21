using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class BootcampStateConfiguration : IEntityTypeConfiguration<BootcampState>
{
    public void Configure(EntityTypeBuilder<BootcampState> builder)
    {
        builder.ToTable("BootcampStates").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
        builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");
        builder.Property(x => x.DeleteDate).HasColumnName("DeleteDate");
        builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted");
    }
}
