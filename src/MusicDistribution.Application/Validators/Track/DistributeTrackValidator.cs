using FluentValidation;
using MusicDistribution.Application.DTOs.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Validators.Track
{
    public class DistributeTrackValidator
      : AbstractValidator<DistributeTrackDto>
    {
        public DistributeTrackValidator()
        {
            RuleFor(x => x.DSPIds)
                .NotEmpty();

            RuleForEach(x => x.DSPIds)
                .GreaterThan(0);
        }
    }
}
