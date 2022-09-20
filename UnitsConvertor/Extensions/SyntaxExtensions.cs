using UnitsConvertor.Attributes;
using UnitsConvertor.Enums;

namespace UnitsConvertor.Extensions
{
    internal static class SyntaxExtensions
    {
        public static string GetSymbol(this SiPrefixes prefix)
        {
            return SymbolAttribute.GetSymbol(prefix);
        }

        public static string GetSymbol(this MeasureTypes mt)
        {
            return SymbolAttribute.GetSymbol(mt);
        }
    }
}
