namespace Kyiv;

internal record БлокКоду(int ПочатковаАдреса)
{
    public List<Операція> Операції { get; } = [];

    public int ОстанняАдреса => ПочатковаАдреса + Операції.Count - 1;

    public Операція this[int адреса]
    {
        get
        {
            if (адреса < ПочатковаАдреса || адреса > ОстанняАдреса)
            {
                throw new ArgumentOutOfRangeException(nameof(адреса));
            }

            return Операції[адреса - ПочатковаАдреса];
        }
    }
}
