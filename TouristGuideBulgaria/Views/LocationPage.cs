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
                Text = "Натисни бутона за да вземеш локацията",
                FontSize = 16
            };

            var getLocationButton = new Button
            {
                Text = "Вземи локация"
            };

            var nearestButton = new Button
            {
                Text = "Покажи най-близките обекти"
            };

            getLocationButton.Clicked += async (sender, e) =>
            {
                try
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();

                    if (location == null)
                    {
                        location = await Geolocation.GetLocationAsync(
                            new GeolocationRequest(GeolocationAccuracy.Medium));
                    }

                    if (location != null)
                    {
                        _locationLabel.Text =
                            $"Latitude: {location.Latitude}\nLongitude: {location.Longitude}";
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

            Content = new VerticalStackLayout
            {
                Padding = 20,
                Spacing = 15,
                Children =
                {
                    _locationLabel,
                    getLocationButton,
                    nearestButton
                }
            };
        }
    }
}