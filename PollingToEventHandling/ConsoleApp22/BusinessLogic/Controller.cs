using WeaterStation.Model;

namespace WeatherStation.BusinessLogic
{
    public class Controller
    {
        private Humidity humidity;
        private Temperature temperature;
        private Pressure pressure;

        public Controller()
        {
            humidity = new Humidity();
            temperature = new Temperature();
            pressure = new Pressure();
        }

        public void Display(IReport report)
        {
            report.Display(pressure, temperature, humidity);
        }
    }
}
