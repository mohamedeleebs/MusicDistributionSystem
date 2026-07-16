using MusicDistribution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Interfaces.Repositories
{
    public interface IArtistRepository
    {
        Task AddAsync(Artist artist);

        Task<List<Artist>> GetAllAsync();

        Task<Artist?> GetByIdAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task SaveChangesAsync();
    }
}
