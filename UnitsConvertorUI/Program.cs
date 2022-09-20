using UnitsConvertor.InputHanlding;

namespace UnitsConvertorUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ch = new ConversionHandler();
            Console.WriteLine(ch.Help());
            Console.WriteLine("Use shortcuts for converion");
            Console.WriteLine("Example: 35 MB Gb");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.Write("Input: ");
                    var input = Console.ReadLine();
                    var result = ch.Convert(input);
                    Console.WriteLine(result);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}