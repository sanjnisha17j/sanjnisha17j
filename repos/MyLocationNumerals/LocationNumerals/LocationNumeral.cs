using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLocationNumerals
{
    public class LocationNumeral
    {
        private Dictionary<string, long> locationNumerals = new Dictionary<string,long>();
        public LocationNumeral()
        {
            locationNumerals = PopulateLocationNumerals();
        }

        private Dictionary<string, long> PopulateLocationNumerals()
        {
            int value = 2;
            for (int power = 0; power <= 32; power++)
                Console.WriteLine($"{value}^{power} = {(long)Math.Pow(value, power):N0} (0x{(long)Math.Pow(value, power):X})");
            int count = 0;
            for (char alphabet = 'a'; alphabet <= 'z'; alphabet++)
            {
                locationNumerals.Add(alphabet.ToString(), (long)Math.Pow(value, count));
                count++;
            }
            return locationNumerals;
        }

        public string GetLocationNumeralsForNumber(long num)
        {
            string binaryForm = LocationNumeralUtils.getBinaryRepresentation(num);
            int count = binaryForm.Length -1;
            long numeral;
            StringBuilder locationNumeral = new StringBuilder();
            foreach (char c in binaryForm)
            {
                if (c.Equals('1'))
                {
                    numeral = (long)Math.Pow(2, count);
                    var matchKey = locationNumerals.FirstOrDefault(x => x.Value.Equals(numeral)).Key;
                    locationNumeral.Append(matchKey.ToString());
                }
                count--;
            }
            return LocationNumeralUtils.ReverseString(locationNumeral.ToString());
        }

        public long getNumberfromLocationNumerals(string lNumeral)
        {
            long number = 0;
            foreach (char c in lNumeral)
            {
                var value = locationNumerals.FirstOrDefault(x => x.Key.Equals(c.ToString())).Value;
                number += value;
            }
            return number;

        }

        public string getAbbreviatedForm(string lNumeral)
        {
            long number = getNumberfromLocationNumerals(lNumeral);
            return GetLocationNumeralsForNumber(number);

        }
    }
}
