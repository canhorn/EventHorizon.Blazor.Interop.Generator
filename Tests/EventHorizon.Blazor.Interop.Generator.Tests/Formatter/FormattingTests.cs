using System.Collections.Generic;
using System.IO;
using EventHorizon.Blazor.Interop.Generator.Templates;
using EventHorizon.Blazor.TypeScript.Interop.Generator;
using EventHorizon.Blazor.TypeScript.Interop.Generator.Formatter;
using FluentAssertions;
using Sdcb.TypeScript;
using Xunit;

namespace EventHorizon.Blazor.Interop.Generator.Tests.GenerateClassStatementStringTests
{
    public class FormattingTests
    {
        [Fact]
        [Trait("Category", "FormattingTests.CShapeTextFormatter")]
        public void ShouldGenerateFormattedString()
        {
            // Given
            ReadInteropTemplates.SetReadTemplates();
            var sourceFile = "CSharpTextFormatter.d.ts";
            var source = File.ReadAllText($"./Formatter/SourceFiles/{sourceFile}");
            var expected = File.ReadAllText($"./Formatter/ExpectedResults/CSharpTextFormatter.Expected.txt");
            var ast = new TypeScriptAST(source, sourceFile);
            var typeOverrideMap = new Dictionary<string, string>();

            // When
            var generated = GenerateInteropClassStatement.Generate(
                "ProjectAssembly",
                "CSharpTextClass",
                ast,
                typeOverrideMap
            );
            var actual = GenerateClassStatementString.Generate(
                generated,
                new CSharpTextFormatter()
            );

            // Then
            actual.Should().Be(
                expected
            );
        }
    }
}
