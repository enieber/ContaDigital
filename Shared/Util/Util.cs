using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Util
{
    public static class Util
    {
        public static string GenerateRadon(int key)
        {
            Random rd = new();
                const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
                char[] chars = new char[key];

                for (int i = 0; i < key; i++)
                {
                    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                }

                return new string(chars);
        }


        public static string DoubleSetValue(string value)
        {
            var arrValue = value.Split(",");
           
            string vInt, vDec, _value;

            if (arrValue.Length > 1)
            {
                vInt = arrValue[0];
                vDec = arrValue[1];
                _value = vInt + "." + vDec;
            }
            else
                _value = value;

            return _value;
        }
	}
}
