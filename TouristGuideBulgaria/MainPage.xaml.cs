using TouristGuideBulgaria.Data;
using TouristGuideBulgaria.Models;
using TouristGuideBulgaria.Views;
using TouristGuideBulgaria.Services;

namespace TouristGuideBulgaria
{
    public partial class MainPage : ContentPage
    {
        private Label _favoritesCountLabel;
        private Label _visitedCountLabel;
        private Label _progressLabel;

        public MainPage()
        {
            Title = "Начало";

            var places = PlaceData.GetPlaces();

            _favoritesCountLabel = new Label
            {
                FontSize = 14,
                TextColor = Colors.DarkSlateGray,
                FontAttributes = FontAttributes.Bold
            };

            _visitedCountLabel = new Label
            {
                FontSize = 14,
                TextColor = Colors.DarkSlateGray,
                FontAttributes = FontAttributes.Bold
            };

            _progressLabel = new Label
            {
                FontSize = 14,
                TextColor = Colors.DarkGreen,
                FontAttributes = FontAttributes.Bold
            };

            var favoritesButton = new Button
            {
                Text = "Любими обекти",
                BackgroundColor = Colors.MediumPurple,
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
                BackgroundColor = Colors.MediumPurple,
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
                    var image = new Image
                    {
                        HeightRequest = 170,
                        Aspect = Aspect.AspectFill,
                        BackgroundColor = Colors.LightGray
                    };
                    image.SetBinding(Image.SourceProperty, nameof(Place.ImageUrl));

                    var nameLabel = new Label
                    {
                        FontSize = 21,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.Black
                    };
                    nameLabel.SetBinding(Label.TextProperty, nameof(Place.Name));

                    var categoryLabel = new Label
                    {
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
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
                        FontSize = 14,
                        TextColor = Colors.DarkSlateGray
                    };
                    descriptionLabel.SetBinding(Label.TextProperty, nameof(Place.ShortDescription));

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
                        if (sender is Button button && button.CommandParameter is Place place)
                        {
                            await Navigation.PushAsync(new PlaceDetailsPage(place));
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
                                        descriptionLabel,
                                        detailsButton
                                    }
                                }
                            }
                        }
                    };
                })
            };

            var statsFrame = new Frame
            {
                Padding = 14,
                CornerRadius = 14,
                BorderColor = Colors.LightGray,
                BackgroundColor = Colors.White,
                HasShadow = true,
                Content = new VerticalStackLayout
                {
                    Spacing = 5,
                    Children =
                    {
                        _favoritesCountLabel,
                        _visitedCountLabel,
                        _progressLabel
                    }
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
                            Text = "100 национални туристически обекта",
                            FontSize = 26,
                            FontAttributes = FontAttributes.Bold,
                            TextColor = Colors.Black
                        },
                        new Label
                        {
                            Text = "Открий, запази и посети забележителностите на България",
                            FontSize = 15,
                            TextColor = Colors.Gray
                        },
                        statsFrame,
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

            var totalPlaces = PlaceData.GetPlaces().Count;
            var visitedCount = VisitedService.GetVisitedPlaces().Count;

            _favoritesCountLabel.Text =
                $"Любими: {FavoritesService.GetFavorites().Count}";

            _visitedCountLabel.Text =
                $"Посетени: {visitedCount} / {totalPlaces}";

            var progress = totalPlaces == 0 ? 0 : (visitedCount * 100) / totalPlaces;

            _progressLabel.Text =
                $"Прогрес: {progress}%";
        }
    }
}