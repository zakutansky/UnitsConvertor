namespace UnitsConvertor.Logic.Conversions
{
    internal class TemperatureConversion : ConversionBase
    {
        protected override double Convert(double value, MeasureTypes from, MeasureTypes to)
        {
            if (from == MeasureTypes.Celsius && to == MeasureTypes.Fahrenheit)
            {
                return (value * 9 / 5) + 32;
            }

            if (from == MeasureTypes.Fahrenheit && to == MeasureTypes.Celsius)
            {
                return ((value - 32) * 5) / 9;
            }

            if ((from == MeasureTypes.Fahrenheit && to == MeasureTypes.Fahrenheit) || (from == MeasureTypes.Celsius && to == MeasureTypes.Celsius))
            {
                return value;
            }

            return default;
        }
    }
}
