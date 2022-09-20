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
        private readonly Dictionary<List<MeasureTypes>, Type> _conversionMapping = new Dictionary<List<MeasureTypes>, Type>()
        {
            { new List<MeasureTypes> {MeasureTypes.Meter, MeasureTypes.Foot, MeasureTypes.Inch }, typeof(LengthConversion) },
            { new List<MeasureTypes> {MeasureTypes.Byte, MeasureTypes.Bit }, typeof(DataConversion) },
            { new List<MeasureTypes> {MeasureTypes.Celsius, MeasureTypes.Fahrenheit }, typeof(TemperatureConversion) },
        };

        private ConversionBase _conversion;

        private readonly IEnumerable<MeasureTypes> _measureTypes;

        private readonly IEnumerable<SiPrefixes> _prefixes;

        public ConversionHandler()
        {
            _measureTypes = Enum.GetValues(typeof(MeasureTypes)).OfType<MeasureTypes>();
            _prefixes = Enum.GetValues(typeof(SiPrefixes)).OfType<SiPrefixes>();
        }

        /// <summary>
        /// Converts units between different kinds of measure types.
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
        /// Returns symbols for measure types and prefixes.
        /// </summary>
        /// <returns></returns>
        public string Help()
        {
            var result = new StringBuilder();

            foreach (var mt in _measureTypes)
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

            if(cmd.From.Type == null || cmd.To.Type == null)
                throw new Exception("Wrong input format");

            bool isConversionValid = false;

            foreach (var cm in _conversionMapping)
            {
                if (cm.Key.Contains(cmd.From.Type.Value) && cm.Key.Contains(cmd.To.Type.Value))
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

        private Measure GetMeasure(string input)
        {
            var measure = new Measure();

            foreach (var mt in _measureTypes)
            {
                var mtSymbol = mt.GetSymbol();

                if (input.EndsWith(mtSymbol))
                {
                    input = input.Substring(0, input.LastIndexOf(mtSymbol));
                    measure.Type = mt;
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
