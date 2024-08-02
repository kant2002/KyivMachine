namespace Kyiv;

public record ОдиницяКоду(int ПочатковаАдреса)
{
    public List<ulong> Команди { get; } = [];

    public int ОстанняАдреса => ПочатковаАдреса + Команди.Count - 1;

    public ulong this[int адреса]
    {
        get
        {
            if (адреса < ПочатковаАдреса || адреса > ОстанняАдреса)
            {
                throw new ArgumentOutOfRangeException(nameof(адреса));
            }

            return Команди[адреса - ПочатковаАдреса];
        }
    }
}
