using WeaterStation.Model;

namespace WeatherStation.BusinessLogic
{
    public interface IReport
    {
        void Display(Pressure pressure, Temperature temperature, Humidity humidity);
    }
}
