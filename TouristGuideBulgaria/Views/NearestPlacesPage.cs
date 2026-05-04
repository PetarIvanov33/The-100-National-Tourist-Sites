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

            public string ImageUrl => Place.ImageUrl;

            public double Distance { get; set; }

            public string DistanceText => $"{Distance:F1} км от вас";
        }

        public NearestPlacesPage(Location userLocation)
        {
            Title = "Най-близки обекти";

            var places = PlaceData.GetPlaces();

            var nearestPlaces = places
                .Select(p => new NearestPlaceItem
                {
                    Place = p,
                    Distance = CalculateDistance(
                        userLocation.Latitude,
                        userLocation.Longitude,
                        p.Latitude,
                        p.Longitude)
                })
                .OrderBy(p => p.Distance)
                .Take(5)
                .ToList();

            var collectionView = new CollectionView
            {
                ItemsSource = nearestPlaces,
                SelectionMode = SelectionMode.None,
                ItemTemplate = new DataTemplate(() =>
                {
                    var image = new Image
                    {
                        HeightRequest = 170,
                        Aspect = Aspect.AspectFill,
                        BackgroundColor = Colors.LightGray
                    };
                    image.SetBinding(Image.SourceProperty, nameof(NearestPlaceItem.ImageUrl));

                    var nameLabel = new Label
                    {
                        FontSize = 21,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black
                    };
                    nameLabel.SetBinding(Label.TextProperty, nameof(NearestPlaceItem.Name));

                    var categoryLabel = new Label
                    {
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
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
                        TextColor = Colors.DarkSlateBlue
                    };
                    distanceLabel.SetBinding(Label.TextProperty, nameof(NearestPlaceItem.DistanceText));

                    var detailsButton = new Button
                    {
                        Text = "Детайли",
                        BackgroundColor = Colors.MediumPurple,
                        TextColor = Colors.White,
                        CornerRadius = 10
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
                        Margin = new Thickness(0, 0, 0, 14),
                        Padding = 0,
                        CornerRadius = 14,
                        BorderColor = Colors.LightGray,
                        BackgroundColor = Colors.White,
                        HasShadow = true,
                        Content = new VerticalStackLayout
                        {
                            Spacing = 10,
                            Children =
                            {
                                image,
                                new VerticalStackLayout
                                {
                                    Padding = new Thickness(14, 0, 14, 14),
                                    Spacing = 6,
                                    Children =
                                    {
                                        nameLabel,
                                        categoryLabel,
                                        regionLabel,
                                        distanceLabel,
                                        detailsButton
                                    }
                                }
                            }
                        }
                    };
                })
            };

            Content = new ScrollView
            {
                Content = new VerticalStackLayout
                {
                    Padding = 16,
                    Spacing = 16,
                    Children =
                    {
                        new Label
                        {
                            Text = "Най-близките 5 обекта",
                            FontSize = 26,
                            FontAttributes = FontAttributes.Bold,
                            TextColor = Colors.Black
                        },
                        new Label
                        {
                            Text = "Списъкът е изчислен спрямо текущата GPS локация на устройството.",
                            FontSize = 15,
                            TextColor = Colors.Gray
                        },
                        collectionView
                    }
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