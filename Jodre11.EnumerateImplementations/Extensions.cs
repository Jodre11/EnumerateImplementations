using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jodre11.EnumerateImplementations;

public static class Extensions
{
    public static bool IsPartial(this ClassDeclarationSyntax declarationSyntax) =>
        declarationSyntax.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword));

    public static bool IsPartial(this StructDeclarationSyntax declarationSyntax) =>
        declarationSyntax.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword));
}