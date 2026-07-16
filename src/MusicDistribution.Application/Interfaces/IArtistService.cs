using MusicDistribution.Application.Common;
using MusicDistribution.Application.DTOs.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Interfaces
{
    public interface IArtistService
    {
        Task<ArtistDto> CreateArtistAsync(CreateArtistDto dto);

        Task<IEnumerable<ArtistDto>> GetAllArtistsAsync();
    }
}
