using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System.Diagnostics.CodeAnalysis;

namespace Kyiv.Компоненти;

public class ВвідКоманди : InputBase<ulong>
{
    /// <summary>
    /// Gets or sets the associated <see cref="ElementReference"/>.
    /// <para>
    /// May be <see langword="null"/> if accessed before the component is rendered.
    /// </para>
    /// </summary>
    [DisallowNull] public ElementReference? Element { get; protected set; }

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "input");
        builder.AddMultipleAttributes(1, AdditionalAttributes);
        if (!string.IsNullOrEmpty(NameAttributeValue))
        {
            builder.AddAttribute(2, "name", NameAttributeValue);
        }

        if (!string.IsNullOrEmpty(CssClass))
        {
            builder.AddAttribute(3, "class", CssClass);
        }

        builder.AddAttribute(4, "value", CurrentValueAsString);
        builder.AddAttribute(5, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.SetUpdatesAttributeName("value");
        builder.AddElementReferenceCapture(6, __inputReference => Element = __inputReference);
        builder.CloseElement();
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string? value, out ulong result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        var invalid = value is not null && value.Any(_ => (_ < '0' || _ > '7') && _ != ' ');
        result = invalid ? 0 : ПарсерКоманд.Сконвертувати(value ?? "");
        validationErrorMessage = invalid ? "Не 8-річне число." : null;
        return !invalid;
    }

    /// <inheritdoc />
    protected override string? FormatValueAsString(ulong value)
    {
        return ПарсерКоманд.Сконвертувати(value);
    }
}
