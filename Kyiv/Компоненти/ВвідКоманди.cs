using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

namespace Kyiv.Компоненти;

public class ВвідКоманди : InputText
{
    protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        result = value;
        var invalid = value is not null && value.Any(_ => _ < '0' || _ > '7');
        validationErrorMessage = invalid ? "Не 8-річне число." : null;
        return !invalid;
    }
}
