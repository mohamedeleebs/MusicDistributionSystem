using MusicDistribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Domain.Entities
{

    public class TrackDistribution
    {
        public int Id { get; set; }

        public int TrackId { get; set; }

        public int DSPId { get; set; }

        public DateTime SubmittedAt { get; set; }

        public DistributionStatus Status { get; set; }

        public Track Track { get; set; } = null!;

        public DSP DSP { get; set; } = null!;
    }
}
