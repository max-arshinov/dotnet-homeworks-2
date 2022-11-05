using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Hw7.Models.ForTests;

namespace Hw7Tests.Shared;

public static class TestHelper
{
    public const string LongString = "Мороз и солнце; день чудесный! Еще ты дремлешь, друг прелестный...";
    
    public static async Task<string> GetFormHtml(HttpClient client, string url)
    {
        var response = await client.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }

    private static HtmlNode GetLabelForProperty(string html, string propertyName)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        return doc.DocumentNode.SelectNodes($"//label[@for=\"{propertyName}\"]").First();
    }

    public static string GetValidationMessageFromSpan(string html, string propertyName)
    {
        try
        {
            return GetLabelForProperty(html, propertyName).SelectNodes("../span").First().InnerHtml.RemoveNewLine();
        }
        catch (ArgumentNullException)
        {
            return "";
        }
    }

    public static string GetPropertyNameFromLabel(string html, string propertyName)
        => GetLabelForProperty(html, propertyName).InnerHtml.RemoveNewLine();

    public static async Task<string> SendForm(HttpClient client, string url, BaseModel model)   
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"FirstName", model.FirstName},
            {"LastName", model.LastName},
            {"MiddleName", model.MiddleName!},
            {"Age", model.Age.ToString()},
            {"Sex", model.Sex.ToString()},
        });
        
        var response = await client.PostAsync(url, content);
        return await response.Content.ReadAsStringAsync();
    }

    public static string GetInputTypeForProperty(string html, string propertyName)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        return doc.DocumentNode.SelectNodes($"//input[@id=\"{propertyName}\"]").First().Attributes["type"]
            .DeEntitizeValue;
    }

    public static bool TryGetSelect(string html, string propertyName)
        => GetLabelForProperty(html, propertyName).SelectNodes($"..//select") != null;
}