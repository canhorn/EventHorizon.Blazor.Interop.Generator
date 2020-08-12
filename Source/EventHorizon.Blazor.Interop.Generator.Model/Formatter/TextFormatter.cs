using System;
using System.Collections.Generic;
using System.Text;

namespace EventHorizon.Blazor.Interop.Generator.Model.Formatter
{
    public interface TextFormatter
    {
        string Format(
            string text
        );
    }
}
