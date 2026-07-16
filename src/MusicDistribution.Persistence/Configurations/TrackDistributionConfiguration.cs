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
    public class TrackDistributionConfiguration : IEntityTypeConfiguration<TrackDistribution>
    {
        public void Configure(EntityTypeBuilder<TrackDistribution> builder)
        {
            builder.ToTable("TrackDistributions");

            builder.HasKey(td => td.Id);

            builder.Property(td => td.SubmittedAt)
                   .IsRequired();

            builder.Property(td => td.Status)
                   .HasConversion<int>();

            builder.HasIndex(td => new
            {
                td.TrackId,
                td.DSPId
            }).IsUnique();
        }
    }
}
