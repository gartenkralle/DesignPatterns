using WeaterStation.Model;
using System;
using WeatherStation.View;
using WeatherStation.BusinessLogic;

namespace WeaterStation
{
    class Program
    {
        static void Main()
        {
            Controller controller = new Controller();
            controller.Display(new MainView());

            Console.ReadKey();
        }
    }
}
