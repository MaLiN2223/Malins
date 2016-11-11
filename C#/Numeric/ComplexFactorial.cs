
namespace Numeric
{
    public struct ComplexFactorial
    {
        private Complex _up;
        private Complex _down;
        public ComplexFactorial(Complex up, Complex down)
        {
            _up = up;
            _down = down;
        }

        public override string ToString()
        {
            return $"{_up}/{_down}";
        }
    }
    
}
