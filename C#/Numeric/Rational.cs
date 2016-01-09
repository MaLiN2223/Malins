
namespace Numeric
{
    public struct Rational
    {
        private Integer _up;
        private Integer _down;

        public Rational(Integer up, Integer down)
        {
            _up = up;
            if (down == 0)
                throw new System.ArgumentException("Denominator must be non-zero.");
            _down = down;

        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            return new Rational(r1._up * r2._down, r1._down * r2._up);
        }


    }
}
