using System;
using System.ComponentModel;

namespace WeaterStation.Model
{
    public class Pressure
    {
        private readonly Helper helper;
        public event Action<ValueType> Changed;

        public double Data
        {
            get
            {
                return PressureSensor.Data;
            }
        }

        public Pressure()
        {
            helper = new Helper();
            helper.Poll(() => PressureSensor.Data, PressureChanged);
        }

        private void PressureChanged(ValueType data)
        {
            Changed?.Invoke(data);
        }
    }
}
