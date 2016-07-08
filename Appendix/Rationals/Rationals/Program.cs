using System;

namespace Rationals
{
    internal class Program
    {
        internal static void Main()
        {
            var rationalArr = new[]
            {
                new Rational(6, 32),
                new Rational(2, 12),
                new Rational(),
                new Rational(),
                new Rational(),
                new Rational()
            };

            rationalArr[2] = rationalArr[0] + rationalArr[1];
            rationalArr[3] = rationalArr[0] - rationalArr[1];
            rationalArr[4] = rationalArr[0] * rationalArr[1];
            rationalArr[5] = rationalArr[0] / rationalArr[1];

            Console.WriteLine("Before Reduce:");
            DisplayArr(rationalArr);

            for (var i = 0; i < rationalArr.Length; ++i)
            {
                rationalArr[i].Reduce();
            }

            Console.WriteLine();
            Console.WriteLine("After Reduce:");
            DisplayArr(rationalArr);

            Console.WriteLine();

            Console.WriteLine("Using the implicit to double casting operator:");
            var number1 = (double) rationalArr[0];
            Console.WriteLine($"{rationalArr[0].ToString()} => {number1}");

            Console.WriteLine();

            Console.WriteLine("Using the explicit from int casting operator:");
            var r = (Rational) 8;
            Console.WriteLine($"8 => {r.ToString()}");
        }

        private static void DisplayArr(Rational[] rationalArr)
        {
            Console.WriteLine(rationalArr[0].ToString() + " + " + rationalArr[1].ToString() + " = " + rationalArr[2].ToString() + " = " + rationalArr[2].Value);
            Console.WriteLine(rationalArr[0].ToString() + " - " + rationalArr[1].ToString() + " = " + rationalArr[3].ToString() + " = " + rationalArr[3].Value);
            Console.WriteLine(rationalArr[0].ToString() + " * " + rationalArr[1].ToString() + " = " + rationalArr[4].ToString() + " = " + rationalArr[4].Value);
            Console.WriteLine(rationalArr[0].ToString() + " / " + rationalArr[1].ToString() + " = " + rationalArr[5].ToString() + " = " + rationalArr[5].Value);
        }
    }
}
