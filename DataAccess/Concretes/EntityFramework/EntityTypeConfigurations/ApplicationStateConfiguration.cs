using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class ApplicationStateConfiguration : IEntityTypeConfiguration<ApplicationState>
{
    public void Configure(EntityTypeBuilder<ApplicationState> builder)
    {
        builder.ToTable("ApplicationStates").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
        builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");
        builder.Property(x => x.DeleteDate).HasColumnName("DeleteDate");
        builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted");
    }
}
