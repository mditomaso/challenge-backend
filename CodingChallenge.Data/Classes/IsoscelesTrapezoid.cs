using CodingChallenge.Data.Helpers;
using System;

namespace CodingChallenge.Data.Classes
{
    [Order(4)]
    public class IsoscelesTrapezoid : Shape
    {
        private decimal _majorBase;
        private decimal _smallerBase;

        public IsoscelesTrapezoid(decimal majorBase, decimal smallerBase, decimal side) : base(side) 
        {
            _majorBase = majorBase;
            _smallerBase = smallerBase;
        }

        public override decimal GetArea()
        {
            decimal height = (decimal)Math.Sqrt(Math.Pow((double)_side, 2) - (Math.Pow((double)(_majorBase - _smallerBase), 2) / 4));
            return (_majorBase + _smallerBase) * height / 2;
        }

        public override decimal GetPerimeter()
        {
            return _majorBase + _smallerBase + (2 * _side);
        }
    }
}
