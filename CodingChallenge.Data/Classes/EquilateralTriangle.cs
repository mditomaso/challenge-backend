using CodingChallenge.Data.Helpers;
using System;

namespace CodingChallenge.Data.Classes
{
    [Order(3)]
    public class EquilateralTriangle : Shape
    {
        public EquilateralTriangle(decimal side) : base(side)
        {
        }

        public override decimal GetArea()
        {
            return (decimal)Math.Sqrt(3) / 4 * _side * _side;
        }

        public override decimal GetPerimeter()
        {
            return _side * 3;
        }
    }
}
