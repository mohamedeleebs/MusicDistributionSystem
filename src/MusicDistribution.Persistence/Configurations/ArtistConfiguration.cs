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
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artists");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(a => a.Country)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(a => a.Email)
                   .IsUnique();

            builder.HasMany(a => a.Tracks)
                   .WithOne(t => t.Artist)
                   .HasForeignKey(t => t.ArtistId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
