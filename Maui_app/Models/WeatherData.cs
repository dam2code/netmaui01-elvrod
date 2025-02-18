
namespace Maui_app.Models;

public readonly record struct WeatherData(int Temperature,
                                          int Precipitation,
                                          int Humidity,
                                          int Wind,
                                          WeatherType Condition);
