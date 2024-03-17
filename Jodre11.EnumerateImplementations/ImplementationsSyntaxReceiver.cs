using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Jodre11.EnumerateImplementations;

internal sealed class ImplementationsSyntaxReceiver : ISyntaxReceiver
{
    public List<AttributeDefinition> AttributeDefinitions { get; } = [];

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is AttributeSyntax attributeSyntax)
        {
            var collector = new AttributeCollector("Implementations", "ImplementationsAttribute");
            attributeSyntax.Accept(collector);
            AttributeDefinitions.AddRange(collector.AttributeDefinitions);
        }
    }
}