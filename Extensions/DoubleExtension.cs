using System;

namespace iXtensions.Extensions
{
    public static class DoubleExtension
    {
         /// <summary>
        /// Always round to the nearest / Arredonda sempre para o proximo
        /// </summary>
        public static double ToMathRound(this double Value)
            => Math.Round(Value);


        /// <summary>
        /// Always round down / Arredonda sempre para baixo
        /// </summary>
        public static double ToMathFloor(this double Value)
            => Math.Floor(Value);


        /// <summary>
        /// Always round up / Arredonda sempre para cima
        /// </summary>
        public static double ToMathCeiling(this double Value)
            => Math.Ceiling(Value);
    }
}
