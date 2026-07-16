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
    public class DspRepository : IDspRepository
    {
        private readonly ApplicationDbContext _context;

        public DspRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DSP>> GetAllAsync()
        {
            return await _context.DSPs
                .AsNoTracking()
                .OrderBy(d => d.Name)
                .ToListAsync();
        }

        public async Task<DSP?> GetByIdAsync(int id)
        {
            return await _context.DSPs
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DSP>> GetByIdsAsync(List<int> ids)
        {
            return await _context.DSPs
                .Where(d => ids.Contains(d.Id))
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
