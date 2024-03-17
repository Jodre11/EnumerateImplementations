namespace Jodre11.EnumerateImplementations.Test.Console;

using SomeClassLibrary;

[Implementations(typeof(ISomeType))]
partial class Program
{
    public static void Main(string[] args)
    {
    }

    internal partial IEnumerable<ISomeType> ISomeTypes();
}