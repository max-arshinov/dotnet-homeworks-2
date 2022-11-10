using System.Net.Http;
using System.Threading.Tasks;
using Hw7.ErrorMessages;
using Hw7.Models.ForTests;
using Hw7.Tests.Shared;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Hw7.Tests;

public class TestFormTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly string _url = "/Test/TestModel";

    public TestFormTests(WebApplicationFactory<Program> fixture)
    {
        _client = fixture.CreateClient();
    }
    
    [Theory]
    [InlineData("FirstName", "First Name")]
    [InlineData("Age", "Age")]
    [InlineData("A", "A")]
    public async Task GetTestForm_PropsWithoutDisplayAttr_CamelCaseSplit(string propertyName, string expected)
    {
        //arrange
        var response = await TestHelper.GetFormHtml(_client, _url);

        //act
        var actual = TestHelper.GetPropertyNameFromLabel(response, propertyName);

        //assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData("FirstName", Messages.RequiredMessage)]
    [InlineData("LastName", "")]
    [InlineData("MiddleName", Messages.RequiredMessage)]
    [InlineData("Age", $"Age {Messages.RangeMessage}")]
    public async Task PostEmptyTestForm_CheckForRequiredProperty_EveryPropertyIsRequiredExceptLastName(string propertyName,
        string expected)
    {
        //arrange
        var model = new BaseModel();
        var response = await TestHelper.SendForm(_client, _url, model);

        //act
        var actual = TestHelper.GetValidationMessageFromSpan(response, propertyName);

        //assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData("FirstName", $"First Name {Messages.MaxLengthMessage}")]
    [InlineData("LastName", $"Last Name {Messages.MaxLengthMessage}")]
    [InlineData("MiddleName", "")]
    public async Task PostInvalidTestForm_CheckForMaxLengthValidation_EveryStringPropertyIsValidatedExceptMiddleName(string propertyName,
        string expected)
    {
        //arrange
        var model = new BaseModel{FirstName = TestHelper.LongString, LastName = TestHelper.LongString, MiddleName = TestHelper.LongString};
        var response = await TestHelper.SendForm(_client, _url, model);

        //act
        var actual = TestHelper.GetValidationMessageFromSpan(response, propertyName);

        //assert";
        Assert.Equal(expected, actual);
    }
}