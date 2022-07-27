using System;
using System.Collections;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Reflection;

namespace PropertyCrawler
{
    public static class Property
    {
        private static int _depth = 0;
        public static string Line
        {
            get
            {
                string line = "|";
                for (int i = 0; i < _depth; i++)
                    line += "-";
                return line;
            }
        }

        private static bool IsIterable(this PropertyInfo propertyInfo)
        {
            bool isNotString = propertyInfo.PropertyType != typeof(string);
            bool isList = typeof(IList).IsAssignableFrom(propertyInfo.PropertyType);
            bool isCollection = typeof(ICollection).IsAssignableFrom(propertyInfo.PropertyType);
            bool isEnumarable = typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType);

            return isNotString && (isList || isCollection || isEnumarable);
        }

        private static bool IsIterableGeneric(this PropertyInfo propertyInfo)
        {
            Type type = propertyInfo.GetType();
            return
                type.IsGenericType && (
                    type.GetGenericTypeDefinition() == typeof(List<>) ||
                    type.GetGenericTypeDefinition() == typeof(Collection<>) ||
                    type.GetGenericTypeDefinition() == typeof(Enumerable)
                );
        }

        public static void Crawler(object @object)
        {
            GoingDeeper(@object.GetType().GetProperties());
        }

        public static void GoingDeeper(PropertyInfo[] props)
        {
            _depth++;

            for (int i = 0; i < props.Length; i++)
            {
                bool isIterable = props[i].IsIterable();
                bool isPrimitive = props[i].PropertyType.IsPrimitive;
                string labelType = props[i].PropertyType.Name;
                string label = "";
                label = isPrimitive ? "primitive" : "class";
                if(props[i].PropertyType == typeof(String))
                    label = "string";

                if(!isPrimitive && props[i].PropertyType != typeof(String))
                {
                    Console.WriteLine($"---");
                }

                Console.WriteLine($"{Line}{props[i].Name}:{labelType}");

                if(isIterable)
                {
                    Type type = props[i].PropertyType;
                    bool isGeneric = type.IsGenericType && (
                        type.GetGenericTypeDefinition() == typeof(List<>) ||
                        type.GetGenericTypeDefinition() == typeof(Collection<>)
                    );
                    int totalGenerics = props[i].PropertyType.GetGenericArguments().Length;
                    Type _type = props[i].PropertyType.GetGenericArguments()[0];
                    GoingDeeper(_type.GetProperties());
                }
            }
        }
    }
}