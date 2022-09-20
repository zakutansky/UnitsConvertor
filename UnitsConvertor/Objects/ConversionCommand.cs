using UnitsConvertor.Enums;
using UnitsConvertor.Objects;

namespace UnitsConvertor.Data
{
    internal class ConversionCommand
    {
        public double Value { get; set; }

        public Measure From { get; set; }

        public Measure To { get; set; }
    }
}
