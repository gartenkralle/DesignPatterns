using System;
using System.ComponentModel;

namespace WeaterStation.Model
{
    public class Temperature
    {
        private readonly Helper helper;
        public event Action<ValueType> Changed;

        public double Data
        {
            get
            {
                return TemperatureSensor.Data;
            }
        }

        public Temperature()
        {
            helper = new Helper();
            helper.Poll(() => TemperatureSensor.Data, TemperatureChanged);
        }

        private void TemperatureChanged(ValueType data)
        {
            Changed?.Invoke(data);
        }
    }
}
