using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodingChallenge.Data.Helpers
{
    public static class ReflectiveEnumerator
    {
        public static IEnumerable<Type> GetEnumerableOfTypeByOrderAttribute<T>() where T : class
        {
            List<Type> types = Assembly.GetAssembly(typeof(T)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))).ToList();

            return types.OrderBy(x => (x.GetCustomAttribute(typeof(OrderAttribute)) as OrderAttribute).Order);
        }
    }
}
