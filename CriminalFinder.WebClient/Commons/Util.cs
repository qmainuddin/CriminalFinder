using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriminalFinder.WebClient.Commons
{
    public class Util
    {
        public static int toInt(String number)
        {
            int resultNumber = 0;
            int modValue = 1;
            int len = number.Length;
            for(int i =0; i<len; i++)
            {
                resultNumber = (resultNumber* modValue) + number[i] - '0';
                modValue *= 10;
            }
            return resultNumber;
        }
    }
}