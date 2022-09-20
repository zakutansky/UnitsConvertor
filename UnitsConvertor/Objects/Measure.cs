using UnitsConvertor.Enums;
using UnitsConvertor.Extensions;

namespace UnitsConvertor.Objects
{
    internal class Measure
    {
        public Units? Unit { get; set; }

        public SiPrefixes? Prefix { get; set; }

        public override string ToString()
        {
            var result = string.Empty;

            if (Prefix != null) result = Prefix.Value.GetSymbol();
            if (Unit != null) result += Unit.Value.GetSymbol();

            return result;
        }
    }
}
