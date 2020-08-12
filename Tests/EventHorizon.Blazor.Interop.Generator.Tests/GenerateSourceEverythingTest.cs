using System;
using System.Collections.Generic;
using System.IO;
using EventHorizon.Blazor.Interop.Generator.Templates;
using EventHorizon.Blazor.TypeScript.Interop.Generator;
using EventHorizon.Blazor.TypeScript.Interop.Generator.Formatter;
using EventHorizon.Blazor.TypeScript.Interop.Generator.Model.Writer;
using FluentAssertions;
using Moq;
using Xunit;

namespace EventHorizon.Blazor.Interop.Generator.Tests
{
    public class GenerateSourceEverythingTest
    {
        [Fact]
        public void ShouldGenerateSourceForEverythingDefinition()
        {
            ReadInteropTemplates.SetReadTemplates();
            // Given
            var projectAssembly = "ProjectAssembly";
            var sourceDirectory = "";
            var sourceFileName = "Everything.ts";
            var sourceFile = Path.Combine(
                ".",
                "SourceFiles",
                sourceFileName
            );
            var sourceFiles = new List<string>
            {
                sourceFile
            };
            var generationList = new List<string>
            {
                "Everything",
            };
            var typeOverrideMap = new Dictionary<string, string>();

            var writerMock = new Mock<IWriter>();

            // When
            var generateSource = new GenerateSource();
            var actual = generateSource.Run(
                projectAssembly,
                sourceDirectory,
                sourceFiles,
                generationList,
                writerMock.Object,
                new NoFormattingTextFormatter(),
                typeOverrideMap
            );


            // Then
            actual.Should().BeTrue();
        }
    }
}
