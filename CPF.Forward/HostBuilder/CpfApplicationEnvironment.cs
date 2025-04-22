
namespace CPF;

public class CpfApplicationEnvironment
{
    public bool IsDevelopment() =>
#if DEBUG
        true
#else
        false
#endif
        ;
}