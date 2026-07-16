using Microsoft.EntityFrameworkCore;
using MusicDistribution.Application.Interfaces.Repositories;
using MusicDistribution.Domain.Entities;
using MusicDistribution.Domain.Enums;
using MusicDistribution.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Persistence.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ApplicationDbContext _context;

        public TrackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Track track)
        {
            await _context.Tracks.AddAsync(track);
        }

        
        public async Task<Track?> GetByIdAsync(int id)
        {
            return await _context.Tracks
                .Include(t => t.TrackDistributions)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<Track?> GetDetailsAsync(int id)
        {
            return await _context.Tracks
                .AsNoTracking()
                .Include(t => t.Artist)
                .Include(t => t.TrackDistributions)
                    .ThenInclude(td => td.DSP)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Tracks
                .AnyAsync(t => t.Id == id);
        }

        public async Task<bool> IsrcExistsAsync(string isrc)
        {
            return await _context.Tracks
                .AnyAsync(t => t.ISRC == isrc);
        }

        public async Task<IEnumerable<Track>> GetAllAsync(
            int? artistId,
            string? genre,
            TrackStatus? status)
        {
            IQueryable<Track> query = _context.Tracks
                .Include(t => t.Artist);

            if (artistId.HasValue)
            {
                query = query.Where(t => t.ArtistId == artistId.Value);
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                query = query.Where(t => t.Genre == genre);
            }

            if (status.HasValue)
            {
                query = query.Where(t => t.Status == status.Value);
            }

            return await query
                .OrderByDescending(t => t.ReleaseDate)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Update(Track track)
        {
            _context.Tracks.Update(track);
        }
    }
}
