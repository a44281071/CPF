using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CPF;

public class CpfApplication
{
    public CpfApplication(IServiceProvider service)
    {
        this.service = service;
    }

    private readonly IServiceProvider service;

    private Type? rootModelType;

    public void Run()
    {
        if (rootModelType is null) throw new NullReferenceException(nameof(rootModelType));
        string mFullName = rootModelType.FullName!;  // xx.xxxViewModel
        string vFullName = mFullName[..^5];          // xx.xxxView
        Type vType = Assembly.GetEntryAssembly()!.GetType(vFullName)!;
        var model = service.GetRequiredService(rootModelType);
        CpfObject view = (CpfObject)Activator.CreateInstance(vType)!;

        view.DataContext = model;
        view.CommandContext = model;
        CPF.Platform.Application.Run(view as CPF.Platform.IApp);
    }

    public void StartupViewFor<T>()
    {
        rootModelType = typeof(T);
    }

    public CpfApplicationEnvironment Environment { get; } = new();
}