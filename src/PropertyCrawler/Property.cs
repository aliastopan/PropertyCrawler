using System;
using System.Collections;
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
                var label = isPrimitive ? "primitive" : "class";

                Console.WriteLine($"{Line}{props[i].Name.ToUpper()}:{label}");

                if(isIterable)
                {
                    Type type = props[i].PropertyType;
                    bool isGeneric = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);

                    int totalGenerics = props[i].PropertyType.GetGenericArguments().Length;
                    for (int j = 0; j < totalGenerics; j++)
                    {
                        // Type type = props[i].PropertyType.GetGenericArguments()[j];
                        // Deep(type.GetProperties());
                        // Type _prop = type.GetGenericArguments()[0];
                        // PropertyInfo[] x = _prop.GetType().GetProperties();
                    }
                }
            }
        }

        public static void _Crawler(object @object)
        {
            PropertyInfo[] props = @object.GetType().GetProperties();

            foreach(var prop in props)
            {
                bool isPrimitive = prop.PropertyType.IsPrimitive;
                bool isCollection =
                    prop.PropertyType != typeof(string) &&
                    typeof(ICollection).IsAssignableFrom(prop.PropertyType);

                var _type = isPrimitive ? "p" : "c";

                Console.WriteLine($"|-{prop.Name}:{_type}");

                if(isCollection)
                {
                    Type type = prop.PropertyType;
                    bool isGeneric = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);

                    if(isGeneric)
                    {
                        int totalGenerics = type.GetGenericArguments().Length;
                        for (int i = 0; i < totalGenerics; i++)
                        {
                            Type _prop = type.GetGenericArguments()[0];
                            PropertyInfo[] x = _prop.GetType().GetProperties();


                            // Crawler(_prop);
                            // Console.WriteLine($"|--{x.}");
                        }

                        // foreach (var _prop in type.GetGenericArguments())
                        // {
                        //     Crawler(_prop);
                        // }

                        // var itemType = type.GetGenericArguments()[0];
                        // var x = itemType.GetType().GetProperties();
                    }

                    // var _props = type.GetType().GetProperties();
                }
            }

        }
    }
}