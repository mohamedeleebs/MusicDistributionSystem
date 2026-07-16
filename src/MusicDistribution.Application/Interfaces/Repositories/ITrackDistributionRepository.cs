using MusicDistribution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Interfaces.Repositories
{
    public interface ITrackDistributionRepository
    {
        Task AddRangeAsync(List<TrackDistribution> distributions);

        Task<List<TrackDistribution>> GetByTrackIdAsync(int trackId);

        Task SaveChangesAsync();
    }
}
