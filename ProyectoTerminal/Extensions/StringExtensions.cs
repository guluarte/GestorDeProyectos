using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTerminal.Extensions
{
    public static class StringExtensions
    {
        public static string TruncateString(this string str, int start, int maxLength)
        {
            return str.Substring(start, Math.Min(str.Length, maxLength));
        }
    }
}