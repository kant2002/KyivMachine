using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Kyiv;

public class ТекстовийПисарІзВиступами : TextWriter
{
    private readonly TextWriter _писатель;
    private readonly string _рядокТабів;
    private int _рівеньВідступу;
    private bool _очікуютьсяТаби;

    public const string УсталенийРядокТабів = "    ";

    public ТекстовийПисарІзВиступами(TextWriter писар) : this(писар, УсталенийРядокТабів) { }

    public ТекстовийПисарІзВиступами(TextWriter писар, string рядокТабів) : base(CultureInfo.InvariantCulture)
    {
        ArgumentNullException.ThrowIfNull(писар);

        _писатель = писар;
        _рядокТабів = рядокТабів;
        _очікуютьсяТаби = true;
    }

    public override Encoding Encoding => _писатель.Encoding;

    [AllowNull]
    public override string NewLine
    {
        get { return _писатель.NewLine; }
        set { _писатель.NewLine = value; }
    }

    public int Відступ
    {
        get { return _рівеньВідступу; }
        set { _рівеньВідступу = Math.Max(value, 0); }
    }

    public TextWriter ВнутрішнійПисар => _писатель;

    public override void Close() => _писатель.Close();

    /// <inheritdoc/>
    public override ValueTask DisposeAsync() => _писатель.DisposeAsync();

    public override void Flush() => _писатель.Flush();

    /// <inheritdoc/>
    public override Task FlushAsync() => _писатель.FlushAsync();

    /// <summary>
    /// Clears all buffers for this <see cref="ТекстовийПисарІзВиступами"/> asynchronously and causes any buffered data to be
    /// written to the underlying device.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous flush operation.</returns>
    public override Task FlushAsync(CancellationToken cancellationToken) =>
        cancellationToken.IsCancellationRequested ? Task.FromCanceled(cancellationToken) :
        GetType() != typeof(ТекстовийПисарІзВиступами) ? FlushAsync() :
        _писатель.FlushAsync(cancellationToken);

    protected virtual void OutputTabs()
    {
        if (_очікуютьсяТаби)
        {
            for (int i = 0; i < _рівеньВідступу; i++)
            {
                _писатель.Write(_рядокТабів);
            }
            _очікуютьсяТаби = false;
        }
    }

    /// <summary>
    /// Asynchronously outputs tabs to the underlying <see cref="TextWriter"/> based on the current <see cref="Відступ"/>.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected virtual async Task OutputTabsAsync()
    {
        if (_очікуютьсяТаби)
        {
            for (int i = 0; i < _рівеньВідступу; i++)
            {
                await _писатель.WriteAsync(_рядокТабів).ConfigureAwait(false);
            }
            _очікуютьсяТаби = false;
        }
    }

    public override void Write(string? s)
    {
        OutputTabs();
        _писатель.Write(s);
    }

    public override void Write(bool value)
    {
        OutputTabs();
        _писатель.Write(value);
    }

    public override void Write(char value)
    {
        OutputTabs();
        _писатель.Write(value);
    }

    public override void Write(char[]? buffer)
    {
        OutputTabs();
        _писатель.Write(buffer);
    }

    public override void Write(char[] buffer, int index, int count)
    {
        OutputTabs();
        _писатель.Write(buffer, index, count);
    }

    public override void Write(double value)
    {
        OutputTabs();
        _писатель.Write(value);
    }

    public override void Write(float value)
    {
        OutputTabs();
        _писатель.Write(value);
    }

    public override void Write(int value)
    {
        OutputTabs();
        _писатель.Write(value);
    }

    public override void Write(long value)
    {
        OutputTabs();
        _писатель.Write(value);
    }

    public override void Write(object? value)
    {
        OutputTabs();
        _писатель.Write(value);
    }

    public override void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
    {
        OutputTabs();
        _писатель.Write(format, arg0);
    }

    public override void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
    {
        OutputTabs();
        _писатель.Write(format, arg0, arg1);
    }

    public override void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[] arg)
    {
        OutputTabs();
        _писатель.Write(format, arg);
    }

    /// <summary>
    /// Writes out a formatted string, using the same semantics as specified.
    /// </summary>
    /// <param name="format">The formatting string to use.</param>
    /// <param name="arg">The argument span to output.</param>
    public override void Write([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params ReadOnlySpan<object?> arg)
    {
        OutputTabs();
        _писатель.Write(format, arg);
    }

    /// <summary>
    /// Asynchronously writes the specified <see cref="char"/> to the underlying <see cref="TextWriter"/>, inserting
    /// tabs at the start of every line.
    /// </summary>
    /// <param name="value">The <see cref="char"/> to write.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteAsync(char value)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteAsync(value).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously writes the specified number of <see cref="char"/>s from the specified buffer
    /// to the underlying <see cref="TextWriter"/>, starting at the specified index, and outputting tabs at the
    /// start of every new line.
    /// </summary>
    /// <param name="buffer">The array to write from.</param>
    /// <param name="index">Index in the array to stort writing at.</param>
    /// <param name="count">The number of characters to write.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteAsync(char[] buffer, int index, int count)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteAsync(buffer, index, count).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously writes the specified string to the underlying <see cref="TextWriter"/>, inserting tabs at the
    /// start of every line.
    /// </summary>
    /// <param name="value">The string to write.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteAsync(string? value)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteAsync(value).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously writes the specified characters to the underlying <see cref="TextWriter"/>, inserting tabs at the
    /// start of every line.
    /// </summary>
    /// <param name="buffer">The characters to write.</param>
    /// <param name="cancellationToken">Token for canceling the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteAsync(buffer, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously writes the contents of the specified <see cref="StringBuilder"/> to the underlying <see cref="TextWriter"/>, inserting tabs at the
    /// start of every line.
    /// </summary>
    /// <param name="value">The text to write.</param>
    /// <param name="cancellationToken">Token for canceling the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteAsync(StringBuilder? value, CancellationToken cancellationToken = default)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteAsync(value, cancellationToken).ConfigureAwait(false);
    }

    public void WriteLineNoTabs(string? s)
    {
        _писатель.WriteLine(s);
    }

    /// <summary>
    /// Asynchronously writes the specified string to the underlying <see cref="TextWriter"/> without inserting tabs.
    /// </summary>
    /// <param name="s">The string to write.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task WriteLineNoTabsAsync(string? s)
    {
        return _писатель.WriteLineAsync(s);
    }

    public override void WriteLine(string? s)
    {
        OutputTabs();
        _писатель.WriteLine(s);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine()
    {
        OutputTabs();
        _писатель.WriteLine();
        _очікуютьсяТаби = true;
    }

    public override void WriteLine(bool value)
    {
        OutputTabs();
        _писатель.WriteLine(value);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine(char value)
    {
        OutputTabs();
        _писатель.WriteLine(value);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine(char[]? buffer)
    {
        OutputTabs();
        _писатель.WriteLine(buffer);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine(char[] buffer, int index, int count)
    {
        OutputTabs();
        _писатель.WriteLine(buffer, index, count);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine(double value)
    {
        OutputTabs();
        _писатель.WriteLine(value);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine(float value)
    {
        OutputTabs();
        _писатель.WriteLine(value);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine(int value)
    {
        OutputTabs();
        _писатель.WriteLine(value);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine(long value)
    {
        OutputTabs();
        _писатель.WriteLine(value);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine(object? value)
    {
        OutputTabs();
        _писатель.WriteLine(value);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0)
    {
        OutputTabs();
        _писатель.WriteLine(format, arg0);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, object? arg0, object? arg1)
    {
        OutputTabs();
        _писатель.WriteLine(format, arg0, arg1);
        _очікуютьсяТаби = true;
    }

    public override void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[] arg)
    {
        OutputTabs();
        _писатель.WriteLine(format, arg);
        _очікуютьсяТаби = true;
    }

    /// <summary>
    /// Writes out a formatted string, followed by a line terminator, using the same semantics as specified.
    /// </summary>
    /// <param name="format">The formatting string to use.</param>
    /// <param name="arg">The argument span to output.</param>
    public override void WriteLine([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params ReadOnlySpan<object?> arg)
    {
        OutputTabs();
        _писатель.WriteLine(format, arg);
        _очікуютьсяТаби = true;
    }

    //[CLSCompliant(false)]
    public override void WriteLine(uint value)
    {
        OutputTabs();
        _писатель.WriteLine(value);
        _очікуютьсяТаби = true;
    }

    /// <inheritdoc/>
    public override async Task WriteLineAsync()
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteLineAsync().ConfigureAwait(false);
        _очікуютьсяТаби = true;
    }

    /// <summary>
    /// Asynchronously writes the specified <see cref="char"/> to the underlying <see cref="TextWriter"/> followed by a line terminator, inserting tabs
    /// at the start of every line.
    /// </summary>
    /// <param name="value">The character to write.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteLineAsync(char value)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteLineAsync(value).ConfigureAwait(false);
        _очікуютьсяТаби = true;
    }

    /// <summary>
    /// Asynchronously writes the specified number of characters from the specified buffer followed by a line terminator,
    /// to the underlying <see cref="TextWriter"/>, starting at the specified index within the buffer, inserting tabs at the start of every line.
    /// </summary>
    /// <param name="buffer">The buffer containing characters to write.</param>
    /// <param name="index">The index within the buffer to start writing at.</param>
    /// <param name="count">The number of characters to write.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteLineAsync(char[] buffer, int index, int count)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteLineAsync(buffer, index, count).ConfigureAwait(false);
        _очікуютьсяТаби = true;
    }

    /// <summary>
    /// Asynchronously writes the specified string followed by a line terminator to the underlying <see cref="TextWriter"/>, inserting
    /// tabs at the start of every line.
    /// </summary>
    /// <param name="value">The string to write.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteLineAsync(string? value)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteLineAsync(value).ConfigureAwait(false);
        _очікуютьсяТаби = true;
    }

    /// <summary>
    /// Asynchronously writes the specified characters followed by a line terminator to the underlying <see cref="TextWriter"/>, inserting
    /// tabs at the start of every line.
    /// </summary>
    /// <param name="buffer">The characters to write.</param>
    /// <param name="cancellationToken">Token for canceling the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteLineAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteLineAsync(buffer, cancellationToken).ConfigureAwait(false);
        _очікуютьсяТаби = true;
    }

    /// <summary>
    /// Asynchronously writes the contents of the specified <see cref="StringBuilder"/> followed by a line terminator to the
    /// underlying <see cref="TextWriter"/>, inserting tabs at the start of every line.
    /// </summary>
    /// <param name="value">The text to write.</param>
    /// <param name="cancellationToken">Token for canceling the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public override async Task WriteLineAsync(StringBuilder? value, CancellationToken cancellationToken = default)
    {
        await OutputTabsAsync().ConfigureAwait(false);
        await _писатель.WriteLineAsync(value, cancellationToken).ConfigureAwait(false);
        _очікуютьсяТаби = true;
    }
}