using Hw6;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Hw6Tests;

// ReSharper disable once ClassNeverInstantiated.Global
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override IHostBuilder CreateHostBuilder() => Host
        .CreateDefaultBuilder()
        .ConfigureWebHostDefaults(x =>
        {
            x.UseStartup<App.Startup>().UseTestServer();
        });
}