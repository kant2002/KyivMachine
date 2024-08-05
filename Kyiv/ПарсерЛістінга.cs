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
        int останняАдреса = 1;
        var результат = new Лістінг();
        ОдиницяКоду одиницяКоду = null!;
        foreach (var лінія in лінії)
        {
            if (лінія == "") continue;
            try
            {
                var частини = лінія.Split([' '], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (частини.Length == 5)
                {
                    if (частини[0].Length == 4)
                    {
                        if (!int.TryParse(частини[0], out var частинаАдреси))
                        {
                            throw new InvalidOperationException($"Цей формат не підтримується. {частини[0]} не число в лінії {лінія}");
                        }

                        var адреса = Із8РічноїАдреси(частинаАдреси);
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
                            throw new InvalidOperationException($"Цей формат не підтримується. Лінія {лінія}");
                        }

                        if (!int.TryParse(частини[0], out var частинаАдреси))
                        {
                            throw new InvalidOperationException($"Цей формат не підтримується. {частини[0]} не число в лінії {лінія}");
                        }

                        останняАдреса = (останняАдреса & ~7) + Із8РічноїАдреси(частинаАдреси);
                    }

                    одиницяКоду.Команди.Add(ПарсерКоманд.Сконвертувати(лінія.Split(' ', 2)[1]));
                }
                else if (частини.Length == 4)
                {
                    if (одиницяКоду == null)
                    {
                        одиницяКоду = new ОдиницяКоду(останняАдреса);
                        результат.ОдиниціКоду.Add(одиницяКоду);
                    }

                    одиницяКоду.Команди.Add(ПарсерКоманд.Сконвертувати(лінія));
                }
                else
                {
                    throw new InvalidOperationException($"Цей формат не підтримується. Лінія {лінія}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Не змогли обробити лінію {лінія}");
                throw;
            }
        }

        return результат;
    }
}
