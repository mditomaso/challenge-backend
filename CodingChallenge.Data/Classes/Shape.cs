using CodingChallenge.Data.Interfaces;

namespace CodingChallenge.Data.Classes
{
    public abstract class Shape : IShape
    {
        protected decimal _side;

        protected Shape(decimal side)
        {
            _side = side;
        }

        public abstract decimal GetArea();

        public abstract decimal GetPerimeter();
    }
}
