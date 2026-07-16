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
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Tracks");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.ISRC)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(t => t.ISRC)
                   .IsUnique();

            builder.Property(t => t.Genre)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.ReleaseDate)
                   .IsRequired();

            builder.Property(t => t.Status)
                   .HasConversion<int>();

            builder.HasMany(t => t.TrackDistributions)
                   .WithOne(td => td.Track)
                   .HasForeignKey(td => td.TrackId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
