using FluentValidation;
using MusicDistribution.Application.DTOs.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Validators.Track
{
    public class CreateTrackValidator : AbstractValidator<CreateTrackDto>
    {
        public CreateTrackValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.ISRC)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.ArtistId)
                .GreaterThan(0);

            RuleFor(x => x.Genre)
                .NotEmpty();

            RuleFor(x => x.ReleaseDate)
                .NotEmpty();
        }
    }
}
