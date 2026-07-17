using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MusicDistribution.Domain.Entities;
using MusicDistribution.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MusicDistribution.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace MusicDistribution.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists => Set<Artist>();

        public DbSet<Track> Tracks => Set<Track>();

        public DbSet<DSP> DSPs => Set<DSP>();

        public DbSet<TrackDistribution> TrackDistributions => Set<TrackDistribution>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}