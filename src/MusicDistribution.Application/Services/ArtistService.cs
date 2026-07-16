using MusicDistribution.Application.DTOs.Artist;
using MusicDistribution.Application.Interfaces;
using MusicDistribution.Application.Interfaces.Repositories;
using MusicDistribution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ArtistDto> CreateArtistAsync(CreateArtistDto dto)
        {
            var artist = new Artist
            {
                Name = dto.Name,
                Email = dto.Email,
                Country = dto.Country
            };

            await _unitOfWork.Artists.AddAsync(artist);

            await _unitOfWork.SaveChangesAsync();

            return new ArtistDto
            {
                Id = artist.Id,
                Name = artist.Name,
                Email = artist.Email,
                Country = artist.Country
            };
        }

        public async Task<IEnumerable<ArtistDto>> GetAllArtistsAsync()
        {
            var artists = await _unitOfWork.Artists.GetAllAsync();

            return artists.Select(a => new ArtistDto
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                Country = a.Country
            });
        }
    }
}
