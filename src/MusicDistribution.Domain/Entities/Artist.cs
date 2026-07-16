using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDistribution.Domain.Entities
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public ICollection<Track> Tracks { get; set; } = new List<Track>();
    }
}
