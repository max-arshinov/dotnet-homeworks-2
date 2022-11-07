using System.Diagnostics.CodeAnalysis;
using Hw9.Configuration;
using Hw9.Parser.Parser;
using Hw9.Parser.Tokens;

// var tkz = new Tokenizer();
// var prs = new Parser(new ParserProvider());
//
// var a = prs.Parse(tkz.Tokenize("3 - 4 / 2"));
// var b = prs.Parse(tkz.Tokenize("10"));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMathCalculator();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Calculator}/{id?}");

app.Run();

namespace Hw9
{
    [ExcludeFromCodeCoverage]
    public partial class Program { }
}