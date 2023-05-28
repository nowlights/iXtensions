using System;
using System.Globalization;

namespace iXtensions.Extensions
{
    public static class IntExtension
    {
        public static string NomeDoMes(this int Value)
        {
            //string fullMonthName = new DateTime(DateTime.Now.Year, Value, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("pt_BR"));
            string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Value);
            monthName = monthName.ToFirstUpper();
            return monthName;
        }

        public static string GetMonthName(this int Month)
            => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month).ToFirstUpper();



        private static readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

        public static string FormatSize(this Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1} {1}", number, suffixes[counter]);
        }


        /// <summary>
        /// Get a bool if number x is divisible by a number N for example:
        /// x = 1 : n = 4 ? 1 is divisible by 4? False
        /// x = 2 : n = 4 ? 2 is divisible by 4? False
        /// x = 4 : n = 4 ? 4 is divisible by 4? True
        /// x = 12 : n = 4 ? 12 is divisible by 4? True ...
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns>Return a bool is x is divisible for a N</returns>
        public static bool IsDisivisible(int x, int n)
            => (x % n) == 0;




    }
}