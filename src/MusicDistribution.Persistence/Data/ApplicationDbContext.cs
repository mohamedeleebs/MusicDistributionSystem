using Microsoft.EntityFrameworkCore;
using MusicDistribution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists => Set<Artist>();

        public DbSet<Track> Tracks => Set<Track>();

        public DbSet<DSP> DSPs => Set<DSP>();

        public DbSet<TrackDistribution> TrackDistributions => Set<TrackDistribution>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
