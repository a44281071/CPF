using CPF.Drawing;
using CPF.Platform;
using CPF.Skia;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPF;

public class CpfApplicationBuilder
{
    internal CpfApplicationBuilder(CpfApplicationOptions options)
    {
        Options = options;
        Services.AddSingleton<CpfApplication>();
    }

    private List<BuildPlatformInfo> needPlatforms = [];
    public IServiceCollection Services { get; } = new ServiceCollection();

    public CpfApplicationOptions Options { get; }

    public CpfApplicationBuilder AddLinuxPlatform()
    {
        var info = new BuildPlatformInfo(OperatingSystemType.Linux, new CPF.Linux.LinuxPlatform(), new SkiaDrawingFactory { UseGPU = true });
        needPlatforms.Add(info);
        return this;
    }

    public CpfApplicationBuilder AddMacPlatform()
    {
        var info = new BuildPlatformInfo(OperatingSystemType.OSX, new CPF.Mac.MacPlatform(), new SkiaDrawingFactory { UseGPU = false });
        needPlatforms.Add(info);
        return this;
    }

    public CpfApplicationBuilder AddWindowsPlatform()
    {
        var info = new BuildPlatformInfo(OperatingSystemType.Windows, new CPF.Windows.WindowsPlatform(false), new SkiaDrawingFactory { UseGPU = true });
        needPlatforms.Add(info);
        return this;
    }

    public CpfApplication Build()
    {
        IServiceProvider provider = Services.BuildServiceProvider();

        var runtimes = needPlatforms.Select(dd => (dd.OperatingSystemType, dd.RuntimePlatform, dd.DrawingFactory)).ToArray();
        CPF.Platform.Application.Initialize(runtimes);

        var app = provider.GetRequiredService<CpfApplication>();
        return app;
    }

    private record BuildPlatformInfo(OperatingSystemType OperatingSystemType, RuntimePlatform RuntimePlatform, DrawingFactory DrawingFactory);
}