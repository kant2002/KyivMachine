using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System.Diagnostics.CodeAnalysis;

namespace Kyiv.Компоненти;

public class ВвідРегістра : InputBase<ushort>
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
        builder.AddAttribute(1, "step", "any");
        builder.AddMultipleAttributes(2, AdditionalAttributes);
        if (!string.IsNullOrEmpty(NameAttributeValue))
        {
            builder.AddAttribute(3, "name", NameAttributeValue);
        }

        if (!string.IsNullOrEmpty(CssClass))
        {
            builder.AddAttribute(4, "class", CssClass);
        }

        builder.AddAttribute(5, "value", CurrentValueAsString);
        builder.AddAttribute(6, "onchange", EventCallback.Factory.CreateBinder<string?>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
        builder.SetUpdatesAttributeName("value");
        builder.AddElementReferenceCapture(7, __inputReference => Element = __inputReference);
        builder.CloseElement();
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string? value, out ushort result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        var invalid = value is not null && value.Any(_ => (_ < '0' || _ > '7') && _ != ' ');
        result = invalid ? (ushort)0 : (ushort)Конвертер.Із8РічноїАдреси(int.Parse(value));
        validationErrorMessage = invalid ? "Не 8-річне число." : null;
        return !invalid;
    }

    /// <inheritdoc />
    protected override string? FormatValueAsString(ushort value)
    {
        return Конвертер.До8РічноїАдреси(value).ToString();
    }
}
