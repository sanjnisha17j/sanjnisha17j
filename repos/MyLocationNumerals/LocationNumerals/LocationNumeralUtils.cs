using System;
using System.Collections.Generic;
using System.Text;

namespace MyLocationNumerals
{
    public static class LocationNumeralUtils
    {
        public static string getBinaryRepresentation(long num)
        {
            string result;
            result = "";
            while (num > 1)
            {
                int remainder = (int)(num % 2);
                result = Convert.ToString(remainder) + result;
                num /= 2;
            }
            result = Convert.ToString(num) + result;
            return result;
        }

        public static string ReverseString(string myStr)
        {
            char[] myArr = myStr.ToCharArray();
            Array.Reverse(myArr);
            return new string(myArr);
        }


    }
}
