using System;

namespace MyLocationNumerals
{
    class Program
    {

        static void Main(string[] args)
        {
            LocationNumeral lnumeral = new LocationNumeral();

            Console.WriteLine("Input number to convert to location Numeral");
            long number = Convert.ToInt64(Console.ReadLine());

            String location = lnumeral.GetLocationNumeralsForNumber(number);

            Console.WriteLine("Location: " + location);

            Console.WriteLine("Input location numeral to convert to number");
            string locNum = Console.ReadLine().Trim();

            long numberForLocNum = lnumeral.getNumberfromLocationNumerals(locNum);

            Console.WriteLine("Number : " + numberForLocNum);

            Console.WriteLine("Input location numeral to convert to abbreviated");
            string locNumber = Console.ReadLine().Trim();

            string abbrLocNumber = lnumeral.getAbbreviatedForm(locNumber);

            Console.WriteLine("Abbreviated Location Numeral : " + abbrLocNumber);

            Console.ReadLine();


        }
    }
}
