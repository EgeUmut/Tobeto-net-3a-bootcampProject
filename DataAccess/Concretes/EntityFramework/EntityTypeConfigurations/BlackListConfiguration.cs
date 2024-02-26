using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

internal class BlackListConfiguration:IEntityTypeConfiguration<BlackList>
{
    public void Configure(EntityTypeBuilder<BlackList> builder)
    {
        builder.ToTable("BlackLists").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.ApplicantId).HasColumnName("ApplicantId").IsRequired();
        builder.Property(x => x.Reason).HasColumnName("Reason").IsRequired();
        builder.Property(x => x.Date).HasColumnName("Date").IsRequired();
        builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
        builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");
        builder.Property(x => x.DeleteDate).HasColumnName("DeleteDate");
        builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted");

        builder.HasOne(p => p.Applicant);
    }
}
