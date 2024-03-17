namespace Jodre11.EnumerateImplementations;

using JetBrains.Annotations;

/// <summary>
/// Enumerate all instances of a specified type.
/// </summary>
/// <param name="ofType">The type to enumerate.</param>
[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Struct,
    AllowMultiple = true)]
[PublicAPI]
public sealed class ImplementationsAttribute(Type ofType) : Attribute
{
    /// <summary>
    /// Optional member name where the implementations will be enumerated.
    /// This should be a partial member on the attributed class.
    /// </summary>
    /// <remarks>
    /// The type of the member must be an <see cref="IEnumerable{T}"/> of the specified <c>ofType</c>.
    /// If omitted, the inferred member name will be the name of <c>ofType</c> suffixed with an <c>"s"</c>.
    /// </remarks>
    public string? MemberName { get; set; }
    
    /// <summary>
    /// If specified, the enumeration will be limited to types in this namespace.
    /// </summary>
    public string? NamespaceScope { get; set; }
    
    /// <summary>
    /// Types in this sequence will be excluded from the enumeration.
    /// </summary>
    public IEnumerable<Type>? Exclusions { get; set; }
}