using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GeneratedCodeCleaner.Logic
{
    public class AttributesSorter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var newAttributes = SortAttributes(node.AttributeLists);

            if (newAttributes != node.AttributeLists)
            {
                node = node.WithAttributeLists(newAttributes);
            }

            return base.VisitClassDeclaration(node);
        }

        public override SyntaxNode VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            var newAttributes = SortAttributes(node.AttributeLists);

            if (newAttributes != node.AttributeLists)
            {
                node = node.WithAttributeLists(newAttributes);
            }

            return base.VisitEnumDeclaration(node);
        }

        public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            var newAttributes = SortAttributes(node.AttributeLists);

            if (newAttributes != node.AttributeLists)
            {
                node = node.WithAttributeLists(newAttributes);
            }

            return base.VisitPropertyDeclaration(node);
        }

        private static SyntaxList<AttributeListSyntax> SortAttributes(SyntaxList<AttributeListSyntax> attributeLists)
        {
            if (attributeLists.Count == 0) return attributeLists;

            var sortedAttributeLists = new SyntaxList<AttributeListSyntax>();

            var firstLeadingTrivia = attributeLists[0].GetLeadingTrivia();
            var secondLeadingTrivia = firstLeadingTrivia;

            if (attributeLists.Count > 1)
            {
                secondLeadingTrivia = attributeLists[1].GetLeadingTrivia();
            }

            var orderedAttributeLists = attributeLists.Select(q => q.WithLeadingTrivia(secondLeadingTrivia)).OrderBy(q => q.Attributes.ToString());

            sortedAttributeLists = sortedAttributeLists.AddRange(orderedAttributeLists);
            sortedAttributeLists = sortedAttributeLists.Replace(sortedAttributeLists[0], sortedAttributeLists[0].WithLeadingTrivia(firstLeadingTrivia));

            return sortedAttributeLists;
        }
    }
}