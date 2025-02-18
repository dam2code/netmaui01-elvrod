namespace Maui_app;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Maui_app.MainPage), typeof(Maui_app.MainPage));
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell());
#if WINDOWS
        window.Width = 500;
        window.Height = 300;
#endif
        return window;
    }
}
