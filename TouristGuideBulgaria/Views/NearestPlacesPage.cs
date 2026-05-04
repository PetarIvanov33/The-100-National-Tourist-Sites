using Microsoft.Maui.Devices.Sensors;
using TouristGuideBulgaria.Data;
using TouristGuideBulgaria.Models;

namespace TouristGuideBulgaria.Views
{
    public class NearestPlacesPage : ContentPage
    {
        private class NearestPlaceItem
        {
            public Place Place { get; set; } = new Place();

            public string Name => Place.Name;

            public string Category => Place.Category;

            public string Region => Place.Region;

            public string DistanceText { get; set; } = string.Empty;
        }

        public NearestPlacesPage(Location userLocation)
        {
            Title = "Най-близки обекти";

            var places = PlaceData.GetPlaces();

            var nearestPlaces = places
                .Select(p => new NearestPlaceItem
                {
                    Place = p,
                    DistanceText = $"{CalculateDistance(
                        userLocation.Latitude,
                        userLocation.Longitude,
                        p.Latitude,
                        p.Longitude):F1} км от вас"
                })
                .OrderBy(p => double.Parse(p.DistanceText.Split(' ')[0]))
                .Take(5)
                .ToList();

            var collectionView = new CollectionView
            {
                ItemsSource = nearestPlaces,
                SelectionMode = SelectionMode.None,
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label
                    {
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold
                    };
                    nameLabel.SetBinding(Label.TextProperty, nameof(NearestPlaceItem.Name));

                    var categoryLabel = new Label
                    {
                        FontSize = 14,
                        TextColor = Colors.DarkGreen
                    };
                    categoryLabel.SetBinding(Label.TextProperty, nameof(NearestPlaceItem.Category));

                    var regionLabel = new Label
                    {
                        FontSize = 14,
                        TextColor = Colors.Gray
                    };
                    regionLabel.SetBinding(Label.TextProperty, nameof(NearestPlaceItem.Region));

                    var distanceLabel = new Label
                    {
                        FontSize = 15,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.DarkBlue
                    };
                    distanceLabel.SetBinding(Label.TextProperty, nameof(NearestPlaceItem.DistanceText));

                    var detailsButton = new Button
                    {
                        Text = "Детайли"
                    };

                    detailsButton.SetBinding(Button.CommandParameterProperty, ".");

                    detailsButton.Clicked += async (sender, e) =>
                    {
                        if (sender is Button button && button.CommandParameter is NearestPlaceItem item)
                        {
                            await Navigation.PushAsync(new PlaceDetailsPage(item.Place));
                        }
                    };

                    return new Frame
                    {
                        Margin = new Thickness(0, 0, 0, 12),
                        Padding = 12,
                        CornerRadius = 12,
                        BorderColor = Colors.LightGray,
                        Content = new VerticalStackLayout
                        {
                            Spacing = 5,
                            Children =
                            {
                                nameLabel,
                                categoryLabel,
                                regionLabel,
                                distanceLabel,
                                detailsButton
                            }
                        }
                    };
                })
            };

            Content = new VerticalStackLayout
            {
                Padding = 15,
                Spacing = 10,
                Children =
                {
                    new Label
                    {
                        Text = "Най-близките 5 обекта",
                        FontSize = 24,
                        FontAttributes = FontAttributes.Bold
                    },
                    collectionView
                }
            };
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371;

            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        private double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}