using System;
using System.Numerics;

//Needs to add a reference to the Assembly System.Numerics
namespace Rationals
{
    internal struct Rational
    {
        public int Numerator { get; private set; }
        public int Denomirator { get; private set; }
        public double Value => (double)Numerator / Denomirator;
        public Rational(int numerator)
        {
            Numerator = numerator;
            Denomirator = 1;
        }
        public Rational(int numerator, int denomirator)
        {
            try
            {
                CheckDenomirator(denomirator);
                Numerator = numerator;
                Denomirator = denomirator;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Numerator = numerator;
                Denomirator = 1;
            }  
        }

        private static void CheckDenomirator(int denomirator)
        {
            if (denomirator == 0)
            {
                throw new ArgumentException("ArgumentException: Can not be zero.", nameof(denomirator));
            }
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            if (r1.Denomirator == r2.Denomirator)
            {
                var newRational = new Rational(r1.Numerator + r2.Numerator, r1.Denomirator);
                return newRational;
            }
            else
            {
                var denomirator = r1.Denomirator * r2.Denomirator;
                var newRational = new Rational((denomirator / r2.Denomirator) * r2.Numerator + (denomirator / r1.Denomirator) * r1.Numerator, denomirator);
                return newRational;
            }
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            if (r1.Denomirator == r2.Denomirator)
            {
                var newRational = new Rational(r1.Numerator - r2.Numerator, r1.Denomirator);
                return newRational;
            }
            else
            {
                var denomirator = r1.Denomirator * r2.Denomirator;
                var newRational = new Rational((denomirator / r2.Denomirator) * r2.Numerator - (denomirator / r1.Denomirator) * r1.Numerator, denomirator);
                return newRational;
            }
        }
        public static Rational operator *(Rational r1, Rational r2)
        {
            var newRational = new Rational(r1.Numerator * r2.Numerator, r1.Denomirator * r2.Denomirator);
            return newRational;
        }
        public static Rational operator /(Rational r1, Rational r2)
        {
            var newRational = new Rational(r1.Numerator * r2.Denomirator, r1.Denomirator * r2.Numerator);
            return newRational;
        }
        public static implicit operator double(Rational r)
        {
            return r.Value;
        }
        public static explicit operator Rational(int num)
        {
            return new Rational(num);
        }
        public override string ToString()
        {
            return $"{Numerator}/{Denomirator}";
        }
        public void Reduce()
        {
            var numerator = Numerator;
            if (Numerator != 0)
            {
                Numerator /= (int)BigInteger.GreatestCommonDivisor(Numerator, Denomirator);
            }
            if (Denomirator != 0)
            {
                Denomirator /= (int)BigInteger.GreatestCommonDivisor(numerator, Denomirator);
            }
        }
    }
}