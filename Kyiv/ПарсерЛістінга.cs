using Система.ВВ;
using static Kyiv.Конвертер;
namespace Kyiv;

public static class ПарсерЛістінга
{
    public static Лістінг ПрочитатиІзФайла(string файл)
    {
        var лінії = Файл.ПрочитатиУсіЛінії(файл);
        return ПрочитатиІзЛіній(лінії);
    }

    public static Лістінг ПрочитатиІзЛіній(string[] лінії)
    {
        int останняАдреса = 20;
        var результат = new Лістінг();
        ОдиницяКоду одиницяКоду = null!;// = new ОдиницяКоду(останняАдреса);
        foreach (var лінія in лінії)
        {
            var частини = лінія.Split([' '], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (частини.Length == 5)
            {
                if (частини[0].Length == 4)
                {
                    var адреса = Із8РічноїАдреси(int.Parse(частини[0]));
                    if (останняАдреса + 1 != адреса || одиницяКоду == null)
                    {
                        одиницяКоду = new ОдиницяКоду(адреса);
                        результат.ОдиниціКоду.Add(одиницяКоду);
                    }

                    останняАдреса = адреса;
                }
                else
                {
                    if (одиницяКоду == null)
                    {
                        throw new InvalidOperationException("Цей формат не підтримується");
                    }

                    останняАдреса = (останняАдреса & ~7) + Із8РічноїАдреси(int.Parse(частини[0]));
                }

                одиницяКоду.Команди.Add(ПарсерКоманд.Сконвертувати(лінія.Split(' ', 2)[1]));
            }
            else
            {
                throw new InvalidOperationException("Цей формат не підтримується");
            }
        }

        return результат;
    }
}
