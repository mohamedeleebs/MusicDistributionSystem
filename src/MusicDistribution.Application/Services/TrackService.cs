using MusicDistribution.Application.DTOs.Distribution;
using MusicDistribution.Application.DTOs.Track;
using MusicDistribution.Application.Interfaces;
using MusicDistribution.Application.Interfaces.Repositories;
using MusicDistribution.Domain.Entities;
using MusicDistribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Services
{
    public class TrackService : ITrackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TrackDto> CreateTrackAsync(CreateTrackDto dto)
        {
            // Check Artist Exists
            if (!await _unitOfWork.Artists.ExistsAsync(dto.ArtistId))
                throw new Exception("Artist not found.");

            // Check ISRC Uniqueness
            if (await _unitOfWork.Tracks.IsrcExistsAsync(dto.ISRC))
                throw new Exception("ISRC already exists.");

            var track = new Track
            {
                Title = dto.Title,
                ArtistId = dto.ArtistId,
                ISRC = dto.ISRC,
                Genre = dto.Genre,
                ReleaseDate = dto.ReleaseDate,
                Status = dto.Status
            };

            await _unitOfWork.Tracks.AddAsync(track);

            await _unitOfWork.SaveChangesAsync();

            var artist = await _unitOfWork.Artists.GetByIdAsync(dto.ArtistId);

            return new TrackDto
            {
                Id = track.Id,
                Title = track.Title,
                ArtistName = artist!.Name,
                Genre = track.Genre,
                Status = track.Status
            };
        }

        public async Task<IEnumerable<TrackDto>> GetTracksAsync(
            int? artistId,
            string? genre,
            TrackStatus? status)
        {
            var tracks = await _unitOfWork.Tracks.GetAllAsync(
                artistId,
                genre,
                status);

            return tracks.Select(track => new TrackDto
            {
                Id = track.Id,
                Title = track.Title,
                ArtistName = track.Artist.Name,
                Genre = track.Genre,
                Status = track.Status
            });
        }

        public async Task<TrackDetailsDto> GetTrackDetailsAsync(int id)
        {
            var track = await _unitOfWork.Tracks.GetDetailsAsync(id);

            if (track is null)
                throw new Exception("Track not found.");

            return new TrackDetailsDto
            {
                Id = track.Id,
                Title = track.Title,
                ArtistName = track.Artist.Name,
                Genre = track.Genre,
                ISRC = track.ISRC,
                ReleaseDate = track.ReleaseDate,
                Status = track.Status,

                Distributions = track.TrackDistributions
                    .Select(td => new DistributionDto
                    {
                        DSPName = td.DSP.Name,
                        Status = td.Status,
                        SubmittedAt = td.SubmittedAt
                    })
                    .ToList()
            };
        }

        public async Task UpdateTrackStatusAsync(
    int id,
    UpdateTrackStatusDto dto)
        {
            var track = await _unitOfWork.Tracks.GetByIdAsync(id);

            if (track is null)
                throw new Exception("Track not found.");

            track.Status = dto.Status;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DistributeTrackAsync(
    int id,
    DistributeTrackDto dto)
        {
            var track = await _unitOfWork.Tracks.GetByIdAsync(id);

            if (track is null)
                throw new Exception("Track not found.");

            var dsps = await _unitOfWork.DSPs.GetByIdsAsync(dto.DSPIds);

            if (dsps.Count != dto.DSPIds.Count)
                throw new Exception("One or more DSPs do not exist.");

            var distributions = new List<TrackDistribution>();

            foreach (var dsp in dsps)
            {
                var alreadyExists =
                    await _unitOfWork.TrackDistributions
                        .ExistsAsync(track.Id, dsp.Id);

                if (alreadyExists)
                    continue;

                distributions.Add(new TrackDistribution
                {
                    TrackId = track.Id,
                    DSPId = dsp.Id,
                    SubmittedAt = DateTime.UtcNow,
                    Status = DistributionStatus.Pending
                });
            }

            if (distributions.Any())
            {
                await _unitOfWork.TrackDistributions
                    .AddRangeAsync(distributions);

                track.Status = TrackStatus.Submitted;

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
