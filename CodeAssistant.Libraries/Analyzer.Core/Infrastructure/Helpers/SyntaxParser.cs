using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Analyzer.Core.Infrastructure.Helpers
{
    /// <summary>
    /// Provides functionality to parse C# source code into a Roslyn <see cref="SyntaxTree"/>.
    /// </summary>
    public class SyntaxParser : ISyntaxParser
    {
        /// <inheritdoc />
        public SyntaxTree Parse(string code)
        {
            return CSharpSyntaxTree.ParseText(code);
        }
    }

}
