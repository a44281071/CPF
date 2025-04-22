using System;
using System.Collections.Generic;
using System.Text;

namespace CPF;

public class HostBuilder
{
    public static CpfApplicationBuilder CreateCpfBuilder(string[] args)
    {
        return new CpfApplicationBuilder(new() { Args = args });
    }
}