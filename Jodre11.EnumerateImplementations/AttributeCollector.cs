namespace Jodre11.EnumerateImplementations;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

internal class AttributeCollector(params string[] attributeNames) : CSharpSyntaxVisitor
{
    private readonly HashSet<string> _attributeNames = [..attributeNames];

    public List<AttributeDefinition> AttributeDefinitions { get; } = [];

    public override void VisitAttribute(AttributeSyntax node)
    {
        base.VisitAttribute(node);

        if (!_attributeNames.Contains(node.Name.ToString()))
        {
            return;
        }
        
        var classOrStructSyntaxNode = node.Parent?.Parent;
        ClassDeclarationSyntax? classDeclarationSyntax = null;
        StructDeclarationSyntax? structDeclarationSyntax = null;
        switch (classOrStructSyntaxNode)
        {
            case null:
                return;
            case ClassDeclarationSyntax c:
                classDeclarationSyntax = c;
                break;
            case StructDeclarationSyntax s:
                structDeclarationSyntax = s;
                break;
        }

        var fieldArguments = new List<(string Name, object Value)>();
        var propertyArguments = new List<(string Name, object Value)>();

        var arguments = node.ArgumentList?.Arguments.ToArray() ?? [];
        foreach (var syntax in arguments)
        {
            if (syntax.NameColon != null)
            {
                fieldArguments.Add((syntax.NameColon.Name.ToString(), syntax.Expression));
            }
            else if (syntax.NameEquals != null)
            {
                propertyArguments.Add((syntax.NameEquals.Name.ToString(), syntax.Expression));
            }
            else
            {
                fieldArguments.Add((string.Empty, syntax.Expression));
            }
        }

        AttributeDefinitions.Add(new AttributeDefinition
        (
            node.Name.ToString(),
            fieldArguments.ToArray(),
            propertyArguments.ToArray(),
            classDeclarationSyntax,
            structDeclarationSyntax
        ));
    }
}