using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MinimalApi.Extensions.SourceGeneration
{
    public static class Extensions
    {
        public static IncrementalValuesProvider<ISymbol> FilterClassDeclarationsByAttribute(this IncrementalGeneratorInitializationContext ctx, string attributeName)
        {
            return ctx.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (node, _) => node is ClassDeclarationSyntax cds &&
                    cds.AttributeLists.Count > 0,
                transform: static (ctx, _) =>
                {
                    var classDecl = (ClassDeclarationSyntax)ctx.Node;
                    var classSymbol = ctx.SemanticModel.GetDeclaredSymbol(classDecl);
                    return classSymbol;
                })
            .Where(static symbol => symbol is not null)
            .Select((symbol, _) => symbol!)
            .Where(symbol =>
                symbol.GetAttributes().Any(ad =>
                    ad.AttributeClass?.ToDisplayString() == attributeName
                ));
        }
    }
}
