using System.Reflection;


namespace ACME.Infrastructure.Reviews;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
