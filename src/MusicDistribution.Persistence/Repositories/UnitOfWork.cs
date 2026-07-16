using MusicDistribution.Application.Interfaces.Repositories;
using MusicDistribution.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IArtistRepository Artists { get; }

        public ITrackRepository Tracks { get; }

        public IDspRepository DSPs { get; }

        public ITrackDistributionRepository TrackDistributions { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IArtistRepository artistRepository,
            ITrackRepository trackRepository,
            IDspRepository dspRepository,
            ITrackDistributionRepository trackDistributionRepository)
        {
            _context = context;

            Artists = artistRepository;
            Tracks = trackRepository;
            DSPs = dspRepository;
            TrackDistributions = trackDistributionRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
