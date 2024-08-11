namespace Kyiv;

public class Лістінг
{
    public List<ОдиницяКоду> ОдиниціКоду { get; } = [];

    public int ПочатковаАдреса => ОдиниціКоду.FirstOrDefault()?.ПочатковаАдреса ?? 0;
}
