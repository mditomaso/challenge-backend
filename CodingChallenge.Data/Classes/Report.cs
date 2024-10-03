using CodingChallenge.Data.Helpers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public static class Report
    {
        public static string PrintShapes(List<Shape> shapes, LanguageEnum language)
        {
            Resources.Shape.Culture = new CultureInfo(EnumHelper.GetEnumDescription(language));

            //Necessary to have always dots on decimal numbers. Otherwise, it takes the system format (comma or dot)
            Resources.Shape.Culture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = Resources.Shape.Culture;

            if (!shapes.Any())
                return Resources.Shape.EmptyListTitle;

            var sb = new StringBuilder();
            // HEADER
            sb.Append(Resources.Shape.ReportTitle);

            decimal sumOfPerimeters = 0;
            decimal sumOfAreas = 0;
            var shapeTypes = ReflectiveEnumerator.GetEnumerableOfTypeByOrderAttribute<Shape>();
            foreach (var type in shapeTypes)
            {
                var subList = shapes.Where(x => x.GetType() == type).ToList();
                var subListTotal = subList.Count();

                if (subList.Any())
                {
                    decimal sumOfSubListAreas = 0;
                    subList.ForEach(x => sumOfSubListAreas += x.GetArea());
                    sumOfAreas += sumOfSubListAreas;

                    decimal sumOfSubListPerimeters = 0;
                    subList.ForEach(x => sumOfSubListPerimeters += x.GetPerimeter());
                    sumOfPerimeters += sumOfSubListPerimeters;

                    ResourceManager rm = Resources.Shape.ResourceManager;
                    string shapeType = rm.GetString($"{type.Name}{(subListTotal > 1 ? "Plural" : string.Empty)}", Resources.Shape.Culture);

                    sb.Append(string.Format(Resources.Shape.LineResult, subListTotal, shapeType, sumOfSubListAreas.ToString("#.##"), sumOfSubListPerimeters.ToString("#.##")));
                }
            }

            // FOOTER
            sb.Append(string.Format(Resources.Shape.TotalResult, shapes.Count, sumOfPerimeters.ToString("#.##"), sumOfAreas.ToString("#.##")));

            return sb.ToString();
        }
    }
}
