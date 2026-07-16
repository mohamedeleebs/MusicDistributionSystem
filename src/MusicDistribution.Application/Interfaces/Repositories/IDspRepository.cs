using MusicDistribution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Interfaces.Repositories
{
    public interface IDspRepository
    {
        Task<List<DSP>> GetAllAsync();

        Task<List<DSP>> GetByIdsAsync(List<int> ids);

        Task<DSP?> GetByIdAsync(int id);

        Task SaveChangesAsync();
    }
}
