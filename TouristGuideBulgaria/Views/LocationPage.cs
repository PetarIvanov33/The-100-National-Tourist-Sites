using Microsoft.Maui.Devices.Sensors;

namespace TouristGuideBulgaria.Views
{
    public class LocationPage : ContentPage
    {
        private readonly Label _locationLabel;

        public LocationPage()
        {
            Title = "Моята локация";

            _locationLabel = new Label
            {
                Text = "Все още няма взета локация.",
                FontSize = 16,
                TextColor = Colors.DarkSlateGray
            };

            var getLocationButton = new Button
            {
                Text = "Вземи локация",
                BackgroundColor = Colors.MediumPurple,
                TextColor = Colors.White,
                CornerRadius = 10
            };

            var nearestButton = new Button
            {
                Text = "Покажи най-близките обекти",
                BackgroundColor = Colors.MediumPurple,
                TextColor = Colors.White,
                CornerRadius = 10
            };

            getLocationButton.Clicked += async (sender, e) =>
            {
                try
                {
                    _locationLabel.Text = "Зареждане на локация...";

                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if (location == null)
                    {
                        location = await Geolocation.GetLocationAsync(
                            new GeolocationRequest(GeolocationAccuracy.Medium));
                    }

                    if (location != null)
                    {
                        _locationLabel.Text =
                            $"Latitude: {location.Latitude:F6}\nLongitude: {location.Longitude:F6}";
                    }
                    else
                    {
                        _locationLabel.Text = "Не успяхме да вземем локацията.";
                    }
                }
                catch (Exception ex)
                {
                    _locationLabel.Text = $"Грешка: {ex.Message}";
                }
            };

            nearestButton.Clicked += async (sender, e) =>
            {
                try
                {
                    _locationLabel.Text = "Проверка на текущата локация...";

                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if (location == null)
                    {
                        location = await Geolocation.GetLocationAsync(
                            new GeolocationRequest(GeolocationAccuracy.Medium));
                    }

                    if (location == null)
                    {
                        await DisplayAlert("Грешка", "Няма локация", "OK");
                        return;
                    }

                    await Navigation.PushAsync(new NearestPlacesPage(location));
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Грешка", ex.Message, "OK");
                }
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
                            Text = "Моята локация",
                            FontSize = 26,
                            FontAttributes = FontAttributes.Bold,
                            TextColor = Colors.Black
                        },
                        new Label
                        {
                            Text = "Използвай GPS функционалността на телефона, за да намериш най-близките туристически обекти.",
                            FontSize = 15,
                            TextColor = Colors.Gray
                        },

                        new Frame
                        {
                            Padding = 16,
                            CornerRadius = 14,
                            BorderColor = Colors.LightGray,
                            BackgroundColor = Colors.White,
                            HasShadow = true,
                            Content = new VerticalStackLayout
                            {
                                Spacing = 10,
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "Текущи координати",
                                        FontSize = 20,
                                        FontAttributes = FontAttributes.Bold,
                                        TextColor = Colors.Black
                                    },
                                    _locationLabel
                                }
                            }
                        },

                        getLocationButton,
                        nearestButton
                    }
                }
            };
        }
    }
}