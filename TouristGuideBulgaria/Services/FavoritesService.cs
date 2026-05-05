using TouristGuideBulgaria.Models;
using Microsoft.Maui.Storage;

namespace TouristGuideBulgaria.Services
{
    public static class FavoritesService
    {
        private const string FavoritesKey = "favorites_ids";

        private static List<int> _favoriteIds = new();

        static FavoritesService()
        {
            LoadFavorites();
        }

        public static List<Place> GetFavorites()
        {
            return Data.PlaceData.GetPlaces()
                .Where(p => _favoriteIds.Contains(p.Id))
                .ToList();
        }

        public static bool IsFavorite(int placeId)
        {
            return _favoriteIds.Contains(placeId);
        }

        public static void AddFavorite(Place place)
        {
            if (!_favoriteIds.Contains(place.Id))
            {
                _favoriteIds.Add(place.Id);
                SaveFavorites();
            }
        }

        public static void RemoveFavorite(Place place)
        {
            if (_favoriteIds.Contains(place.Id))
            {
                _favoriteIds.Remove(place.Id);
                SaveFavorites();
            }
        }

        private static void SaveFavorites()
        {
            var data = string.Join(",", _favoriteIds);
            Preferences.Set(FavoritesKey, data);
        }

        private static void LoadFavorites()
        {
            var data = Preferences.Get(FavoritesKey, "");

            if (string.IsNullOrWhiteSpace(data))
                return;

            _favoriteIds = data
                .Split(',')
                .Select(id => int.Parse(id))
                .ToList();
        }
    }
}