using TouristGuideBulgaria.Models;

namespace TouristGuideBulgaria.Services
{
    public static class FavoritesService
    {
        private static readonly List<Place> _favorites = new();

        public static List<Place> GetFavorites()
        {
            return _favorites;
        }

        public static bool IsFavorite(int placeId)
        {
            return _favorites.Any(p => p.Id == placeId);
        }

        public static void AddFavorite(Place place)
        {
            if (!IsFavorite(place.Id))
            {
                place.IsFavorite = true;
                _favorites.Add(place);
            }
        }

        public static void RemoveFavorite(Place place)
        {
            var existingPlace = _favorites.FirstOrDefault(p => p.Id == place.Id);

            if (existingPlace != null)
            {
                existingPlace.IsFavorite = false;
                _favorites.Remove(existingPlace);
            }

            place.IsFavorite = false;
        }
    }
}