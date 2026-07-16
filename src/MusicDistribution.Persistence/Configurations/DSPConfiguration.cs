using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicDistribution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Persistence.Configurations
{
    public class DSPConfiguration : IEntityTypeConfiguration<DSP>
    {
        public void Configure(EntityTypeBuilder<DSP> builder)
        {
            builder.ToTable("DSPs");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(d => d.Name)
                   .IsUnique();

            builder.HasMany(d => d.TrackDistributions)
                   .WithOne(td => td.DSP)
                   .HasForeignKey(td => td.DSPId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
