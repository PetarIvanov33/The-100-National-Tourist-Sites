using TouristGuideBulgaria.Data;
using TouristGuideBulgaria.Models;
using TouristGuideBulgaria.Views;
using TouristGuideBulgaria.Services;

namespace TouristGuideBulgaria
{
    public partial class MainPage : ContentPage
    {
        private Label _favoritesCountLabel;

        public MainPage()
        {
            var places = PlaceData.GetPlaces();

            _favoritesCountLabel = new Label
            {
                FontSize = 14,
                TextColor = Colors.DarkBlue
            };

            var favoritesButton = new Button
            {
                Text = "Любими обекти",
                BackgroundColor = Colors.LightBlue,
                TextColor = Colors.White,
                CornerRadius = 10
            };

            favoritesButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new FavoritesPage());
            };

            var locationButton = new Button
            {
                Text = "Моята локация",
                BackgroundColor = Colors.LightBlue,
                TextColor = Colors.White,
                CornerRadius = 10
            };

            locationButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new LocationPage());
            };

            var collectionView = new CollectionView
            {
                ItemsSource = places,
                SelectionMode = SelectionMode.None,
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label
                    {
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold
                    };
                    nameLabel.SetBinding(Label.TextProperty, nameof(Place.Name));

                    var categoryLabel = new Label
                    {
                        FontSize = 14,
                        TextColor = Colors.DarkGreen
                    };
                    categoryLabel.SetBinding(Label.TextProperty, nameof(Place.Category));

                    var regionLabel = new Label
                    {
                        FontSize = 14,
                        TextColor = Colors.Gray
                    };
                    regionLabel.SetBinding(Label.TextProperty, nameof(Place.Region));

                    var descriptionLabel = new Label
                    {
                        FontSize = 14
                    };
                    descriptionLabel.SetBinding(Label.TextProperty, nameof(Place.ShortDescription));

                    var detailsButton = new Button
                    {
                        Text = "Детайли",
                        BackgroundColor = Colors.LightGray,
                        TextColor = Colors.Black,
                        CornerRadius = 8
                    };

                    detailsButton.SetBinding(Button.CommandParameterProperty, ".");
                    detailsButton.Clicked += async (sender, e) =>
                    {
                        if (sender is Button button && button.CommandParameter is Place place)
                        {
                            await Navigation.PushAsync(new PlaceDetailsPage(place));
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
                                descriptionLabel,
                                detailsButton
                            }
                        }
                    };
                })
            };

            Content = new ScrollView
            {
                Content = new VerticalStackLayout
                {
                    Padding = 15,
                    Spacing = 15,
                    Children =
                    {
                        new Label
                        {
                            Text = "100 национални туристически обекта",
                            FontSize = 24,
                            FontAttributes = FontAttributes.Bold
                        },
                        new Label
                        {
                            Text = "Открий, запази и посети забележителностите на България",
                            FontSize = 14,
                            TextColor = Colors.Gray
                        },
                        _favoritesCountLabel,
                        favoritesButton,
                        locationButton,
                        collectionView
                    }
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _favoritesCountLabel.Text =
                $"Любими: {FavoritesService.GetFavorites().Count}";
        }
    }
}