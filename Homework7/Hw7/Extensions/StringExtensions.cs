using System.Text;
using System.Text.RegularExpressions;

namespace Hw7.Extensions;

public static class StringExtensions
{
    public static string CamelCaseToSpace(this string str)
    {
        // Insert spaces before all caps with string builder
        var sb = new StringBuilder(str);
        for (int i = 1; i < sb.Length; i++)
        {
            if (char.IsUpper(sb[i]))
            {
                sb.Insert(i, " ");
                i++;
            }
        }

        return sb.ToString();
    }
}