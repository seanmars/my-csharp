using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;

namespace Common
{
    // Copy From https://github.com/StackExchange/Dapper/blob/4e62055c5775aced61b848282ed180de0ab62161/Dapper.Rainbow/Database.cs#L132
    public static class PropertyHelper
    {
        private static readonly ConcurrentDictionary<Type, List<string>> paramNameCache = new ConcurrentDictionary<Type, List<string>>();

        public static List<string> GetParamNames(object o)
        {
            if (o is DynamicParameters parameters)
            {
                return parameters.ParameterNames.ToList();
            }

            if (!paramNameCache.TryGetValue(o.GetType(), out List<string> paramNames))
            {
                paramNames = new List<string>();
                foreach (var prop in o.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.GetGetMethod(false) != null))
                {
                    var attributes = prop.GetCustomAttributes(typeof(IgnorePropertyAttribute), true);
                    var attr = attributes.FirstOrDefault() as IgnorePropertyAttribute;
                    if (attr == null || (!attr.Value))
                    {
                        paramNames.Add(prop.Name);
                    }
                }
                paramNameCache[o.GetType()] = paramNames;
            }
            return paramNames;
        }
    }
}
