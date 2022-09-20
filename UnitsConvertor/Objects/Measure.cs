using UnitsConvertor.Enums;
using UnitsConvertor.Extensions;

namespace UnitsConvertor.Objects
{
    internal class Measure
    {
        public MeasureTypes? Type { get; set; }

        public SiPrefixes? Prefix { get; set; }

        public override string ToString()
        {
            var result = string.Empty;

            if (Prefix != null) result = Prefix.Value.GetSymbol();
            if (Type != null) result += Type.Value.GetSymbol();

            return result;
        }
    }
}
