﻿using System.Diagnostics;
using System.Reflection.PortableExecutable;
using static Kyiv.Конвертер;

namespace Kyiv;

public class МашинаКиїв
{
    private const ulong SignFlag = 1UL << 40;

    /// <summary>
    /// счетчик команд
    /// </summary>
    /// <remarks>11-бітний</remarks>
    public ushort РегістрС = 1;

    /// <summary>
    /// регистр команд
    /// </summary>
    /// <remarks>41-бітний</remarks>
    public ulong РегістрК;

    /// <summary>
    /// регистр возврата
    /// </summary>
    /// <remarks>11-бітний</remarks>
    public ushort РегістрР;

    /// <summary>
    /// регистр циклов 
    /// </summary>
    /// <remarks>11-бітний</remarks>
    public ushort РегістрЦ;

    /// <summary>
    /// регистра модификации адресов
    /// </summary>
    /// <remarks>11-бітний</remarks>
    public ushort РегістрА;

    /// <summary>
    /// регистр-триггер аварийного останова
    /// </summary>
    public bool АварійнаЗупинка;

    /// <summary>
    /// тумблер блокировки аварийного останова
    /// </summary>
    public bool ТумблерБлокировкиАварийногоОстанова;

    public ulong[] ОперативноеЗапоминающееУстройство = new ulong[1024];
    public ulong[] ПассивноеЗапоминающееУстройство = new ulong[512];
    public ulong[] ВнешняяПамять = new ulong[9864];
    private bool ФлагПереповнення;
    private const long МінімальнеНегативнеЧисло = -(long.MaxValue >> 23);
    private const long МаксимальнеПозітивнеЧисло = long.MaxValue >> 23;// 0x0FF_FFFF_FFFF;

    public МашинаКиїв()
    {
        // сторінка 83
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(10)] = ПарсерКоманд.Сконвертувати("00 0001 0000 0000"); // 2^-16
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(11)] = ПарсерКоманд.Сконвертувати("00 0000 0001 0000"); // 2^-28
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(12)] = ПарсерКоманд.Сконвертувати("00 0000 0000 0001"); // 2^-40
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(13)] = ПарсерКоманд.Сконвертувати("00 0001 0001 0001");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(14)] = ПарсерКоманд.Сконвертувати("00 0001 0001 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(15)] = ПарсерКоманд.Сконвертувати("00 0000 0001 0001");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(16)] = ПарсерКоманд.Сконвертувати("00 0001 0000 0001");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(17)] = ПарсерКоманд.Сконвертувати("00 0002 0000 0000"); // 2^-15

        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(20)] = ПарсерКоманд.Сконвертувати("00 0000 0002 0000"); // 2^-27
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(21)] = ПарсерКоманд.Сконвертувати("00 0000 0000 0002"); // 2^-39
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(22)] = ПарсерКоманд.Сконвертувати("00 7777 0000 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(23)] = ПарсерКоманд.Сконвертувати("00 0000 7777 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(24)] = ПарсерКоманд.Сконвертувати("00 0000 0000 7777");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(25)] = ПарсерКоманд.Сконвертувати("37 0000 0000 0000"); // -15/16
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(26)] = ПарсерКоманд.Сконвертувати("20 0000 0000 0000"); // -0
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(27)] = ПарсерКоманд.Сконвертувати("37 0000 7777 7777");

        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(30)] = ПарсерКоманд.Сконвертувати("00 7777 7777 7777");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(31)] = ПарсерКоманд.Сконвертувати("37 7777 0000 7777");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(32)] = ПарсерКоманд.Сконвертувати("37 7777 7777 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(33)] = ПарсерКоманд.Сконвертувати("00 7777 0000 7777");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(34)] = ПарсерКоманд.Сконвертувати("00 0000 7777 7777");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(35)] = ПарсерКоманд.Сконвертувати("17 7777 7777 7777"); // Машинна одиниця 1-2^-40
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(36)] = ПарсерКоманд.Сконвертувати("37 7777 7777 7777"); // -(1-2^-40)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(37)] = ПарсерКоманд.Сконвертувати("04 6420 2324 1220"); // lg2

        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(40)] = ПарсерКоманд.Сконвертувати("00 0020 0000 0000"); // 2^-12
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(41)] = ПарсерКоманд.Сконвертувати("00 0000 0020 0000"); // 2^-24
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(42)] = ПарсерКоманд.Сконвертувати("10 0000 0000 0000"); // 2^-1
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(43)] = ПарсерКоманд.Сконвертувати("04 0000 0000 0000"); // 2^-2
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(44)] = ПарсерКоманд.Сконвертувати("02 0000 0000 0000"); // 2^-3
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(45)] = ПарсерКоманд.Сконвертувати("01 0000 0000 0000"); // 2^-4
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(46)] = ПарсерКоманд.Сконвертувати("00 2000 0000 0000"); // 2^-6
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(47)] = ПарсерКоманд.Сконвертувати("00 0000 0000 0020"); // 2^-36

        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(50)] = ПарсерКоманд.Сконвертувати("12 0000 0000 0000"); // 10/16
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(51)] = ПарсерКоманд.Сконвертувати("13 0562 0577 3722"); // ln2
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(52)] = ПарсерКоманд.Сконвертувати("01 4631 4631 4632"); // 0,1
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(53)] = ПарсерКоманд.Сконвертувати("00 1217 2702 4366"); // 0,01
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(54)] = ПарсерКоманд.Сконвертувати("00 0101 4223 3514"); // 0,001
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(55)] = ПарсерКоманд.Сконвертувати("03 1463 1463 1463"); // 0,2 = 1/5
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(56)] = ПарсерКоманд.Сконвертувати("04 6314 6314 6315"); // 0,3
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(57)] = ПарсерКоманд.Сконвертувати("14 6314 6314 6315"); // 0,8 = 4/5

        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(60)] = ПарсерКоманд.Сконвертувати("00 0203 0446 7230"); // 0,002 = 1/500
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(61)] = ПарсерКоманд.Сконвертувати("02 4365 6050 7534"); // 0,16 = 4/25
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(62)] = ПарсерКоманд.Сконвертувати("05 0753 4121 7270"); // 0,32
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(63)] = ПарсерКоманд.Сконвертувати("05 0574 6033 3447"); // 1/π
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(64)] = ПарсерКоманд.Сконвертувати("11 0156 5650 1025"); // 1/sqrt(π)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(65)] = ПарсерКоманд.Сконвертувати("05 7055 2615 4264"); // 1/e
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(66)] = ПарсерКоманд.Сконвертувати("14 4417 6652 1042"); // π/4
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(67)] = ПарсерКоманд.Сконвертувати("12 1371 4066 7116"); // 2/π  

        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(70)] = ПарсерКоманд.Сконвертувати("13 2404 7463 1772"); // sqrt(2)/2
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(71)] = ПарсерКоманд.Сконвертувати("11 1715 1642 6202"); // 1/sqrt(3)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(72)] = ПарсерКоманд.Сконвертувати("16 3765 6134 5604"); // e/3
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(73)] = ПарсерКоманд.Сконвертувати("06 3041 0514 7521"); // 1/sqrt(2π)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(74)] = ПарсерКоманд.Сконвертувати("12 6770 2505 4243"); // e/4
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(75)] = ПарсерКоманд.Сконвертувати("05 2525 2525 2525"); // 1/3
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(76)] = ПарсерКоманд.Сконвертувати("01 4760 1366 1043"); // 1/π^2
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(77)] = ПарсерКоманд.Сконвертувати("06 7455 7305 2237"); // М = log10(е)

        // сторінка 87 перевод из двоичной системы счисления в десятичную
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(100)] = ПарсерКоманд.Сконвертувати("01 0000 0000 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(101)] = ПарсерКоманд.Сконвертувати("26 0012 0000 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(102)] = ПарсерКоманд.Сконвертувати("11 0002 3050 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(103)] = ПарсерКоманд.Сконвертувати("10 3047 0002 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(104)] = ПарсерКоманд.Сконвертувати("12 0003 3045 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(105)] = ПарсерКоманд.Сконвертувати("01 0004 0003 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(106)] = ПарсерКоманд.Сконвертувати("12 0004 3047 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(107)] = ПарсерКоманд.Сконвертувати("02 0002 0004 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(110)] = ПарсерКоманд.Сконвертувати("12 0002 3045 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(111)] = ПарсерКоманд.Сконвертувати("27 4001 3102 3146");
        // сторінка 91 ln(X)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(112)] = ПарсерКоманд.Сконвертувати("01 5712 7226 4561");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(113)] = ПарсерКоманд.Сконвертувати("02 2346 6040 1441");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(114)] = ПарсерКоманд.Сконвертувати("03 6616 1114 4322");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(115)] = ПарсерКоманд.Сконвертувати("13 4252 1661 7650");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(116)] = ПарсерКоманд.Сконвертувати("01 3020 0000 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(117)] = ПарсерКоманд.Сконвертувати("05 3070 0002 3123");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(120)] = ПарсерКоманд.Сконвертувати("12 0002 3070 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(121)] = ПарсерКоманд.Сконвертувати("01 0005 З011 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(122)] = ПарсерКоманд.Сконвертувати("05 0000 0000 3117");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(123)] = ПарсерКоманд.Сконвертувати("12 З011 0005 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(124)] = ПарсерКоманд.Сконвертувати("02 0005 3020 0006");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(125)] = ПарсерКоманд.Сконвертувати("12 0006 0005 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(126)] = ПарсерКоманд.Сконвертувати("11 0002 3042 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(127)] = ПарсерКоманд.Сконвертувати("02 0002 3042 0006");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(130)] = ПарсерКоманд.Сконвертувати("01 0002 3042 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(131)] = ПарсерКоманд.Сконвертувати("12 0006 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(132)] = ПарсерКоманд.Сконвертувати("11 0002 0002 0006");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(133)] = ПарсерКоманд.Сконвертувати("12 0002 3043 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(134)] = ПарсерКоманд.Сконвертувати("26 0003 0000 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(135)] = ПарсерКоманд.Сконвертувати("01 3112 0000 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(136)] = ПарсерКоманд.Сконвертувати("11 0003 0006 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(137)] = ПарсерКоманд.Сконвертувати("01 0003 7113 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(140)] = ПарсерКоманд.Сконвертувати("27 4001 3136 3141");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(141)] = ПарсерКоманд.Сконвертувати("11 0003 0002 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(142)] = ПарсерКоманд.Сконвертувати("11 0003 0004 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(143)] = ПарсерКоманд.Сконвертувати("11 0005 3042 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(144)] = ПарсерКоманд.Сконвертувати("02 0003 0005 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(145)] = ПарсерКоманд.Сконвертувати("11 0003 3051 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(146)] = ПарсерКоманд.Сконвертувати("32 0000 0000 0000");
        // сторінка 89 1/2 * cosX (-1 <x < 1)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(147)] = ПарсерКоманд.Сконвертувати("11 0002 3067 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(150)] = ПарсерКоманд.Сконвертувати("06 3035 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(151)] = ПарсерКоманд.Сконвертувати("05 0000 0000 3153");
        // сторінка 89 1/2 * sinX (-1 <x < 1)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(152)] = ПарсерКоманд.Сконвертувати("11 0002 3067 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(153)] = ПарсерКоманд.Сконвертувати("11 0002 0002 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(154)] = ПарсерКоманд.Сконвертувати("26 0004 0000 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(155)] = ПарсерКоманд.Сконвертувати("01 3172 0000 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(156)] = ПарсерКоманд.Сконвертувати("11 0003 0004 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(157)] = ПарсерКоманд.Сконвертувати("01 0003 7173 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(160)] = ПарсерКоманд.Сконвертувати("27 4001 3156 3161");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(161)] = ПарсерКоманд.Сконвертувати("11 0003 0002 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(162)] = ПарсерКоманд.Сконвертувати("32 0000 0000 0000");
        //...сторінка 91 sqrt(x)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(163)] = ПарсерКоманд.Сконвертувати("01 0000 3035 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(164)] = ПарсерКоманд.Сконвертувати("12 0002 0003 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(165)] = ПарсерКоманд.Сконвертувати("02 0004 0003 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(166)] = ПарсерКоманд.Сконвертувати("11 0004 3042 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(167)] = ПарсерКоманд.Сконвертувати("01 0003 0004 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(170)] = ПарсерКоманд.Сконвертувати("05 3047 0004 3164");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(171)] = ПарсерКоманд.Сконвертувати("32 0000 0000 0000");
        //...сторінка 89
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(172)] = ПарсерКоманд.Сконвертувати("00 0004 7553 6722");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(173)] = ПарсерКоманд.Сконвертувати("20 0231 1146 1443");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(174)] = ПарсерКоманд.Сконвертувати("00 5063 2127 5453");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(175)] = ПарсерКоманд.Сконвертувати("25 1256 7405 5264");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(176)] = ПарсерКоманд.Сконвертувати("14 4417 6651 0101");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(177)] = ПарсерКоманд.Сконвертувати("20 0000 0000 0001");
        // недокуменсоане значення 2^-5
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(201)] = ПарсерКоманд.Сконвертувати("00 4000 0000 0000");
        // сторінка 92 e(x)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(202)] = ПарсерКоманд.Сконвертувати("06 3025 3044 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(203)] = ПарсерКоманд.Сконвертувати("01 0000 0004 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(204)] = ПарсерКоманд.Сконвертувати("11 0002 3201 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(205)] = ПарсерКоманд.Сконвертувати("11 0002 0002 0006");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(206)] = ПарсерКоманд.Сконвертувати("12 0006 0005 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(207)] = ПарсерКоманд.Сконвертувати("02 0004 3044 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(210)] = ПарсерКоманд.Сконвертувати("01 0004 0005 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(211)] = ПарсерКоманд.Сконвертувати("05 3044 0004 3206");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(212)] = ПарсерКоманд.Сконвертувати("02 0005 0002 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(213)] = ПарсерКоманд.Сконвертувати("11 0002 3042 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(214)] = ПарсерКоманд.Сконвертувати("12 0002 0005 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(215)] = ПарсерКоманд.Сконвертувати("01 0002 3043 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(216)] = ПарсерКоманд.Сконвертувати("32 0000 0000 0000");
        // сторінка 89 1/2 * cosX (—2π < x < 2π)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(217)] = ПарсерКоманд.Сконвертувати("05 0002 3042 3221");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(220)] = ПарсерКоманд.Сконвертувати("06 3035 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(221)] = ПарсерКоманд.Сконвертувати("05 0002 3043 3237");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(222)] = ПарсерКоманд.Сконвертувати("06 3042 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(223)] = ПарсерКоманд.Сконвертувати("01 3026 0000 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(224)] = ПарсерКоманд.Сконвертувати("12 0002 3241 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(225)] = ПарсерКоманд.Сконвертувати("06 3035 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(226)] = ПарсерКоманд.Сконвертувати("11 0002 0002 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(227)] = ПарсерКоманд.Сконвертувати("26 0004 0000 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(230)] = ПарсерКоманд.Сконвертувати("01 3172 0000 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(231)] = ПарсерКоманд.Сконвертувати("11 0003 0004 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(232)] = ПарсерКоманд.Сконвертувати("01 0003 7173 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(233)] = ПарсерКоманд.Сконвертувати("27 4001 3231 3234");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(234)] = ПарсерКоманд.Сконвертувати("11 0003 0002 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(235)] = ПарсерКоманд.Сконвертувати("14 0005 0003 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(236)] = ПарсерКоманд.Сконвертувати("32 0000 0000 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(237)] = ПарсерКоманд.Сконвертувати("01 0000 0000 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(240)] = ПарсерКоманд.Сконвертувати("04 0000 0000 3224");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(241)] = ПарсерКоманд.Сконвертувати("04 0000 0000 0001");
        // сторінка 93 1/π * arcsinX (— 1 < x < 1)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(242)] = ПарсерКоманд.Сконвертувати("02 0000 0000 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(243)] = ПарсерКоманд.Сконвертувати("05 0000 0000 3245");
        // сторінка 93 1/π * arccosX (— 1 < x < 1)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(244)] = ПарсерКоманд.Сконвертувати("01 0000 0000 0004");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(245)] = ПарсерКоманд.Сконвертувати("01 0000 0000 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(246)] = ПарсерКоманд.Сконвертувати("01 3042 0000 0006");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(247)] = ПарсерКоманд.Сконвертувати("11 0002 0002 0005");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(250)] = ПарсерКоманд.Сконвертувати("31 0002 3251 3253");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(251)] = ПарсерКоманд.Сконвертувати("02 0005 3042 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(252)] = ПарсерКоманд.Сконвертувати("05 0000 0000 3255");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(253)] = ПарсерКоманд.Сконвертувати("14 0003 0006 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(254)] = ПарсерКоманд.Сконвертувати("02 3042 0005 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(255)] = ПарсерКоманд.Сконвертувати("12 0002 3263 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(256)] = ПарсерКоманд.Сконвертувати("10 3042 0006 0006");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(257)] = ПарсерКоманд.Сконвертувати("05 3012 0006 3247");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(260)] = ПарсерКоманд.Сконвертувати("31 0004 3262 3261");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(261)] = ПарсерКоманд.Сконвертувати("02 3042 0003 0003");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(262)] = ПарсерКоманд.Сконвертувати("32 0000 0000 0000");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(263)] = ПарсерКоманд.Сконвертувати("10 0000 0000 0001");
        // сторінка 89 1/2 * sinX (— 2π < x < 2π)
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(264)] = ПарсерКоманд.Сконвертувати("04 0000 0002 3266");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(265)] = ПарсерКоманд.Сконвертувати("01 3035 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(266)] = ПарсерКоманд.Сконвертувати("04 0002 3042 3273");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(267)] = ПарсерКоманд.Сконвертувати("02 3035 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(270)] = ПарсерКоманд.Сконвертувати("04 0002 3043 3272");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(271)] = ПарсерКоманд.Сконвертувати("02 3042 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(272)] = ПарсерКоманд.Сконвертувати("02 0000 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(273)] = ПарсерКоманд.Сконвертувати("04 0002 3043 3275");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(274)] = ПарсерКоманд.Сконвертувати("02 3042 0002 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(275)] = ПарсерКоманд.Сконвертувати("12 0002 3241 0002");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(276)] = ПарсерКоманд.Сконвертувати("04 0000 0000 3153");
        ПассивноеЗапоминающееУстройство[Із8РічноїАдреси(277)] = ПарсерКоманд.Сконвертувати("22 0003 0003 3146");

        Память = new КоллекціяПамяти(this);
    }

    public КоллекціяПамяти Память { get; }

    public ulong АдресаПараметра
    {
        get => Память[Із8РічноїАдреси(2)];
        set => Память[Із8РічноїАдреси(2)] = value;
    }

    public ulong АдресаРезультата
    {
        get => Память[Із8РічноїАдреси(3)];
        set => Память[Із8РічноїАдреси(3)] = value;
    }

    public ulong АдресаТимчасовоїЗмінної1
    {
        get => Память[Із8РічноїАдреси(4)];
        set => Память[Із8РічноїАдреси(4)] = value;
    }

    public ulong АдресаТимчасовоїЗмінної2
    {
        get => Память[Із8РічноїАдреси(5)];
        set => Память[Із8РічноїАдреси(5)] = value;
    }

    public ulong АдресаТимчасовоїЗмінної3
    {
        get => Память[Із8РічноїАдреси(6)];
        set => Память[Із8РічноїАдреси(6)] = value;
    }

    private int ВзятиБазовуАдресу(int адреса)
    {
        if ((адреса & (1 << 11)) != 0)
        {
            return адреса % 2048;
        }

        return адреса;
    }

    private int ВзятиВідноснуАдреса(int адреса)
    {
        if ((адреса & (1 << 11)) != 0)
        {
            return (адреса + РегістрА) % 2048;
        }

        return адреса;
    }

    public ulong ПрочитатиПамять(int адреса)
    {
        if (адреса == 0) return 0;

        if (адреса < 1024) return ОперативноеЗапоминающееУстройство[адреса];

        if (адреса < 2047) return ПассивноеЗапоминающееУстройство[адреса - 1536];
        if (адреса == 2047)
        {
            // Последняя ячейка пятого блока сменно-спаянной памяти (имеющая адрес 3777) используется для подсоединения датчика случайных чисел
            Debug.Assert(false, "Датчик випадкових чисел не реалізован");
        }

        Debug.Assert(false, $"Невідома адреса {адреса}");
        return 0;
    }

    public ulong ПрочитатиПамятьІз8РічноїАдреси(int адреса) => ПрочитатиПамять(Із8РічноїАдреси(адреса));

    public void ЗаписатиПамять(int адреса, ulong значення)
    {
        //адреса = адреса - 2048;
        if (адреса == 0)
        {
            // Последняя ячейка пятого блока сменно-спаянной памяти (имеющая адрес 3777) используется для подсоединения датчика случайных чисел
            Debug.Assert(false, "Значення 0 не можна міняти");
        }

        if (адреса < 1024)
        {
            ОперативноеЗапоминающееУстройство[адреса] = значення;
            return;
        }
        if (адреса < 2047)
        {
            ПассивноеЗапоминающееУстройство[адреса - 1536] = значення;
            return;
        }

        if (адреса == 2047)
        {
            // Последняя ячейка пятого блока сменно-спаянной памяти (имеющая адрес 3777) используется для подсоединения датчика случайных чисел
            Debug.Assert(false, "Датчик випадкових чисел не реалізован");
        }

        Debug.Assert(false, $"Невідома адреса {адреса}");
    }

    public void ЗаписатиПамятьІз8РічноїАдреси(int адреса, ulong значення) => ЗаписатиПамять(Із8РічноїАдреси(адреса), значення);

    public void ВиконатиКоманду()
    {
        РегістрК = Память[РегістрС];
        ВиконатиКоманду(ПарсерКоманд.Розібрати(РегістрК));
    }

    public void ВстановитиЛічильник(int новийЛічильник)
    {
        РегістрС = (ushort)новийЛічильник;
        РегістрК = Память[новийЛічильник];
    }

    public void ЗавантажитиУПамять(string описПрограми)
    {
        int початковаАдреса = 0;
        foreach (var лінія in описПрограми.ReplaceLineEndings().Split(Environment.NewLine))
        {
            var частини = лінія.Split(" ", 2, StringSplitOptions.TrimEntries);
            if (частини[0].Length == 4)
            {
                початковаАдреса = Конвертер.Із8РічноїАдреси(int.Parse(частини[0]));
            }
            else
            {
                початковаАдреса++;
            }

            Память[початковаАдреса] = ПарсерКоманд.Сконвертувати(частини[0]);
        }
    }

    public void ВиконатиКоманду(СтруктураКоманди команда)
    {
        switch (команда.Код)
        {
            // ст. 55
            case КодОперації.Сложение:
                {
                    var значення1 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса1));
                    var значення2 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса2));
                    var значення = Додавання(значення1, значення2);
                    if (ФлагПереповнення)
                    {
                        if (АварійнаЗупинка && !ТумблерБлокировкиАварийногоОстанова)
                        {
                            Debug.Assert(false, $"Машина зупинена");
                        }
                        else
                        {
                            РегістрС += 2;
                        }
                    }
                    else
                    {
                        ЗаписатиПамять(ВзятиВідноснуАдреса(команда.Адреса3), значення);
                        РегістрС += 1;
                        РегістрК = ПрочитатиПамять(РегістрС);
                    }
                }
                break;
            // ст. 56
            case КодОперації.Вычитание:
                {
                    var значення1 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса1));
                    var значення2 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса2));
                    var значення = Віднімання(значення1, значення2);
                    if (ФлагПереповнення)
                    {
                        if (АварійнаЗупинка && !ТумблерБлокировкиАварийногоОстанова)
                        {
                            Debug.Assert(false, $"Машина зупинена");
                        }
                        else
                        {
                            РегістрС += 2;
                        }
                    }
                    else
                    {
                        ЗаписатиПамять(ВзятиВідноснуАдреса(команда.Адреса3), значення);
                        РегістрС += 1;
                        РегістрК = ПрочитатиПамять(РегістрС);
                    }
                }
                break;
            // ст. 56
            case КодОперації.ВычитаниеПоМодулю:
                {
                    var значення1 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса1));
                    var значення2 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса2));
                    var значення = ВідніманняМодулів(значення1, значення2);
                    if (ФлагПереповнення)
                    {
                        if (АварійнаЗупинка && !ТумблерБлокировкиАварийногоОстанова)
                        {
                            Debug.Assert(false, $"Машина зупинена");
                        }
                        else
                        {
                            РегістрС += 2;
                        }
                    }
                    else
                    {
                        ЗаписатиПамять(ВзятиВідноснуАдреса(команда.Адреса3), значення);
                        РегістрС += 1;
                        РегістрК = ПрочитатиПамять(РегістрС);
                    }
                }
                break;
            // ст. 57
            case КодОперації.СравнениеБезУчетаЗнаков:
                {
                    var значення1 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса1));
                    var значення2 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса2));
                    значення1 = Модуль(значення1);
                    значення2 = Модуль(значення2);
                    if (значення1 <= значення2)
                    {
                        РегістрС = (ushort)ВзятиВідноснуАдреса(команда.Адреса3);
                        РегістрК = ПрочитатиПамять(РегістрС);
                    }
                    else
                    {
                        РегістрС += 1;
                        РегістрК = ПрочитатиПамять(РегістрС);
                    }
                }
                break;
            // ст. 56
            case КодОперації.УмножениеБезОкругления:
            case КодОперації.УмножениеСОкруглением:
                {
                    var значення1 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса1));
                    var значення2 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса2));
                    var значення = Множення(значення1, значення2, команда.Код == КодОперації.УмножениеСОкруглением);
                    if (ФлагПереповнення)
                    {
                        if (АварійнаЗупинка && !ТумблерБлокировкиАварийногоОстанова)
                        {
                            Debug.Assert(false, $"Машина зупинена");
                        }
                        else
                        {
                            РегістрС += 2;
                        }
                    }
                    else
                    {
                        ЗаписатиПамять(ВзятиВідноснуАдреса(команда.Адреса3), значення);
                        РегістрС += 1;
                        РегістрК = ПрочитатиПамять(РегістрС);
                    }
                }
                break;
            // ст. 56
            case КодОперації.Деление:
                {
                    var значення1 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса1));
                    var значення2 = ПрочитатиПамять(ВзятиВідноснуАдреса(команда.Адреса2));
                    var значення = Ділення(значення1, значення2);
                    if (ФлагПереповнення)
                    {
                        if (АварійнаЗупинка && !ТумблерБлокировкиАварийногоОстанова)
                        {
                            Debug.Assert(false, $"Машина зупинена");
                        }
                        else
                        {
                            РегістрС += 2;
                        }
                    }
                    else
                    {
                        ЗаписатиПамять(ВзятиВідноснуАдреса(команда.Адреса3), значення);
                        РегістрС += 1;
                        РегістрК = ПрочитатиПамять(РегістрС);
                    }
                }
                break;
            // ст. 58
            case КодОперації.ПереходПоРегиструВозврата:
                {
                    РегістрС = РегістрР;
                    РегістрР = 0;
                    РегістрК = ПрочитатиПамять(РегістрС);
                }
                break;
            // ст. 59
            case КодОперації.НачалоГрупповойОперации:
                {
                    РегістрЦ = (ushort)ВзятиБазовуАдресу(команда.Адреса1);
                    РегістрА = (ushort)ВзятиБазовуАдресу(команда.Адреса2);
                    if (РегістрЦ == РегістрА)
                    {
                        РегістрС = (ushort)команда.Адреса3;
                    }
                    else
                    {
                        РегістрС += 1;
                    }
 
                    РегістрК = ПрочитатиПамять(РегістрС);
                }
                break;
            // ст. 60
            case КодОперації.ОкончаниеГрупповойОперации:
                {
                    РегістрА += (ushort)ВзятиБазовуАдресу(команда.Адреса1);
                    if (РегістрЦ == РегістрА)
                    {
                        РегістрС = (ushort)ВзятиБазовуАдресу(команда.Адреса3);
                    }
                    else
                    {
                        РегістрС = (ushort)ВзятиБазовуАдресу(команда.Адреса2);
                    }

                    РегістрК = ПрочитатиПамять(РегістрС);
                }
                break;
            default:
                throw new NotImplementedException($"Команда {команда.Код} не реалізована");
        }    
    }

    private ulong Додавання(ulong значення1, ulong значення2)
    {
        var число = РозширитиЧисло(значення1) + РозширитиЧисло(значення2);
        ФлагПереповнення = МінімальнеНегативнеЧисло > число || число > МаксимальнеПозітивнеЧисло;
        var значення = ЗвузитиЧисло(число);
        return значення;
    }

    private ulong Віднімання(ulong значення1, ulong значення2)
    {
        var число = РозширитиЧисло(значення1) - РозширитиЧисло(значення2);
        ФлагПереповнення = МінімальнеНегативнеЧисло > число || число > МаксимальнеПозітивнеЧисло;            
        var значення = ЗвузитиЧисло(число);
        return значення;
    }

    private ulong ВідніманняМодулів(ulong значення1, ulong значення2)
    {
        var число = РозширитиЧисло(Модуль(значення1)) - РозширитиЧисло(Модуль(значення2));
        ФлагПереповнення = МінімальнеНегативнеЧисло > число || число > МаксимальнеПозітивнеЧисло;
        var значення = ЗвузитиЧисло(число);
        return значення;
    }

    private ulong Ділення(ulong значення1, ulong значення2)
    {
        var знак1 = ЄЗнак(значення1);
        var знак2 = ЄЗнак(значення2);
        значення1 = Модуль(значення1);
        значення2 = Модуль(значення2);
        if (значення2 == 0)
        {
            Debug.Fail("Ділення на нуль");
        }

        var число = знак1 != знак2 ? 1UL << 40 : 0;
        if (значення1 == значення2)
        {
            число += ПарсерКоманд.Сконвертувати("17 7777 7777 7777");
            return число;
        }

        for (var i = 40; i > 0;i--)
        {
            if (значення1 >= значення2)
            {
                число += 1UL << i;
                значення1 -= значення2;
            }

            значення2 >>= 1;
        }

        return число;
    }

    private ulong Множення(ulong значення1, ulong значення2, bool скруглення)
    {
        var знак1 = ЄЗнак(значення1);
        var знак2 = ЄЗнак(значення2);
        значення1 = Модуль(значення1);
        значення2 = Модуль(значення2);
        var число = 0UL;

        var p1 = значення1;
        for (var i = 0; i < 40; i++)
        {
            if ((значення2 & (1UL << i)) != 0)
            {
                число += p1 >> (39 - i);
            }
        }

        return (знак1 != знак2 ? 1UL << 40 : 0) + (число >> 1) + (скруглення ? (число & 1) : 0UL);
    }

    // сторінка 7 та 17
    // кожне число SA1A2A3....A40 це поліном S * (A1*2^-1 + A2*2^-2 + A3*2^-3 + ... +  + A40*2^-40)                                                  
    private static long РозширитиЧисло(ulong значення)
    {
        var модуль = значення & (ulong.MaxValue >> 24);
        if (ЄЗнак(значення)) return -unchecked((long)модуль);

        return unchecked((long)модуль);
    }

    private static ulong ЗвузитиЧисло(long значення)
    {
        if (значення > 0) return unchecked((ulong)значення);

        return unchecked((ulong)-значення) | SignFlag;
    }

    public static ulong Модуль(ulong значення)
    {
        return значення & ~SignFlag;
    }

    public static bool ЄЗнак(ulong значення) => (значення & SignFlag) != 0;

    public static bool ЄПереповнення(ulong значення)
    {
        if ((значення & (1UL << 41)) != 0)
        {
            return true;
        }

        if ((значення & (1UL << 41)) != 0)
        {
            return true;
        }

        return false;
    }

    public class КоллекціяПамяти(МашинаКиїв машина)
    {
        public ulong this[int адреса]
        {
            get => машина.ПрочитатиПамять(адреса);
            set => машина.ЗаписатиПамять(адреса, value);
        }
    }
}
