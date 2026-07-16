using MusicDistribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.DTOs.Track
{
    public class CreateTrackDto
    {
        public string Title { get; set; } = string.Empty;

        public int ArtistId { get; set; }

        public string ISRC { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; } = string.Empty;

        public TrackStatus Status { get; set; }
    }
}
