using System;
using System.Collections.Generic;

namespace Rationals
{
    internal class Program
    {
        internal static void Main()
        {
            var rationalArr = new Rational[7];

            rationalArr[0] = new Rational(80, 256);
            rationalArr[1] = new Rational(80, 256);
            rationalArr[2] = new Rational();
            rationalArr[3] = new Rational();
            rationalArr[4] = new Rational();
            rationalArr[5] = new Rational();
            rationalArr[6] = new Rational();


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

            Console.WriteLine("After Reduce:");
            DisplayArr(rationalArr);

            Console.WriteLine("Using the implicit to double casting operator:");
            var number1 = (double) rationalArr[0];
            Console.WriteLine($"{rationalArr[0]} => {number1}");
            Console.WriteLine();

            Console.WriteLine("Using the explicit from int casting operator:");
            var r = (Rational) 8;
            Console.WriteLine($"8 => {r}");
            Console.WriteLine();

            Console.WriteLine("Avoiding Divide by zero Exception:");
            Console.WriteLine();
            //Catching Exception, rationalArr[3] = 0
            rationalArr[6] = rationalArr[0] / rationalArr[3];
        }

        private static void DisplayArr(IReadOnlyList<Rational> rationalArr)
        {
            Console.WriteLine(rationalArr[0] + " + " + rationalArr[1] + " = " + rationalArr[2] + " = " + rationalArr[2].Value);
            Console.WriteLine(rationalArr[0] + " - " + rationalArr[1] + " = " + rationalArr[3] + " = " + rationalArr[3].Value);
            Console.WriteLine(rationalArr[0] + " * " + rationalArr[1] + " = " + rationalArr[4] + " = " + rationalArr[4].Value);
            Console.WriteLine(rationalArr[0] + " / " + rationalArr[1] + " = " + rationalArr[5] + " = " + rationalArr[5].Value);
            Console.WriteLine();
        }
    }
}
