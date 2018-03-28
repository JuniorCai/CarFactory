using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarFactory.Admin.Helpers
{
    public class SerialNumberHelpers
    {
        private static int _minValue = 111111;
        private static int _maxValue = 999999;

        public static int GenerateSerialNumber()
        {
            Random serialRandom = new Random();
            return serialRandom.Next(_minValue, _maxValue);
        }
    }
}