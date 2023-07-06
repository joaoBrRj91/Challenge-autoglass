using System;
namespace ClallangeAutoGlass.Business.Validations.Documents
{
	public static class Utils
	{
        public static string OnlyNumbers(string value)
        {
            var onlyNumber = "";
            foreach (var s in value)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }

        public static bool IsLengthValid(string value, int targetLength)
        {
            return value.Length == targetLength;
        }
    }
}

