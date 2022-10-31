using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Hw7.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hw7.MyHtmlServices;

public static class HtmlHelperExtensions
{
    public static IHtmlContent MyEditorForModel(this IHtmlHelper helper)
    {
        var html = new HtmlContentBuilder();
        var type = helper.ViewData.ModelMetadata.ModelType;
        var modelValue = helper.ViewData.Model;

        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            html.AppendLine(CreateInputFor(helper, prop, modelValue));
        }

        return html;
    }

    private static IHtmlContent CreateInputFor(IHtmlHelper helper, PropertyInfo property, object? modelValue)
    {
        var tag = new TagBuilder("div");
        tag.AddCssClass("mb-3");

        tag.InnerHtml.AppendHtml(CreateLabel(helper, property));
        tag.InnerHtml.AppendHtml(
            CreateForProp(property,
                modelValue is not null
                    ? property.GetValue(modelValue)
                    : null));

        if (modelValue is not null)
            tag.InnerHtml.AppendHtml(ValidateProperty(property, modelValue));

        return tag;
    }

    private static IHtmlContent CreateLabel(IHtmlHelper helper, PropertyInfo property)
    {
        var label = new TagBuilder("label");
        label.Attributes.Add("for", property.Name);
        label.InnerHtml.Append(GetPropertyName(property));
        return label;
    }

    private static IHtmlContent CreateForProp(PropertyInfo property, object? propValue)
        => property.PropertyType.IsEnum
            ? CreateSelectForEnum(property, propValue)
            : CreateInput(property, propValue);

    private static IHtmlContent CreateInput(PropertyInfo property, object? value)
    {
        var tag = new TagBuilder("input");
        tag.AddCssClass("form-control");

        tag.Attributes.Add("id", property.Name);
        tag.Attributes.Add("name", property.Name);
        tag.Attributes.Add("type", GetInputType(property));
        if (value is not null)
            tag.Attributes.Add("value", value.ToString());

        return tag;
    }

    private static IHtmlContent CreateSelectForEnum(PropertyInfo property, object? value)
    {
        var tag = new TagBuilder("select");
        tag.AddCssClass("form-control");

        tag.Attributes.Add("name", property.Name);

        var items = property.PropertyType
            .GetFields(BindingFlags.Public | BindingFlags.Static);

        foreach (var item in items)
        {
            tag.InnerHtml.AppendHtml(CreateOption(
                item.Name,
                GetPropertyName(item),
                item.Name == value?.ToString()));
        }

        return tag;
    }

    private static IHtmlContent CreateOption(string value, string text, bool selected)
    {
        var tag = new TagBuilder("option");

        tag.Attributes.Add("value", value);
        if (selected)
            tag.Attributes.Add("selected", "true");
        tag.InnerHtml.Append(text);

        return tag;
    }

    private static IHtmlContent ValidateProperty(PropertyInfo property, object modelValue)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(modelValue)
        {
            DisplayName = GetPropertyName(property),
            MemberName = property.Name
        };

        return (Validator.TryValidateProperty(property.GetValue(modelValue), context, results) || results.Count == 0)
            ? HtmlString.Empty
            : CreateValidationInfo(string.Join("\n", results.Select(r => r.ErrorMessage)));
    }

    private static IHtmlContent CreateValidationInfo(string errorMessage)
    {
        var tag = new TagBuilder("span");

        tag.AddCssClass("form-text");
        tag.AddCssClass("text-danger");
        
        tag.InnerHtml.Append(errorMessage);

        return tag;
    }

    private static string GetInputType(PropertyInfo property)
        => property.PropertyType switch
        {
            { } t when t == typeof(int) => "number",
            _ => "text",
        };

    private static string GetPropertyName(MemberInfo propertyInfo) =>
        propertyInfo.GetCustomAttribute<DisplayAttribute>()?.Name ??
        propertyInfo.Name.CamelCaseToSpace();
}