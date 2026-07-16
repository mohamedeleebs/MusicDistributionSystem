using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IArtistRepository Artists { get; }

        ITrackRepository Tracks { get; }

        IDspRepository DSPs { get; }

        ITrackDistributionRepository TrackDistributions { get; }

        Task<int> SaveChangesAsync();
    }
}
