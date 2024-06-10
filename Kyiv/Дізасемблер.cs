using System.Linq;

namespace Kyiv;

public class Дізасемблер
{
    public static string Дізасемблювати(string команда)
    {
        var лінії = команда.ReplaceLineEndings().Split(Environment.NewLine);
        List<string> команди = new List<string>();
        foreach (var лінія in лінії)
        {
            if (string.IsNullOrWhiteSpace(лінія))
            {
                команди.Add(лінія);
            }
            else
            {
                try
                {
                    команди.Add(ДоАссемблера(ПарсерКоманд.Розібрати(лінія)));
                }
                catch
                {
                    команди.Add("// Невідома команда " + лінія);
                }
            }
        }    

        return string.Join(Environment.NewLine, команди);
    }

    private static string ДоАссемблера(СтруктураКоманди команда)
    {
        switch (команда.Код)
        {
            case КодОперації.ОстановМашины:
            case КодОперації.ПереходПоРегиструВозврата:
                return команда.Код.ToString();
            case КодОперації.ПереходПоФиксатору:
                return $"{команда.Код} {Адреса(команда.Адреса1)},{Адреса(команда.Адреса3)}";
            default:
                return $"{команда.Код} {Адреса(команда.Адреса1)},{Адреса(команда.Адреса2)},{Адреса(команда.Адреса3)}";
        }
    }

    private static string Адреса(int адреса)
    {
        var базоваАдреса = адреса & 0x7FF;
        if ((адреса & (1 << 11)) != 0)
        {
            return $"[{До8РічноїАдреси(базоваАдреса)}]";
        }

        return До8РічноїАдреси(базоваАдреса).ToString();
    }

    private static int До8РічноїАдреси(int ячейка) => (ячейка / (8 * 8 * 8)) * 1000 + (ячейка % (8 * 8 * 8) / (8 * 8)) * 100 + (ячейка % (8 * 8) / 8) * 10 + ячейка % 8;
}
