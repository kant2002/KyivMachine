﻿using System.Linq;

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
                    команди.Add(ДоАссемблера(ПарсерКоманд.Розібрати(лінія), true));
                }
                catch
                {
                    команди.Add("// Невідома команда " + лінія);
                }
            }
        }    

        return string.Join(Environment.NewLine, команди);
    }

    private static string ДоАссемблера(СтруктураКоманди команда, bool html)
    {
        switch (команда.Код)
        {
            case КодОперації.ОстановМашины:
            case КодОперації.ПереходПоРегиструВозврата:
                return команда.Код.ToString();
            case КодОперації.ПереходПоФиксатору:
                return $"{команда.Код} {Адреса(команда.Адреса1, html)}, {Адреса(команда.Адреса3, html)}";
            default:
                return $"{команда.Код} {Адреса(команда.Адреса1, html)}, {Адреса(команда.Адреса2, html)}, {Адреса(команда.Адреса3, html)}";
        }
    }

    private static string Адреса(int адреса, bool html)
    {
        // загально відомі ячейки
        if (адреса == 2) return "<code>парам</code>";
        if (адреса == 3) return "<code>рез</code>";
        if (адреса == 4) return "<code>тимч1</code>";
        if (адреса == 5) return "<code>тимч2</code>";
        if (адреса == 6) return "<code>тимч3</code>";

        // константи
        if (До8РічноїАдреси(адреса) == 3010) return "<code>ДваУМінус16Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3011) return "<code>ДваУМінус28Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3012) return "<code>ДваУМінус40Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3017) return "<code>ДваУМінус15Ступіні</code>";

        if (До8РічноїАдреси(адреса) == 3020) return "<code>ДваУМінус27Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3021) return "<code>ДваУМінус39Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3025) return "<code>Мінус15_16их</code>";
        if (До8РічноїАдреси(адреса) == 3026) return "<code>МінусНуль</code>";

        if (До8РічноїАдреси(адреса) == 3035) return "<code>МашиннаОдиниця</code>";
        if (До8РічноїАдреси(адреса) == 3036) return "<code>МінусМашиннаОдиниця</code>";
        if (До8РічноїАдреси(адреса) == 3037) return "<code>Log10_2</code>";

        if (До8РічноїАдреси(адреса) == 3040) return "<code>ДваУМінус12Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3041) return "<code>ДваУМінус24Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3042) return "<code>ДваУМінус1Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3043) return "<code>ДваУМінус2Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3044) return "<code>ДваУМінус3Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3045) return "<code>ДваУМінус4Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3046) return "<code>ДваУМінус6Ступіні</code>";
        if (До8РічноїАдреси(адреса) == 3047) return "<code>ДваУМінус36Ступіні</code>";

        if (До8РічноїАдреси(адреса) == 3050) return "<code>Плюс10_16их</code>";
        if (До8РічноїАдреси(адреса) == 3051) return "<code>Ln2</code>";
        if (До8РічноїАдреси(адреса) == 3052) return "<code>ОднаДесята</code>";
        if (До8РічноїАдреси(адреса) == 3053) return "<code>ОднаСота</code>";
        if (До8РічноїАдреси(адреса) == 3054) return "<code>ОднаТисячна</code>";
        if (До8РічноїАдреси(адреса) == 3055) return "<code>ДвіДесятих</code>";
        if (До8РічноїАдреси(адреса) == 3056) return "<code>ТриДесятих</code>";
        if (До8РічноїАдреси(адреса) == 3057) return "<code>ВісімДесятих</code>";

        if (До8РічноїАдреси(адреса) == 3060) return "<code>ДвіТисячних</code>";
        if (До8РічноїАдреси(адреса) == 3061) return "<code>ШіснадцятьСотих</code>";
        if (До8РічноїАдреси(адреса) == 3062) return "<code>ТридьцятьДвіСотих</code>";
        if (До8РічноїАдреси(адреса) == 3063) return "<code>ОдиницяНаПі</code>";
        if (До8РічноїАдреси(адреса) == 3064) return "<code>ОдиницяНаКоріньІзПі</code>";
        if (До8РічноїАдреси(адреса) == 3065) return "<code>ОдиницяНаЕ</code>";
        if (До8РічноїАдреси(адреса) == 3066) return "<code>ПіНаЧотири</code>";
        if (До8РічноїАдреси(адреса) == 3067) return "<code>ДваНаПі</code>";

        if (До8РічноїАдреси(адреса) == 3070) return "<code>КоріньДвійкиНаДва</code>";
        if (До8РічноїАдреси(адреса) == 3071) return "<code>ОдинНаКоріньІзТрьох</code>";
        if (До8РічноїАдреси(адреса) == 3072) return "<code>ЕНаТри</code>";
        if (До8РічноїАдреси(адреса) == 3073) return "<code>ОдинНаКоріньІзДваПі</code>";
        if (До8РічноїАдреси(адреса) == 3074) return "<code>ЕНаЧотири</code>";
        if (До8РічноїАдреси(адреса) == 3075) return "<code>ОднаТретя</code>";
        if (До8РічноїАдреси(адреса) == 3076) return "<code>ОдинНаПіКвадрат</code>";
        if (До8РічноїАдреси(адреса) == 3077) return "<code>Lg_E</code>";

        var базоваАдреса = адреса & 0x7FF;
        if ((адреса & (1 << 11)) != 0)
        {
            return $"[{До8РічноїАдреси(базоваАдреса)}]";
        }

        return До8РічноїАдреси(базоваАдреса).ToString();
    }

    private static int До8РічноїАдреси(int ячейка) => (ячейка / (8 * 8 * 8)) * 1000 + (ячейка % (8 * 8 * 8) / (8 * 8)) * 100 + (ячейка % (8 * 8) / 8) * 10 + ячейка % 8;
}
