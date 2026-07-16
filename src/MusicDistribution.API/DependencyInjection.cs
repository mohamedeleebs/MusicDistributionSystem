using FluentValidation;
using MusicDistribution.Application.Interfaces;
using MusicDistribution.Application.Services;
using MusicDistribution.Application.Validators.Artist;

namespace MusicDistribution.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IArtistService, ArtistService>();

            services.AddScoped<ITrackService, TrackService>();

            services.AddValidatorsFromAssemblyContaining<CreateArtistValidator>();

            return services;
        }
    }
}
