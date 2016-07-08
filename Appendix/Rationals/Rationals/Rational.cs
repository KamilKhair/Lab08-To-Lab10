namespace Rationals
{
    internal struct Rational
    {
        public Rational(int numerator, int denomirator)
        {
            Numerator = numerator;
            Denomirator = denomirator == 0 ? 1 : denomirator;
        }

        public Rational(int numerator)
        {
            Numerator = numerator;
            Denomirator = 1;
        }
        public int Numerator { get; private set; }

        public int Denomirator { get; private set; }

        public double Value => (double)Numerator / Denomirator;

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
            return Numerator + "/" + Denomirator;
        }


        public void Reduce()
        {
            var numerator = Numerator;
            Numerator /= Gcd(Numerator, Denomirator);
            Denomirator /= Gcd(numerator, Denomirator);
        }

        private static int Gcd(int a, int b) // Greatest Common Divisor
        {
            while (true)
            {
                if (b == 0)
                {
                    return a;
                }
                var r = a % b;
                a = b;
                b = r;
            }
        }
    }
}