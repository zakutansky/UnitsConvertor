namespace UnitsConvertor.Logic.Conversions
{
    internal class DataConversion : ConversionBase
    {
        protected override double Convert(double value, MeasureTypes from, MeasureTypes to)
        {
            if(from == MeasureTypes.Byte && to == MeasureTypes.Bit)
            {
                return value * 8;
            }

            if (from == MeasureTypes.Bit && to == MeasureTypes.Byte)
            {
                return value / 8;
            }

            if ((from == MeasureTypes.Bit && to == MeasureTypes.Bit) || (from == MeasureTypes.Byte && to == MeasureTypes.Byte))
            {
                return value;
            }

            return default;
        }
    }
}
