using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Hw7.MyHtmlServices;

public static class HtmlHelperExtensions
{
    public static IHtmlContent MyEditorForModel(this IHtmlHelper helper)
    {
        var model = helper.ViewData.Model;
        var properties = helper.ViewData.ModelMetadata.ModelType.GetProperties();
        return ConstructHtml(model, properties);
    }

    private static HtmlContentBuilder ConstructHtml(object? model, IEnumerable<PropertyInfo> properties)
    {
        var page = new HtmlContentBuilder();
        foreach (var property in properties)
        {
            page.AppendHtmlLine(
                "<div>" + GetPropertyField(property) + GetInputField(model, property) + "</div>");
        }
        return page;
    }

    private static string GetPropertyField(MemberInfo property)
    {
        var attribute = property.GetCustomAttribute<DisplayAttribute>();
        var attributeName = attribute is null
            ? string.Join(" ", Regex.Split(property.Name, "(?<!^)(?=[A-Z])"))
            : attribute.Name!;
        return $"<label for=\"{property.Name}\">{attributeName}</label><br>";
    }

    private static string GetInputField(object? model, PropertyInfo property)
    {
        var sb = new StringBuilder();
        var modelValue = model is null ? string.Empty : $" value=\"{property.GetValue(model)}\"";
        if (property.PropertyType.IsEnum)
        {
            sb.AppendLine($"<select" + modelValue + ">");
            foreach (var val in Enum.GetValues(property.PropertyType))
            {
                sb.AppendLine($"<option>{val}</option>");
            } 
            sb.AppendLine("</select>");
        }
        else
        {
            var inputType = property.PropertyType == typeof(int) ? "number" : "text";
            sb.AppendLine($"<input id=\"{property.Name}\" type=\"{inputType}\"" + modelValue + "/>");
        }

        if (model is not null)
            sb.AppendLine(GetErrorSpan(property, property.GetValue(model)));
        return sb.ToString();
    }

    private static string GetErrorSpan(MemberInfo property, object? value)
    {
        var validationAttributes = property.GetCustomAttributes<ValidationAttribute>();
        foreach (var attribute in validationAttributes)
            if (!attribute.IsValid(value))
                return $"<div>{attribute.ErrorMessage!}</div>";
        return string.Empty;
    }
}