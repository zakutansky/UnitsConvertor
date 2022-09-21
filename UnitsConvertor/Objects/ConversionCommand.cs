using UnitsConvertor.Enums;
using UnitsConvertor.Objects;

namespace UnitsConvertor.Data
{
    internal class ConversionCommand
    {
        public double Value { get; set; }

        public ConversionUnit From { get; set; }

        public ConversionUnit To { get; set; }
    }
}
