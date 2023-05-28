using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace iXtensions.Extensions
{
    public static class StringExtension
    {
        public static int ToInteger(this string Value)
            => Convert.ToInt32(Value);



        public static string RemoveLast(this string Value, int removeLength = 1)
            => String.IsNullOrEmpty(Value) ? "" : Value.Remove(Value.Length - removeLength);


        public static string RemoveLastIfValuesIs(this string values, int removeLength, string valueToVerifyAndRemove)
        {
            if (values.Length < removeLength) return values;
            string x = values.Substring(values.Length - removeLength, removeLength);
            if (x == valueToVerifyAndRemove)
                return values.Remove(values.Length - removeLength);
            return values;
        }

        public static bool LastLenghtIs(this string value, string compare)
            => value == null ? false : value.Substring(value.Length - compare.Length, compare.Length) == compare;



        public static bool MultContains(this string valueToVerify, params string[] values)
        {
            int r = 0;
            foreach (string i in values)
                if (valueToVerify.Contains(i))
                    r++;
            return r >= 1;
        }



        public static string ToFirstUpper(this string value)
            => char.ToUpper(value[0]) + value.Substring(1);

        public static string ToCamelCase(this string value)
        {
            string[] words = value.Split(' ');

            for (int i = 1; i < words.Length; i++)
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            return string.Join("", words);
        }

   
        public static string FirstLetter(this string Value, int ToSize = 1, string returnWith = "")
            => !string.IsNullOrEmpty(Value) && Value.Length >= 1 && Value.Length > ToSize ? Value.Substring(0, ToSize) + returnWith : Value;


        public static bool LengthRange(this string Value, int start, int end)
            => Value.Length >= start && Value.Length <= end;

        public static bool isInt(this string Value)
            => Int32.TryParse(Value, out _);

        public static bool isNumberPhone(this string Value)
        {
            try
            {
                string r = Value.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace(".", "");
                if (r.isInt() & r.LengthRange(9, 11)) return true; else return false;
            }
            catch (System.Exception) { return false; }
        }

        public static string VerifyElseReturn(this string Value, string Return, params string[] Verify)
        {
            foreach (string i in Verify)
                if (Value.ToLower() == i.ToLower()) return i;
            return Return;
        }

        public static string IfNullThenReturn(this string Value, string Return)
            => String.IsNullOrEmpty(Value) ? Return : Value;


        public static string RemoveWhiteSpace(this string Value, params string[] ValuesToReplace)
        {
            foreach (var i in ValuesToReplace) Value = Value.Replace(i, "");
            return Value;
        }

        public static bool isSecurity(this string value)
            => String.IsNullOrWhiteSpace(value) ? true : (value.MultContains("<", ">", "javascript", "onchange", "onclick") ? false : true);



        /// <summary>
        /// Valida uma string de inteiros separados por virgula, ex.: 1,2,3,4, verifica se todos são numeros validos
        /// </summary>
        /// <param name="value"></param>
        /// <param name="saida"></param>
        /// <returns></returns>
        public static bool isValidIntCsv(this string value)
        {
            int invalidNumbers = 0;
            string[] splitado = value.Split(',');
            foreach (var i in splitado)
            {
                int saida = 0;
                bool validNumber = int.TryParse(i, out saida);
                if (!validNumber) invalidNumbers++;
            }
            return invalidNumbers >= 1 ? false : true;
        }

        public static int[] ConvertCsvIntInArray(string value)
        {
            string[] splitado = value.Split(',');
            int[] data = new int[splitado.Length];
            for (int i = 0; i < splitado.Length; i++)
            {
                int num = 0;
                bool validNum = int.TryParse(splitado[i], out num);
                if (validNum) data[i] = num;
                else throw new System.Exception($"Erro ao converter {splitado[i]} em int");
            }
            return data;
        }


        public static string ToMoney(this string Value)
        {
            try
            {
                return Convert.ToDouble(Value).ToString("N2");
            }
            catch (System.Exception) { return "N/A"; }
        }


        public static T ToEnum<T>(this string value)
            => (T)Enum.Parse(typeof(T), value, true);

        public static string SpaceCapitalLetter(this string value)
         => System.Text.RegularExpressions.Regex.Replace(value, "[A-Z]", " $0");


        public static int[] CsvToIntArray(this string value)
           => value.Split(',').Select(x => int.Parse(x)).ToArray();


        public static string RemoveAccent(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }


    }
}
