using CodingChallenge.Data.Helpers;

namespace CodingChallenge.Data.Classes
{
    [Order(1)]
    public class Square : Shape
    {
        public Square(decimal side) : base(side)
        {
        }

        public override decimal GetArea()
        {
            return _side * _side;
        }

        public override decimal GetPerimeter()
        {
            return _side * 4;
        }
    }
}
