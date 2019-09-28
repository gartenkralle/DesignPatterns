using System;
using System.ComponentModel;

namespace WeaterStation.Model
{
    public class Humidity
    {
        private readonly Helper helper;

        public event Action<ValueType> Changed;

        public double Data
        {
            get
            {
                return HumiditySensor.Data;
            }
        }

        public Humidity()
        {
            helper = new Helper();
            helper.Poll(() => HumiditySensor.Data, Humidity_Changed);
        }

        private void Humidity_Changed(ValueType data)
        {
            Changed?.Invoke(data);
        }
    }
}
