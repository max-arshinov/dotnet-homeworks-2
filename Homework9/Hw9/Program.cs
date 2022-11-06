using System.Diagnostics.CodeAnalysis;
using Hw9.Configuration;
using Hw9.Parser.Tokens;

var a = new Tokenizer();
var result = a.Tokenize("10+i".Replace(" ", ""));
result = a.Tokenize("10+i".Replace(" ", ""));
result = a.Tokenize("1.20:2".Replace(" ", ""));
result = a.Tokenize("2 -+ 2.23.1 - 23");

Console.WriteLine("");
// var builder = WebApplication.CreateBuilder(args);
//
// builder.Services.AddControllersWithViews();
//
// builder.Services.AddMathCalculator();
//
// var app = builder.Build();
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     app.UseHsts();
// }
//
// app.UseHttpsRedirection();
// app.UseStaticFiles();
//
// app.UseRouting();
//
// app.UseAuthorization();
//
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Calculator}/{action=Calculator}/{id?}");
//
// app.Run();

namespace Hw9
{
    [ExcludeFromCodeCoverage]
    public partial class Program { }
}