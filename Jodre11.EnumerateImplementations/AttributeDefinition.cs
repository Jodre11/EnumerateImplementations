using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jodre11.EnumerateImplementations;

internal sealed record AttributeDefinition
{
    public AttributeDefinition(
        string name,
        IReadOnlyList<(string Name, object Value)> fieldArguments,
        IReadOnlyList<(string Name, object Value)> propertyArguments,
        ClassDeclarationSyntax? classDeclarationSyntax,
        StructDeclarationSyntax? structDeclarationSyntax)
    {
        Name = name;
        FieldArguments = fieldArguments;
        PropertyArguments = propertyArguments;
        ClassDeclarationSyntax = classDeclarationSyntax;
        StructDeclarationSyntax = structDeclarationSyntax;
    }

    public string Name { get; set; }
    public IReadOnlyList<(string Name, object Value)> FieldArguments { get; set; } = [];
    public IReadOnlyList<(string Name, object Value)> PropertyArguments { get; set; } = [];
    public ClassDeclarationSyntax? ClassDeclarationSyntax { get; set; }
    public StructDeclarationSyntax? StructDeclarationSyntax { get; set; }
}