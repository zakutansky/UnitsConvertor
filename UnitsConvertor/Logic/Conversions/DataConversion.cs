namespace UnitsConvertor.Logic.Conversions
{
    internal class DataConversion : ConversionBase
    {
        protected override double Convert(double value, Units from, Units to)
        {
            if(from == Units.Byte && to == Units.Bit)
            {
                return value * 8;
            }

            if (from == Units.Bit && to == Units.Byte)
            {
                return value / 8;
            }

            if ((from == Units.Bit && to == Units.Bit) || (from == Units.Byte && to == Units.Byte))
            {
                return value;
            }

            return default;
        }
    }
}
