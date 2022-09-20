namespace UnitsConvertor.Logic.Conversions
{
    internal class TemperatureConversion : ConversionBase
    {
        protected override double Convert(double value, Units from, Units to)
        {
            if (from == Units.Celsius && to == Units.Fahrenheit)
            {
                return (value * 9 / 5) + 32;
            }

            if (from == Units.Fahrenheit && to == Units.Celsius)
            {
                return ((value - 32) * 5) / 9;
            }

            if ((from == Units.Fahrenheit && to == Units.Fahrenheit) || (from == Units.Celsius && to == Units.Celsius))
            {
                return value;
            }

            return default;
        }
    }
}
