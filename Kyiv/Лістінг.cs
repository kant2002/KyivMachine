namespace Kyiv;

public class Лістінг
{
    public List<ОдиницяКоду> ОдиниціКоду { get; } = [];
    internal List<БлокКоду> БлокиКоду { get; } = [];

    public int ПочатковаАдреса => ОдиниціКоду.FirstOrDefault()?.ПочатковаАдреса ?? 0;
}
