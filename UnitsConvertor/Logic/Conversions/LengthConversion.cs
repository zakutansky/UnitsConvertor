namespace UnitsConvertor.Logic.Conversions
{
    internal class LengthConversion : ConversionBase
    {
        protected override double Convert(double value, MeasureTypes from, MeasureTypes to)
        {
            if (from == MeasureTypes.Meter && to == MeasureTypes.Foot)
            {
                return value * 3.281;
            }

            if (from == MeasureTypes.Foot && to == MeasureTypes.Meter)
            {
                return value / 3.281;
            }

            if (from == MeasureTypes.Meter && to == MeasureTypes.Inch)
            {
                return value * 39.37;
            }

            if (from == MeasureTypes.Inch && to == MeasureTypes.Meter)
            {
                return value / 39.37;
            }

            if (from == MeasureTypes.Foot && to == MeasureTypes.Inch)
            {
                return value * 12;
            }

            if (from == MeasureTypes.Inch && to == MeasureTypes.Foot)
            {
                return value / 12;
            }

            if ((from == MeasureTypes.Meter && to == MeasureTypes.Meter) 
                || (from == MeasureTypes.Foot && to == MeasureTypes.Foot)
                || (from == MeasureTypes.Inch && to == MeasureTypes.Inch))
            {
                return value;
            }

            return default;
        }
    }
}
