using TitaniumDaffodil;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Fluxor;


Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHNqVVhkW1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF9iSH5adERiXXpccXddQQ==;Mgo+DSMBPh8sVXJ0S0V+XE9AcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3xSd0VqW35fdHFXR2VUVg==;ORg4AjUWIQA/Gnt2VVhjQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRd0RjUH1fcXBQRGFbUkM=;NzU3NjQwQDMyMzAyZTMzMmUzMGxCaVRoaUxEM2k3cUVwOHJINXMvaWdpMFpQRmh6ei9qZnhNWEx3VFJTN0E9;NzU3NjQxQDMyMzAyZTMzMmUzMEVzbEgwVkVMWnZBWDhNME8zQlFEOHNSUytOZVdYVW1VVkgzV3gwbnRXeUU9;NRAiBiAaIQQuGjN/V0Z+X09EaFtFVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdERiWXZccXVRQ2JeUkNx;NzU3NjQzQDMyMzAyZTMzMmUzME9rUGErcFhINjYrckFneDk2WGE0REVnVnZjVi9YZlhFVnZJb2I4RHVNNDA9;NzU3NjQ0QDMyMzAyZTMzMmUzMGNoM1dvaDJxK2V4VjIrTHY4WmhJeTJsYm9nKzluR0lYcjdETTQyWncyUkk9;Mgo+DSMBMAY9C3t2VVhjQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRd0RjUH1fcXBQRGRYVEE=;NzU3NjQ2QDMyMzAyZTMzMmUzMGEwcDkzZlBZRmRHQ0paelJBYzZSUVNaSnVOOE1OdTAxVUUybDJKdjhVdXM9;NzU3NjQ3QDMyMzAyZTMzMmUzMFV3MDdrRThZWFhPY05maTlaODVmejk0aHpFVmVwelRNc0cxSWtzZDJKaWM9;NzU3NjQ4QDMyMzAyZTMzMmUzME9rUGErcFhINjYrckFneDk2WGE0REVnVnZjVi9YZlhFVnZJb2I4RHVNNDA9");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSyncfusionBlazor();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// builder.Services.AddSingleton<SidebarService>();
builder.Services.AddScoped<SideBarState>();
builder.Services.AddFluxor(config  => 
{
    config
        .ScanAssemblies(typeof(Program).Assembly)
        .UseReduxDevTools();
});


var host = builder.Build();
var sideBarState = host.Services.GetRequiredService<SideBarState>();
FluxorDispatch.Dispatcher = host.Services.GetRequiredService<IDispatcher>();

await host.RunAsync();


 

public static class FluxorDispatch {
    public static IDispatcher? Dispatcher;
    public static void Dispatch<T>(T action) where T : class {
        Dispatcher?.Dispatch(action);
        if (Dispatcher == null) throw new Exception("Dispatcher is null");
    }
}
