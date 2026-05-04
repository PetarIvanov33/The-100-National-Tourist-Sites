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

            var image = new Image
            {
                Source = place.ImageUrl,
                HeightRequest = 220,
                Aspect = Aspect.AspectFill,
                BackgroundColor = Colors.LightGray
            };

            var nameLabel = new Label
            {
                Text = place.Name,
                FontSize = 28,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black
            };

            var categoryLabel = new Label
            {
                Text = $"Категория: {place.Category}",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
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
                FontSize = 16,
                LineBreakMode = LineBreakMode.WordWrap
            };

            var factLabel = new Label
            {
                Text = $"Интересен факт: {place.InterestingFact}",
                FontSize = 15,
                FontAttributes = FontAttributes.Italic,
                TextColor = Colors.DarkSlateGray
            };

            var coordinatesLabel = new Label
            {
                Text = $"Координати: {place.Latitude}, {place.Longitude}",
                FontSize = 14,
                TextColor = Colors.Gray
            };

            var favoriteButton = new Button
            {
                Text = FavoritesService.IsFavorite(_place.Id)
                    ? "Премахни от любими"
                    : "Добави в любими",
                CornerRadius = 10,
                BackgroundColor = Colors.MediumPurple,
                TextColor = Colors.White
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

            var mapsButton = new Button
            {
                Text = "Отвори в Google Maps",
                CornerRadius = 10,
                BackgroundColor = Colors.MediumPurple,
                TextColor = Colors.White
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
                    Spacing = 14,
                    Children =
                    {
                        image,

                        new VerticalStackLayout
                        {
                            Padding = new Thickness(20, 5, 20, 20),
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
                    }
                }
            };
        }
    }
}