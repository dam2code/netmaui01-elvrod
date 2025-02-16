using Astronomy;

namespace Maui_app.Pages;

[QueryProperty(nameof(AstroName), "astroName")]
public partial class AstronomicalBodyPage : ContentPage
{
     string astroName;

    public string AstroName
    {
        get => astroName;
        set
        {
            astroName = value;
            UpdateAstroBodyUI(astroName);  // Actualizar UI cuando el par�metro cambia
        }
    }

    public AstronomicalBodyPage()
    {
        InitializeComponent();
    }

    void UpdateAstroBodyUI(string astroName)
    {
        AstronomicalBody body = FindAstroData(astroName);

        Title = body.Name;  // Cambia el t�tulo de la p�gina

        lblIcon.Text = body.EmojiIcon;
        lblName.Text = body.Name;
        lblMass.Text = body.Mass;
        lblCircumference.Text = body.Circumference;
        lblAge.Text = body.Age;
    }

    AstronomicalBody FindAstroData(string astronomicalBodyName)
    {
        return astronomicalBodyName switch
        {
            "comet" => SolarSystemData.HalleysComet,
            "earth" => SolarSystemData.Earth,
            "moon" => SolarSystemData.Moon,
            "sun" => SolarSystemData.Sun,
            _ => throw new ArgumentException("Cuerpo astron�mico no v�lido")
        };
    }
}
