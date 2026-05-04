using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuideBulgaria.Models
{
    public class Place
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Region { get; set; } = string.Empty;

        public string ShortDescription { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string InterestingFact { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool IsFavorite { get; set; }

        public bool IsVisited { get; set; }

        public string GoogleMapsUrl { get; set; } = string.Empty;
    }
}
