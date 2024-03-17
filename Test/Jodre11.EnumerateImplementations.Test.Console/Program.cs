namespace Jodre11.EnumerateImplementations.Test.Console;

using SomeClassLibrary;

[Implementations(typeof(ISomeType))]
partial class Program
{
    public static void Main(string[] args)
    {
        HelloFrom("Generated Code");
    }

    static partial void HelloFrom(string name);

    static partial IEnumerable<ISomeType> ISomeTypes();
}