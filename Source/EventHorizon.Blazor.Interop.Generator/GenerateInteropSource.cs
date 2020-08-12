namespace EventHorizon.Blazor.Interop.Generator
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using EventHorizon.Blazor.Interop.Generator.Templates;
    using EventHorizon.Blazor.TypeScript.Interop.Generator;
    using EventHorizon.Blazor.TypeScript.Interop.Generator.Model.Formatter;
    using EventHorizon.Blazor.TypeScript.Interop.Generator.Model.Writer;
    using Sdcb.TypeScript;

    public class GenerateInteropSource
    {

        public bool Run(
            string projectAssembly,
            string sourceDirectory,
            IList<string> sourceFiles,
            IList<string> generationList,
            IWriter writer,
            TextFormatter textFormatter,
            IDictionary<string, string> typeOverrideMap
        )
        {
            ReadInteropTemplates.SetReadTemplates();

            return new GenerateSource()
                .Run(
                    projectAssembly,
                    sourceDirectory,
                    sourceFiles,
                    generationList,
                    writer,
                    textFormatter,
                    typeOverrideMap
                );
        }
    }
}
