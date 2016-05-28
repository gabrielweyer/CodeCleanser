using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GeneratedCodeCleaner.Logic
{
    public class CodeCleaner
    {
        private static readonly AttributesSorter AttributesSorter = new AttributesSorter();

        public static void CleanDirectory(string path)
        {
            foreach (var file in Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories))
            {
                var code = File.ReadAllText(file);

                var cleanedCode = Clean(code);

                if (code != cleanedCode)
                {
                    File.WriteAllText(file, cleanedCode);
                }
            }
        }

        public static string Clean(string code)
        {
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = (CompilationUnitSyntax)tree.GetRoot();

            root = RemoveLeadingTrivia(root);

            root = SortAttributesAlphabetically(root);

            return root.GetText().ToString();
        }

        private static CompilationUnitSyntax RemoveLeadingTrivia(CompilationUnitSyntax root)
        {
            if (root.HasLeadingTrivia)
            {
                return root.ReplaceTrivia(root.GetLeadingTrivia(), (trivia, syntaxTrivia) => default(SyntaxTrivia));
            }

            return root;
        }

        private static CompilationUnitSyntax SortAttributesAlphabetically(CompilationUnitSyntax root)
        {
            return (CompilationUnitSyntax)AttributesSorter.Visit(root);
        }
    }
}