using System;
using System.Collections.Generic;
using UnitsConvertor.Data;
using UnitsConvertor.Enums;

namespace UnitsConvertor.Logic.Conversions
{
    internal abstract class ConversionBase
    {
        private static Dictionary<SiPrefixes, double> _siPrefixes = new Dictionary<SiPrefixes, double>()
        {
              { SiPrefixes.Yotta , Math.Pow(10,24) },
              { SiPrefixes.Zetta , Math.Pow(10,21) },
              { SiPrefixes.Exa , Math.Pow(10,18) },
              { SiPrefixes.Peta, Math.Pow(10,15) },
              { SiPrefixes.Tera, Math.Pow(10,12) },
              { SiPrefixes.Giga, Math.Pow(10,9) },
              { SiPrefixes.Mega, Math.Pow(10,6) },
              { SiPrefixes.Kilo, Math.Pow(10,3) },
              { SiPrefixes.Hecto, Math.Pow(10,2) },
              { SiPrefixes.Deca, Math.Pow(10,1) },
              { SiPrefixes.Deci, Math.Pow(10,-1) },
              { SiPrefixes.Centi, Math.Pow(10,-2) },
              { SiPrefixes.Milli, Math.Pow(10,-3) },
              { SiPrefixes.Micro, Math.Pow(10,-6) },
              { SiPrefixes.Nano, Math.Pow(10,-9)},
              { SiPrefixes.Pico, Math.Pow(10,-12) },
              { SiPrefixes.Femto, Math.Pow(10,-15) },
              { SiPrefixes.Atto, Math.Pow(10,-18) },
              { SiPrefixes.Zepto, Math.Pow(10,-21) },
              { SiPrefixes.Yocto, Math.Pow(10,-24) }
        };

        protected abstract double Convert(double value, MeasureTypes from, MeasureTypes to);

        internal double Convert(ConversionCommand cmd)
        {
            if (cmd?.To?.Type == null | cmd?.From?.Type == null) return default;

            double finalPrefix = 1;

            if(cmd.From.Prefix != null)
            {
                if (_siPrefixes.TryGetValue(cmd.From.Prefix.Value, out double prefixFromValue))
                {
                    finalPrefix = prefixFromValue;
                }
            }

            if (cmd.To.Prefix != null)
            {
                if (_siPrefixes.TryGetValue(cmd.To.Prefix.Value, out double prefixToValue))
                {
                    finalPrefix /= prefixToValue;
                }
            }

            var result = Convert(cmd.Value, cmd.From.Type.Value, cmd.To.Type.Value) * finalPrefix;

            return result;
        }
    }
}
