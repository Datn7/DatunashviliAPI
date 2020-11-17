using DatunashviliAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatunashviliAPI.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        /* "პროდუქტების კონფიგურაცია ბაზაში შექმნის დროს მიგრაციისას" */
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();

            builder.HasOne(b => b.WineType).WithMany().HasForeignKey(p => p.WineTypeId);
            builder.HasOne(b => b.WineYear).WithMany().HasForeignKey(p => p.WineYearId);
        }
    }
}
