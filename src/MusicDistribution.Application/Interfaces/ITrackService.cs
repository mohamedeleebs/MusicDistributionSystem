using MusicDistribution.Application.Common;
using MusicDistribution.Application.DTOs.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Interfaces
{
    public interface ITrackService
    {
        Task<ApiResponse<TrackDto>> CreateTrackAsync(CreateTrackDto dto);

        Task<ApiResponse<IEnumerable<TrackDto>>> GetTracksAsync(
            int? artistId,
            string? genre,
            string? status);

        Task<ApiResponse<TrackDetailsDto>> GetTrackDetailsAsync(int id);

        Task<ApiResponse<bool>> UpdateStatusAsync(
            int id,
            UpdateTrackStatusDto dto);

        Task<ApiResponse<bool>> DistributeTrackAsync(
            int id,
            DistributeTrackDto dto);
    }
}
