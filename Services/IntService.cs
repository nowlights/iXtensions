namespace iXtensions.Services
{
    public class IntService
    {

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
