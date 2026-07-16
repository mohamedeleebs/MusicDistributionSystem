using MusicDistribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ISRC { get; set; } = string.Empty;

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; } = string.Empty;

        public TrackStatus Status { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; } = null!;

        public ICollection<TrackDistribution> TrackDistributions { get; set; }
            = new List<TrackDistribution>();
    }
}
