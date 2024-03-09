using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Security.Entities;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(x => x.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(x => x.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();
        builder.Property(x => x.NationalIdentity).HasColumnName("NationalIdentity").IsRequired();
        builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
        builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();


        builder.HasMany(p => p.UserOperationClaims);
    }
}
