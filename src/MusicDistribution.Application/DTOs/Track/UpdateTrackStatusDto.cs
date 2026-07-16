using MusicDistribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.DTOs.Track
{
    public class UpdateTrackStatusDto
    {
        public TrackStatus Status { get; set; }
    }
}
