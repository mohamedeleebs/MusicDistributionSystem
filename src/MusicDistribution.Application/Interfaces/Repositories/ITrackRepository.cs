using MusicDistribution.Domain.Entities;
using MusicDistribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Interfaces.Repositories
{
    public interface ITrackRepository
    {
        Task AddAsync(Track track);

        Task<Track?> GetByIdAsync(int id);


        Task<Track?> GetDetailsAsync(int id);        // AsNoTracking + Include

        Task<bool> ExistsAsync(int id);

        Task<bool> IsrcExistsAsync(string isrc);

        Task<IEnumerable<Track>> GetAllAsync(
            int? artistId,
            string? genre,
            TrackStatus? status);

        void Update(Track track);
        Task SaveChangesAsync();
    }
}
