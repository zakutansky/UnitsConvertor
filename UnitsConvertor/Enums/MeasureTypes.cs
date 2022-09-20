using UnitsConvertor.Attributes;

namespace UnitsConvertor
{
    public enum MeasureTypes
    {
        [Symbol("m")]
        Meter,
        [Symbol("ft")]
        Foot,
        [Symbol("inch")]
        Inch,
        [Symbol("B")]
        Byte,
        [Symbol("b")]
        Bit,
        [Symbol("C")]
        Celsius,
        [Symbol("F")]
        Fahrenheit
    }
}
