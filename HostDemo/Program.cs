using CPF;
using HostDemo.Views;
using Microsoft.Extensions.DependencyInjection;

namespace HostDemo;

internal class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        CpfApplicationBuilder builder = HostBuilder.CreateCpfBuilder(args);
        builder.AddWindowsPlatform()
               .AddMacPlatform()
               .AddLinuxPlatform();

        //builder.Services.RegisterSingleInstance<WindowAccessor>().As(IWindowAccessor);
        builder.Services.AddTransient<ShellViewModel>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            // app.AddDevTools();
        }

        app.StartupViewFor<ShellViewModel>();

        app.Run();
    }
}