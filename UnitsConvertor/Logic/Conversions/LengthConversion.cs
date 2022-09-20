namespace UnitsConvertor.Logic.Conversions
{
    internal class LengthConversion : ConversionBase
    {
        protected override double Convert(double value, Units from, Units to)
        {
            if (from == Units.Meter && to == Units.Foot)
            {
                return value * 3.281;
            }

            if (from == Units.Foot && to == Units.Meter)
            {
                return value / 3.281;
            }

            if (from == Units.Meter && to == Units.Inch)
            {
                return value * 39.37;
            }

            if (from == Units.Inch && to == Units.Meter)
            {
                return value / 39.37;
            }

            if (from == Units.Foot && to == Units.Inch)
            {
                return value * 12;
            }

            if (from == Units.Inch && to == Units.Foot)
            {
                return value / 12;
            }

            if ((from == Units.Meter && to == Units.Meter) 
                || (from == Units.Foot && to == Units.Foot)
                || (from == Units.Inch && to == Units.Inch))
            {
                return value;
            }

            return default;
        }
    }
}
