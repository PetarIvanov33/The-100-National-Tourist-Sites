using TouristGuideBulgaria.Models;
using TouristGuideBulgaria.Services;

namespace TouristGuideBulgaria.Views
{
    public class VisitedPage : ContentPage
    {
        private readonly CollectionView _collectionView;
        private readonly Label _emptyLabel;

        public VisitedPage()
        {
            Title = "Посетени";

            _emptyLabel = new Label
            {
                Text = "Все още няма посетени обекти.",
                FontSize = 16,
                TextColor = Colors.Gray,
                HorizontalTextAlignment = TextAlignment.Center,
                IsVisible = false
            };

            _collectionView = new CollectionView
            {
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

                    var detailsButton = new Button
                    {
                        Text = "Детайли",
                        BackgroundColor = Colors.SeaGreen,
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
                            Text = "Посетени обекти",
                            FontSize = 26,
                            FontAttributes = FontAttributes.Bold,
                            TextColor = Colors.Black
                        },
                        new Label
                        {
                            Text = "Тук се показват всички обекти, които си посетил.",
                            FontSize = 15,
                            TextColor = Colors.Gray
                        },
                        _emptyLabel,
                        _collectionView
                    }
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var visited = VisitedService.GetVisitedPlaces();

            _collectionView.ItemsSource = null;
            _collectionView.ItemsSource = visited;

            _emptyLabel.IsVisible = visited.Count == 0;
            _collectionView.IsVisible = visited.Count > 0;
        }
    }
}