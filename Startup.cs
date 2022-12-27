using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<SidebarService>();
    }

    public void Configure(WebAssemblyHostBuilder builder)
    {
        // Configure the host environment and request pipeline here
    }
}
