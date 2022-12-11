using Hw7.Models.ForTests;
using Microsoft.AspNetCore.Mvc;

namespace Hw7.Controllers;

public class TestController : Controller
{
    [HttpGet]
    public IActionResult TestModel() => View();

    [HttpPost]
    public IActionResult TestModel(TestModel model) => View(model);
}