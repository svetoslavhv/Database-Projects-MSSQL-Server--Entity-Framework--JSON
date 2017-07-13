﻿namespace CompanySampleDataImporter.Importer
{
    using System;
    using System.Text;
    public static class RandomGenerator
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        private static Random random = new Random();

        public static int GetRandomNumber(int min = 0, int max = int.MaxValue / 2)
        {
            return random.Next(min, max + 1);
        }

        public static string GetRandomString(int minLength = 0, int maxLength = int.MaxValue / 2 )
        {
            var length = random.Next(minLength, maxLength);
            var result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                var currentRandomSymbol = Alphabet[random.Next(0, Alphabet.Length - 1)];
                result.Append(currentRandomSymbol);
            }

            return result.ToString();
        }

        public static DateTime GetRandomDate(DateTime? after = null, DateTime? before = null)
        {
            var minDate = after ?? new DateTime(1990, 1, 1, 0, 0, 0);
            var maxDate = before ?? new DateTime(2050, 12, 31, 23, 59, 59);

            var seconds = GetRandomNumber(minDate.Second, maxDate.Second);
            var minutes = GetRandomNumber(minDate.Minute, maxDate.Minute);
            var hours = GetRandomNumber(minDate.Hour, maxDate.Hour);
            var day = GetRandomNumber(minDate.Day, maxDate.Day);
            var month = GetRandomNumber(minDate.Month, maxDate.Month);
            var year = GetRandomNumber(minDate.Year, maxDate.Year);

            if (day > 28)
            {
                day = 28;
            }

            return new DateTime(year, month, day, hours, minutes, seconds);
        }
    }
}
