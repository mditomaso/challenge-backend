using CodingChallenge.Data.Classes;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests2
    {
        [TestCase]
        public void Report_PrintShapesEmptyListOnSpanish_OKResult()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", Report.PrintShapes(new List<Shape>(), Helpers.LanguageEnum.Spanish));
        }

        [TestCase]
        public void Report_PrintShapesEmptyListOnEnglish_OKResult()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", Report.PrintShapes(new List<Shape>(), Helpers.LanguageEnum.English));
        }

        [TestCase]
        public void Report_PrintShapesOneSquareOnSpanish_OKResult()
        {
            var shapes = new List<Shape> { new Square(5) };

            var result = Report.PrintShapes(shapes, Helpers.LanguageEnum.Spanish);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>" +
                            "TOTAL:<br/>1 formas Perímetro 20 Área 25", result);
        }

        [TestCase]
        public void Report_PrintShapesMultipleSquaresOnEnglish_OKResult()
        {
            var shapes = new List<Shape>
            {
                new Square(5),
                new Square(1),
                new Square(3)
            };

            var result = Report.PrintShapes(shapes, Helpers.LanguageEnum.English);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>" +
                            "TOTAL:<br/>3 shapes Perimeter 36 Area 35", result);
        }

        [TestCase]
        public void Report_PrintShapesMultipleShapesOnEnglish_OKResult()
        {
            var shapes = new List<Shape>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75m),
                new EquilateralTriangle(4.2m),
                new IsoscelesTrapezoid(16, 8, 8)
            };

            var result = Report.PrintShapes(shapes, Helpers.LanguageEnum.English);

            Assert.AreEqual("<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>" +
                            "2 Circles | Area 13.01 | Perimeter 18.06 <br/>" +
                            "3 Triangles | Area 49.64 | Perimeter 51.6 <br/>" +
                            "1 Trapezoid | Area 83.14 | Perimeter 40 <br/>" +
                            "TOTAL:<br/>8 shapes Perimeter 137.66 Area 174.79", result);
        }

        [TestCase]
        public static void Report_PrintShapesMultipleShapesOnSpanish_OKResult()
        {
            var shapes = new List<Shape>
            {
                new Square(5),
                new Circle(3),
                new EquilateralTriangle(4),
                new Square(2),
                new EquilateralTriangle(9),
                new Circle(2.75m),
                new EquilateralTriangle(4.2m)
            };

            var result = Report.PrintShapes(shapes, Helpers.LanguageEnum.Spanish);

            Assert.AreEqual("<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>" +
                            "2 Círculos | Área 13.01 | Perímetro 18.06 <br/>" +
                            "3 Triángulos | Área 49.64 | Perímetro 51.6 <br/>" +
                            "TOTAL:<br/>7 formas Perímetro 97.66 Área 91.65", result);
        }

        [TestCase]
        public static void Report_PrintShapesOneTrapezoidOnDeutsch_OKResult()
        {
            var shapes = new List<Shape> { new IsoscelesTrapezoid(16, 8, 8) };

            var result = Report.PrintShapes(shapes, Helpers.LanguageEnum.Deutsch);

            Assert.AreEqual("<h1>Formenbericht</h1>1 Trapez | Bereich 83.14 | Perimeter 40 <br/>" +
                            "GESAMT:<br/>1 Formen Perimeter 40 Bereich 83.14", result);
        }
    }
}
