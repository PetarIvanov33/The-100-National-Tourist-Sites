using TouristGuideBulgaria.Models;
using TouristGuideBulgaria.Services;

namespace TouristGuideBulgaria.Views
{
    public class FavoritesPage : ContentPage
    {
        private readonly CollectionView _collectionView;

        public FavoritesPage()
        {
            Title = "Любими";

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
                            Text = "Любими обекти",
                            FontSize = 26,
                            FontAttributes = FontAttributes.Bold,
                            TextColor = Colors.Black
                        },
                        new Label
                        {
                            Text = "Тук се показват всички запазени от теб туристически обекти.",
                            FontSize = 15,
                            TextColor = Colors.Gray
                        },
                        _collectionView
                    }
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _collectionView.ItemsSource = null;
            _collectionView.ItemsSource = FavoritesService.GetFavorites();
        }
    }
}