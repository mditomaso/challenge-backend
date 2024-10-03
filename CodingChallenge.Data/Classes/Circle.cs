using CodingChallenge.Data.Helpers;
using System;

namespace CodingChallenge.Data.Classes
{
    [Order(2)]
    public class Circle : Shape
    {
        public Circle(decimal side) : base(side)
        {
        }

        public override decimal GetArea()
        {
            return (decimal)Math.PI * (_side / 2) * (_side / 2);
        }

        public override decimal GetPerimeter()
        {
            return (decimal)Math.PI * _side;
        }
    }
}
