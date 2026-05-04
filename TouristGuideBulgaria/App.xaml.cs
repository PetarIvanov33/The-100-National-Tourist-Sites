namespace TouristGuideBulgaria
{
    public partial class App : Application
    {
        public App()
        {
           
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new MainPage()));
        }
    }
}