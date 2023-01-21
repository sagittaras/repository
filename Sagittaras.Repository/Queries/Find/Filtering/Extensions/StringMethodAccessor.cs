using System;
using System.Reflection;

namespace Sagittaras.Repository.Queries.Find.Filtering.Extensions
{
    /// <summary>
    /// Provides access to MethodInfo objects of the string class.
    /// </summary>
    internal static class StringMethodAccessor
    {
        private static readonly Type StringType = typeof(string);

        public static MethodInfo Trim => StringType.GetMethod(nameof(string.Trim), Type.EmptyTypes)!;
        public static MethodInfo ToUpper => StringType.GetMethod(nameof(string.ToUpper), Type.EmptyTypes)!;
        public static MethodInfo Contains => StringType.GetMethod(nameof(string.Contains), new[] { StringType })!;
    }
}