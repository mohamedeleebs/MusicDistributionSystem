using MusicDistribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.DTOs.Track
{
    public class TrackDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ArtistName { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public TrackStatus Status { get; set; }
    }
}
