using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EventHorizon.Blazor.Interop.Generator.Templates;
using EventHorizon.Blazor.TypeScript.Interop.Generator;
using EventHorizon.Blazor.TypeScript.Interop.Generator.Formatter;
using EventHorizon.Blazor.TypeScript.Interop.Generator.Model;
using EventHorizon.Blazor.TypeScript.Interop.Generator.Model.Writer;
using FluentAssertions;
using Moq;
using Xunit;

namespace EventHorizon.Blazor.Interop.Generator.Tests.GenerateClassStatementStringTests
{
    public class ActualStringGenerationTest
    {
        [Fact]
        [Trait("Category", "Multiple Generation")]
        public void ShouldGenerateSourceForEverythingDefinition()
        {
            // Given
            ReadInteropTemplates.SetReadTemplates();
            var projectAssembly = "ProjectAssembly";
            var sourceDirectory = "";
            var sourceFileName = "MultipleGeneration.d.ts";
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
                "Mesh",
                "Mesh",
                "Engine",
                "Vector3",
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

        [Fact]
        [Trait("Category", "Writer")]
        public void ShouldCallWriterWithGeneratedClassStatement()
        {
            // Given
            var projectAssembly = "ProjectAssembly";
            var sourceDirectory = "";
            var sourceFileName = "MultipleGeneration.d.ts";
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
                "Vector3",
            };
            var typeOverrideMap = new Dictionary<string, string>();

            var writerMock = new Mock<IWriter>();

            // When
            var generateSource = new GenerateSource();
            var actual = default(IList<GeneratedStatement>);
            writerMock.Setup(
                mock => mock.Write(
                    It.IsAny<IList<GeneratedStatement>>()
                )
            ).Callback<IList<GeneratedStatement>>(
                (generatedStatement) =>
                {
                    actual = generatedStatement;
                }
            );

            generateSource.Run(
                projectAssembly,
                sourceDirectory,
                sourceFiles,
                generationList,
                writerMock.Object,
                new NoFormattingTextFormatter(),
                typeOverrideMap
            );


            // Then
            actual.Should().NotBeNull();
            actual.Should().HaveCount(5);
        }
    }
}
