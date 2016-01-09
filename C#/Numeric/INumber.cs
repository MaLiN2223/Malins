namespace Numeric
{
    public abstract class Number
    {
        protected abstract Number Sum(Number nr);
        protected abstract Number Multiply(Number nr);
        protected abstract Number Divide(Number nr);
        protected abstract Number Power();
        protected abstract Number Sqrt();
    }
}
