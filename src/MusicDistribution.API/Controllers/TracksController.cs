using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicDistribution.Application.DTOs.Track;
using MusicDistribution.Application.Interfaces;
using MusicDistribution.Domain.Enums;

namespace MusicDistribution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        // POST: api/tracks
        [HttpPost]
        [ProducesResponseType(typeof(TrackDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTrackDto dto)
        {
            var track = await _trackService.CreateTrackAsync(dto);

            return StatusCode(StatusCodes.Status201Created, track);
        }

        // GET: api/tracks?artistId=1&genre=Pop&status=1
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TrackDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int? artistId,
            [FromQuery] string? genre,
            [FromQuery] TrackStatus? status)
        {
            var tracks = await _trackService.GetTracksAsync(
                artistId,
                genre,
                status);

            return Ok(tracks);
        }

        // GET: api/tracks/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TrackDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var track = await _trackService.GetTrackDetailsAsync(id);

            return Ok(track);
        }
        [HttpPatch("{id:int}/status")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStatus(
    int id,
    [FromBody] UpdateTrackStatusDto dto)
        {
            await _trackService.UpdateTrackStatusAsync(id, dto);

            return NoContent();
        }
        [Authorize]
        [HttpPost("{id:int}/distribute")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Distribute(
    int id,
    [FromBody] DistributeTrackDto dto)
        {
            await _trackService.DistributeTrackAsync(id, dto);

            return NoContent();
        }
    }
}
