using Microsoft.AspNetCore.Mvc;
using MusicDistribution.Application.DTOs.Artist;
using MusicDistribution.Application.Interfaces;

namespace MusicDistribution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ArtistDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var artists = await _artistService.GetAllArtistsAsync();

            return Ok(artists);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ArtistDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateArtistDto dto)
        {
            var artist = await _artistService.CreateArtistAsync(dto);

            return CreatedAtAction(
                nameof(GetAll),
                new { id = artist.Id },
                artist);
        }
    }
}
