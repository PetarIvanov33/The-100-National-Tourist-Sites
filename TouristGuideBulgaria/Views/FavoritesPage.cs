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

                    var detailsButton = new Button
                    {
                        Text = "Детайли"
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
                    Spacing = 10,
                    Children =
                    {
                        new Label
                        {
                            Text = "Любими обекти",
                            FontSize = 24,
                            FontAttributes = FontAttributes.Bold
                        },
                        _collectionView
                    }
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // 🔥 това е ключът – обновява списъка всеки път
            _collectionView.ItemsSource = null;
            _collectionView.ItemsSource = FavoritesService.GetFavorites();
        }
    }
}