using TouristGuideBulgaria.Models;
using TouristGuideBulgaria.Services;

namespace TouristGuideBulgaria.Views
{
    public class PlaceDetailsPage : ContentPage
    {
        private readonly Place _place;

        public PlaceDetailsPage(Place place)
        {
            _place = place;

            Title = place.Name;

            var nameLabel = new Label
            {
                Text = place.Name,
                FontSize = 26,
                FontAttributes = FontAttributes.Bold
            };

            var categoryLabel = new Label
            {
                Text = $"Категория: {place.Category}",
                FontSize = 15,
                TextColor = Colors.DarkGreen
            };

            var regionLabel = new Label
            {
                Text = $"Регион: {place.Region}",
                FontSize = 15,
                TextColor = Colors.Gray
            };

            var descriptionLabel = new Label
            {
                Text = place.Description,
                FontSize = 16
            };

            var factLabel = new Label
            {
                Text = $"Интересен факт: {place.InterestingFact}",
                FontSize = 15,
                FontAttributes = FontAttributes.Italic
            };

            var coordinatesLabel = new Label
            {
                Text = $"Координати: {place.Latitude}, {place.Longitude}",
                FontSize = 14,
                TextColor = Colors.Gray
            };

            // ⭐ Бутон за любими
            var favoriteButton = new Button
            {
                Text = FavoritesService.IsFavorite(_place.Id)
                    ? "Премахни от любими"
                    : "Добави в любими"
            };

            favoriteButton.Clicked += async (sender, e) =>
            {
                if (FavoritesService.IsFavorite(_place.Id))
                {
                    FavoritesService.RemoveFavorite(_place);
                    favoriteButton.Text = "Добави в любими";
                    await DisplayAlert("Любими", "Обектът е премахнат от любими.", "OK");
                }
                else
                {
                    FavoritesService.AddFavorite(_place);
                    favoriteButton.Text = "Премахни от любими";
                    await DisplayAlert("Любими", "Обектът е добавен в любими.", "OK");
                }
            };

            // 🗺️ Google Maps бутон
            var mapsButton = new Button
            {
                Text = "Отвори в Google Maps"
            };

            mapsButton.Clicked += async (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(_place.GoogleMapsUrl))
                {
                    await Launcher.OpenAsync(_place.GoogleMapsUrl);
                }
            };

            Content = new ScrollView
            {
                Content = new VerticalStackLayout
                {
                    Padding = 20,
                    Spacing = 12,
                    Children =
                    {
                        nameLabel,
                        categoryLabel,
                        regionLabel,
                        descriptionLabel,
                        factLabel,
                        coordinatesLabel,
                        favoriteButton,
                        mapsButton
                    }
                }
            };
        }
    }
}