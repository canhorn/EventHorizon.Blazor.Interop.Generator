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
    public class InterfaceTests
    {
        [Fact]
        public void ShouldGenerateInterfaceString()
        {
            ReadInteropTemplates.SetReadTemplates();
            // Given
            var sourceFile = "interface.ts";
            var source = File.ReadAllText($"./SourceFiles/{sourceFile}");
            var expected = File.ReadAllText($"./ExpectedResults/interface.Expected.txt");
            var ast = new TypeScriptAST(source, sourceFile);
            var typeOverrideMap = new Dictionary<string, string>();

            // When
            var generated = GenerateInteropClassStatement.Generate(
                "ProjectAssembly",
                "ExampleInterface",
                ast,
                typeOverrideMap
            );
            var actual = GenerateClassStatementString.Generate(
                generated,
                new NoFormattingTextFormatter()
            );

            // Then
            actual.Should().Be(
                expected
            );
        }
    }
}
