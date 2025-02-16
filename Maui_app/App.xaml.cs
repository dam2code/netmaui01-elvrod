namespace Maui_app;

public partial class App : Application
{
    public static PersonRepository PersonRepo { get; private set; }

    public App(PersonRepository personRepo) // Recibir la instancia inyectada
    {
        InitializeComponent();

        // Asignar la instancia inyectada a la propiedad estática
        PersonRepo = personRepo;
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        return new Window(new AppShell());
    }
}
