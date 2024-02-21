using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.ApplicantId).HasColumnName("ApplicantId").IsRequired();
        builder.Property(x => x.ApplicationStateId).HasColumnName("ApplicationStateId").IsRequired();
        builder.Property(x => x.BootcampId).HasColumnName("BootcampId").IsRequired();
        builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
        builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");
        builder.Property(x => x.DeleteDate).HasColumnName("DeleteDate");
        builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted");

        //builder.HasOne(p => p.Bootcamp);
        builder.HasOne(p => p.Bootcamp);

        builder.HasOne(p => p.ApplicationState);
        builder.HasOne(p => p.Applicant);
    }
}
