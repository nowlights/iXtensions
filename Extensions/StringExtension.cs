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


        public static string RemoveLastIfValuesIs(this string values, int removeLength, string ValueToVerifyAndRemove)
        {
            if (values.Length < removeLength) return values;
            string x = values.Substring(values.Length - removeLength, removeLength);
            if (x == ValueToVerifyAndRemove)
                return values.Remove(values.Length - removeLength);
            return values;
        }


        public static bool EqualList(this string ValorVerify, params string[] Value)
        {
            int r = 0;
            foreach (var i in Value)
                if (i == ValorVerify)
                    r++;
            return r >= 1;
        }

        public static bool MultContains(this string ValorVerify, params string[] Value)
        {
            int r = 0;
            foreach (string i in Value)
                if (ValorVerify.Contains(i))
                    r++;
            return r >= 1;
        }


        public static string ToUpperIfNotNull(this string value)
            => String.IsNullOrEmpty(value) ? value : value.ToUpper();



        public static string ToFirstUpper(this string value)
            => char.ToUpper(value[0]) + value.Substring(1);


        public static string FirstLetter(this string Value, int ToSize = 1, string returnWith = "")
            => !String.IsNullOrEmpty(Value) && Value.Length >= 1 && Value.Length > ToSize ? Value.Substring(0, ToSize) + returnWith : Value;


        public static bool LengthRange(this string Value, int start, int end)
            => Value.Length >= start && Value.Length <= end;

        public static bool isInt(this string Value)
        {
            try { Convert.ToDouble(Value); return true; }
            catch (System.Exception) { return false; }
        }

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



        public static string ReplaceToEmpty(this string Value, params string[] ValuesToReplace)
        {
            foreach (var i in ValuesToReplace) Value = Value.Replace(i, "");
            return Value;
        }

        public static bool isSecurity(this string value)
            => String.IsNullOrWhiteSpace(value) ? true : (value.MultContains("<", ">", "javascript", "onchange", "onclick") ? false : true);


        public static bool ContainsStringInListString(List<string> listValue, string value)
        {
            foreach (var i in listValue)
                if (i == value)
                    return true;

            return false;
        }

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
