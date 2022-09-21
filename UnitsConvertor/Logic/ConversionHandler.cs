using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitsConvertor.Data;
using UnitsConvertor.Enums;
using UnitsConvertor.Extensions;
using UnitsConvertor.Logic.Conversions;
using UnitsConvertor.Objects;

namespace UnitsConvertor.InputHanlding
{
    public class ConversionHandler
    {
        private readonly Dictionary<List<Units>, Type> _conversionMapping = new Dictionary<List<Units>, Type>()
        {
            { new List<Units> {Units.Meter, Units.Foot, Units.Inch }, typeof(LengthConversion) },
            { new List<Units> {Units.Byte, Units.Bit }, typeof(DataConversion) },
            { new List<Units> {Units.Celsius, Units.Fahrenheit }, typeof(TemperatureConversion) },
        };

        private ConversionBase _conversion;

        private readonly IEnumerable<Units> _units;

        private readonly IEnumerable<SiPrefixes> _prefixes;

        public ConversionHandler()
        {
            _units = Enum.GetValues(typeof(Units)).OfType<Units>();
            _prefixes = Enum.GetValues(typeof(SiPrefixes)).OfType<SiPrefixes>();
        }

        /// <summary>
        /// Convert quantities between different units.
        /// Exmaple format: 3 GB b
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Convert(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            var cmd = ValidateInput(input.Trim());
            var result = _conversion?.Convert(cmd);

            return $"{result} {cmd.To}";
        }

        /// <summary>
        /// Returns symbols for units and prefixes.
        /// </summary>
        /// <returns></returns>
        public string Help()
        {
            var result = new StringBuilder();

            foreach (var mt in _units)
            {
                result.AppendLine($"{mt} - {mt.GetSymbol()}");
            }

            result.AppendLine();

            foreach (var p in _prefixes)
            {
                result.AppendLine($"{p} - {p.GetSymbol()}");
            }

            return result.ToString();
        }

        private ConversionCommand ValidateInput(string input)
        {
            var cmd = new ConversionCommand();

            var parts = input.Split(' ');

            if (parts.Count() != 3)
                throw new Exception("Wrong input format");

            if (! double.TryParse(parts[0], out double value))
                throw new Exception("Wrong input format");

            cmd.Value = value;
            cmd.From = GetMeasure(parts[1]);
            cmd.To = GetMeasure(parts[2]);

            if(cmd.From.Unit == null || cmd.To.Unit == null)
                throw new Exception("Wrong input format");

            bool isConversionValid = false;

            foreach (var cm in _conversionMapping)
            {
                if (cm.Key.Contains(cmd.From.Unit.Value) && cm.Key.Contains(cmd.To.Unit.Value))
                {
                    isConversionValid = true;
                    _conversion = (ConversionBase) Activator.CreateInstance(cm.Value);
                    break;
                }
            }

            if(!isConversionValid)
                throw new Exception("Wrong input format");

            return cmd;
        }

        private ConversionUnit GetMeasure(string input)
        {
            var measure = new ConversionUnit();

            foreach (var mt in _units)
            {
                var mtSymbol = mt.GetSymbol();

                if (input.EndsWith(mtSymbol))
                {
                    input = input.Substring(0, input.LastIndexOf(mtSymbol));
                    measure.Unit = mt;
                    break;
                }
            }

            if (input.Length > 0)
            {
                foreach (var p in _prefixes)
                {
                    var prefix = p.GetSymbol();

                    if (input.StartsWith(prefix))
                    {
                        measure.Prefix = p;
                        break;
                    }
                }
            }

            return measure;
        }
    }
}
