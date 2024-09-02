using static Kyiv.Конвертер;

namespace Kyiv;

abstract record Операція();
abstract record Вираз();
enum ТипУнарноїОперації
{
    Модуль,
    БітовеНі,
}
record УнарнаОперація(ТипУнарноїОперації Тип, Вираз Вираз) : Вираз
{
    public override string ToString()
    {
        switch (Тип)
        {
            case ТипУнарноїОперації.Модуль:
                return $"|{Вираз}|";
            case ТипУнарноїОперації.БітовеНі:
                return $"~({Вираз})";
            default:
                throw new NotImplementedException($"Невідомий тип унарної операції {Тип}");
        }
    }
}
enum ТипБінарноїОперації
{
    Додавання,
    Віднімання,
    Множення,
    Ділення,
    ДодаванняКоманд,
    ЦиклічнеДодавання,
    МноженняБезСкругленням,

    Дорівнює,
    МеншеЧиДорівнює,

    ЛогічнеДодавання,
    ЛогічнеМноження,
    ЛогічнаВиключнеАбо,
    СдвигВправо,
    СдвигВліво,

    // Синтетичні операції
    НеДорівнює,
}
record БінарнаОперація(ТипБінарноїОперації Тип, Вираз Вираз1, Вираз Вираз2) : Вираз
{
    public override string ToString()
    {
        return $"{В(Вираз1)} {ТипОперації()} {В(Вираз2)}";
    }

    private static string В(Вираз вираз)
    {
        if (вираз is БінарнаОперація) return $"({вираз})";
        if (вираз is УнарнаОперація) return $"({вираз})";
        return $"{вираз}";
    }

    private string ТипОперації()
    {
        switch (Тип)
        {
            case ТипБінарноїОперації.Додавання:
                return "+";
            case ТипБінарноїОперації.Віднімання:
                return "-";
            case ТипБінарноїОперації.Множення:
                return "*";
            case ТипБінарноїОперації.Ділення:
                return "/";
            case ТипБінарноїОперації.МноженняБезСкругленням:
                return "|*|";
            case ТипБінарноїОперації.ДодаванняКоманд:
                return "ДодК";
            case ТипБінарноїОперації.ЦиклічнеДодавання:
                return "ДодЦ";

            case ТипБінарноїОперації.Дорівнює:
                return "==";
            case ТипБінарноїОперації.МеншеЧиДорівнює:
                return "<=";

            case ТипБінарноїОперації.ЛогічнеДодавання:
                return "|";
            case ТипБінарноїОперації.ЛогічнеМноження:
                return "&";
            case ТипБінарноїОперації.ЛогічнаВиключнеАбо:
                return "^";

            case ТипБінарноїОперації.СдвигВліво:
                return "<<";
            case ТипБінарноїОперації.СдвигВправо:
                return ">>";

            case ТипБінарноїОперації.НеДорівнює:
                return "!=";
            default:
                throw new NotImplementedException($"Невідомий тип бінарної операції {Тип}");
        }
    }
};
record ЗберіганняЗмінної(Вираз МісцеЗберігання, Вираз Що) : Операція
{
    public override string ToString()
    {
        return $"{МісцеЗберігання} = {Що};";
    }
};
record УмовнаОперація(Вираз Умова, Операція Що) : Операція;
record УмовнаОперація2(Вираз Умова, Операція Що, Операція Інакше) : Операція;
record БлокОперацій(Операція[] Операції) : Операція;
record Перехід(int адреса) : Операція
{
    public override string ToString()
    {
        return $"goto lbl_{До8РічноїАдреси(адреса)};";
    }
}
record Повернутися() : Операція
{
    public override string ToString()
    {
        return $"lngjmp;";
    }
};
record ВстановитиТочкуПовернення(int адреса) : Операція
{
    public override string ToString()
    {
        return $"setjmp {До8РічноїАдреси(адреса)};";
    }
}

record Ідентифікатор(string назва) : Вираз
{
    public override string ToString()
    {
        return назва;
    }
};

record Константа(int значення) : Вираз
{
    public override string ToString()
    {
        return $"{До8РічноїАдреси(значення)}";
    }
};
record Число(ulong значення) : Вираз
{
    public override string ToString()
    {
        return $"0x{значення:X}";
    }
};
record АдресаПамяти(Вираз адреса) : Вираз
{
    public override string ToString()
    {
        if (адреса is Регістр)
        {
            return $"п[{адреса}]";
        }

        return $"п[{адреса}]";
    }
};
enum ТипРегістра
{
    С,
    К,
    Р,
    Ц,
    А,
}
record Регістр(ТипРегістра регістр) : Вираз
{
    public override string ToString()
    {
        return регістр.ToString();
    }
};
record ВвідЧисел(int від, int по) : Операція
{
    public override string ToString()
    {
        return $"inputNumbers({До8РічноїАдреси(від)}, {До8РічноїАдреси(по)})";
    }
};
record ВвідКодів(int від, int по) : Операція
{
    public override string ToString()
    {
        return $"inputCodes({До8РічноїАдреси(від)}, {До8РічноїАдреси(по)})";
    }
};

record ВивідКодів(int від, int по) : Операція
{
    public override string ToString()
    {
        return $"printCodes({До8РічноїАдреси(від)}, {До8РічноїАдреси(по)})";
    }
};
record ЗаписатиКодаНаБарабан(int від, int по) : Операція
{
    public override string ToString()
    {
        return $"writeCodesToReel({До8РічноїАдреси(від)}, {До8РічноїАдреси(по)})";
    }
};
record ПрочитатиКодаІзБарабана(int від, int по) : Операція
{
    public override string ToString()
    {
        return $"readCodesFromReel({До8РічноїАдреси(від)}, {До8РічноїАдреси(по)})";
    }
};
record ПідготуватиБарабан(int тип, int адреса, int барабан) : Операція
{
    public override string ToString()
    {
        return $"prepareReel({тип}, {адреса}, {барабан})";
    }
};
record Стоп() : Операція
{
    public override string ToString()
    {
        return "exit();";
    }
};
record Цикл(int А, int Ц, БлокОперацій Операції) : Операція;
record НевідомаОперація(ulong команда) : Операція
{
    public override string ToString()
    {
        return "// Невідома команда " + ПарсерКоманд.Сконвертувати(команда);
    }
};
