using Microsoft.EntityFrameworkCore;
using MusicDistribution.Application.Interfaces.Repositories;
using MusicDistribution.Domain.Entities;
using MusicDistribution.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Persistence.Repositories
{
    public class TrackDistributionRepository : ITrackDistributionRepository
    {
        private readonly ApplicationDbContext _context;

        public TrackDistributionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<TrackDistribution> distributions)
        {
            await _context.TrackDistributions.AddRangeAsync(distributions);
        }

        public async Task<List<TrackDistribution>> GetByTrackIdAsync(int trackId)
        {
            return await _context.TrackDistributions
                .AsNoTracking()
                .Include(td => td.DSP)
                .Where(td => td.TrackId == trackId)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int trackId, int dspId)
        {
            return await _context.TrackDistributions
                .AnyAsync(td => td.TrackId == trackId &&
                                td.DSPId == dspId);
        }
    }
}
