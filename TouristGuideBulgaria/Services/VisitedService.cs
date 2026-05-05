using TouristGuideBulgaria.Models;
using Microsoft.Maui.Storage;

namespace TouristGuideBulgaria.Services
{
    public static class VisitedService
    {
        private const string VisitedKey = "visited_ids";

        private static List<int> _visitedIds = new();

        static VisitedService()
        {
            LoadVisited();
        }

        public static List<Place> GetVisitedPlaces()
        {
            return Data.PlaceData.GetPlaces()
                .Where(p => _visitedIds.Contains(p.Id))
                .ToList();
        }

        public static bool IsVisited(int placeId)
        {
            return _visitedIds.Contains(placeId);
        }

        public static void AddVisited(Place place)
        {
            if (!_visitedIds.Contains(place.Id))
            {
                _visitedIds.Add(place.Id);
                SaveVisited();
            }
        }

        public static void RemoveVisited(Place place)
        {
            if (_visitedIds.Contains(place.Id))
            {
                _visitedIds.Remove(place.Id);
                SaveVisited();
            }
        }

        private static void SaveVisited()
        {
            var data = string.Join(",", _visitedIds);
            Preferences.Set(VisitedKey, data);
        }

        private static void LoadVisited()
        {
            var data = Preferences.Get(VisitedKey, "");

            if (string.IsNullOrWhiteSpace(data))
                return;

            _visitedIds = data
                .Split(',')
                .Select(id => int.Parse(id))
                .ToList();
        }
    }
}