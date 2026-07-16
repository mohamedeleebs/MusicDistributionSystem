using FluentValidation;
using MusicDistribution.Application.DTOs.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Application.Validators.Artist
{
    public class CreateArtistValidator : AbstractValidator<CreateArtistDto>
    {
        public CreateArtistValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
