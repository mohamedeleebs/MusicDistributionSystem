using MusicDistribution.Application.Common;
using MusicDistribution.Application.DTOs.Track;
using MusicDistribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Interfaces
{
    public interface ITrackService
    {
        Task<TrackDto> CreateTrackAsync(CreateTrackDto dto);

        Task<IEnumerable<TrackDto>> GetTracksAsync(
            int? artistId,
            string? genre,
            TrackStatus? status);

        Task<TrackDetailsDto> GetTrackDetailsAsync(int id);

        Task UpdateTrackStatusAsync(
            int id,
            UpdateTrackStatusDto dto);

        Task DistributeTrackAsync(
            int id,
            DistributeTrackDto dto);
    }
}