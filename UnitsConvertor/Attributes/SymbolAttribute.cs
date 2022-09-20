using System;
using System.Linq;
using UnitsConvertor.Helpers;

namespace UnitsConvertor.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class SymbolAttribute : Attribute
    {
        public SymbolAttribute(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; set; }

        public static string GetSymbol(object field)
        {
            var attr = AttributeHelpers.GetAttributesOfField<SymbolAttribute>(field).SingleOrDefault();
            if (attr != null)
            {
                return attr.Symbol;
            }

            return null;
        }
    }
}
