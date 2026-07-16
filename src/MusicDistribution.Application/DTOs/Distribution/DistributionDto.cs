using MusicDistribution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.DTOs.Distribution
{
    public class DistributionDto
    {
        public string DSPName { get; set; } = string.Empty;

        public DistributionStatus Status { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
