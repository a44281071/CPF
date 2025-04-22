using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace HostDemo.Views;

public partial class ShellViewModel : ObservableObject
{
    [ObservableProperty]
    string displayName = "shell screen";

}
