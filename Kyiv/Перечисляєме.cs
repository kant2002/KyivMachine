using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace Система.Лінкью
{
    public static class Перечисляєме
    {
        public static TSource Агрегувати<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
            => Enumerable.Aggregate(source, func);
        public static TAccumulate Агрегувати<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
            => Enumerable.Aggregate(source, seed, func);
        public static TResult Агрегувати<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
            => Enumerable.Aggregate(source, seed, func, resultSelector);
        public static bool Усі<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.All(source, predicate);
        public static bool БудьХто<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Any(source);
        public static bool БудьХто<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Any(source, predicate);
        public static IEnumerable<TSource> Додати<TSource>(this IEnumerable<TSource> source, TSource element)
            => Enumerable.Append(source, element);
        public static IEnumerable<TSource> ЯкПеречисляєме<TSource>(this IEnumerable<TSource> source)
            => Enumerable.AsEnumerable(source);
        public static double Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
            => Enumerable.Average(source, selector);
        public static double Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
            => Enumerable.Average(source, selector);
        public static decimal? Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
            => Enumerable.Average(source, selector);
        public static float? Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
            => Enumerable.Average(source, selector);
        public static double? Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
            => Enumerable.Average(source, selector);
        public static double? Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
            => Enumerable.Average(source, selector);
        public static double Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
            => Enumerable.Average(source, selector);
        public static double? Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
            => Enumerable.Average(source, selector);
        public static decimal Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
            => Enumerable.Average(source, selector);
        public static double? Середне(this IEnumerable<int?> source)
            => Enumerable.Average(source);
        public static float? Середне(this IEnumerable<float?> source)
            => Enumerable.Average(source);
        public static double? Середне(this IEnumerable<long?> source)
            => Enumerable.Average(source);
        public static float Середне<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
            => Enumerable.Average(source, selector);
        public static double? Середне(this IEnumerable<double?> source)
            => Enumerable.Average(source);
        public static decimal? Середне(this IEnumerable<decimal?> source)
            => Enumerable.Average(source);
        public static double Середне(this IEnumerable<long> source)
            => Enumerable.Average(source);
        public static double Середне(this IEnumerable<int> source)
            => Enumerable.Average(source);
        public static double Середне(this IEnumerable<double> source)
            => Enumerable.Average(source);
        public static decimal Середне(this IEnumerable<decimal> source)
            => Enumerable.Average(source);
        public static float Середне(this IEnumerable<float> source)
            => Enumerable.Average(source);
        public static IEnumerable<TResult> Привести<TResult>(this IEnumerable source)
            => Enumerable.Cast<TResult>(source);
        public static IEnumerable<TSource[]> Кусок<TSource>(this IEnumerable<TSource> source, int size)
            => Enumerable.Chunk(source, size);
        public static IEnumerable<TSource> Скласти<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
            => Enumerable.Concat(first, second);
        public static bool Містить<TSource>(this IEnumerable<TSource> source, TSource value)
            => Enumerable.Contains(source, value);
        public static bool Містить<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource>? comparer)
            => Enumerable.Contains(source, value, comparer);
        public static int Кількість<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Count(source);
        public static int Кількість<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Count(source, predicate);
        public static IEnumerable<TSource?> ЗаЗамовчаннямЯкщоПусто<TSource>(this IEnumerable<TSource> source)
            => Enumerable.DefaultIfEmpty(source);
        public static IEnumerable<TSource> ЗаЗамовчаннямЯкщоПусто<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
            => Enumerable.DefaultIfEmpty(source, defaultValue);
        public static IEnumerable<TSource> Унікальні<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Distinct(source);
        public static IEnumerable<TSource> Унікальні<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer)
            => Enumerable.Distinct(source, comparer);
        public static IEnumerable<TSource> УнікальніПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => Enumerable.DistinctBy(source, keySelector);
        public static IEnumerable<TSource> УнікальніПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.DistinctBy(source, keySelector, comparer);
        public static TSource ЕлементВ<TSource>(this IEnumerable<TSource> source, Index index)
            => Enumerable.ElementAt(source, index);
        public static TSource ЕлементВ<TSource>(this IEnumerable<TSource> source, int index)
            => Enumerable.ElementAt(source, index);
        public static TSource? ЕлементВАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, Index index)
            => Enumerable.ElementAtOrDefault(source, index);
        public static TSource? ЕлементВАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, int index)
            => Enumerable.ElementAtOrDefault(source, index);
        public static IEnumerable<TResult> Пусте<TResult>()
            => Enumerable.Empty<TResult>();
        public static IEnumerable<TSource> ЗаВинятком<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
            => Enumerable.Except(first, second);
        public static IEnumerable<TSource> ЗаВинятком<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
            => Enumerable.Except(first, second, comparer);
        public static IEnumerable<TSource> ЗаВиняткомПо<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector)
            => Enumerable.ExceptBy(first, second, keySelector);
        public static IEnumerable<TSource> ЗаВиняткомПо<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.ExceptBy(first, second, keySelector, comparer);
        public static TSource Перший<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.First(source, predicate);
        public static TSource Перший<TSource>(this IEnumerable<TSource> source)
            => Enumerable.First(source);
        public static TSource ПершийАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
            => Enumerable.FirstOrDefault(source, predicate, defaultValue);
        public static TSource ПершийАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
            => Enumerable.FirstOrDefault(source, defaultValue);
        public static TSource? ПершийАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source)
            => Enumerable.FirstOrDefault(source);
        public static TSource? ПершийАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.FirstOrDefault(source, predicate);
        public static IEnumerable<TResult> СгрупуватиПо<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.GroupBy(source, keySelector, resultSelector, comparer);
        public static IEnumerable<TResult> СгрупуватиПо<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.GroupBy(source, keySelector, elementSelector, resultSelector, comparer);
        public static IEnumerable<TResult> СгрупуватиПо<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
            => Enumerable.GroupBy(source, keySelector, elementSelector, resultSelector);
        public static IEnumerable<TResult> СгрупуватиПо<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
            => Enumerable.GroupBy(source, keySelector, resultSelector);
        public static IEnumerable<IGrouping<TKey, TElement>> СгрупуватиПо<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            => Enumerable.GroupBy(source, keySelector, elementSelector);
        public static IEnumerable<IGrouping<TKey, TSource>> СгрупуватиПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.GroupBy(source, keySelector, comparer);
        public static IEnumerable<IGrouping<TKey, TSource>> СгрупуватиПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => Enumerable.GroupBy(source, keySelector);
        public static IEnumerable<IGrouping<TKey, TElement>> СгрупуватиПо<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.GroupBy(source, keySelector, elementSelector, comparer);
        public static IEnumerable<TResult> ПоєднатиСгруповано<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
            => Enumerable.GroupJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector);
        public static IEnumerable<TResult> ПоєднатиСгруповано<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.GroupJoin(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        public static IEnumerable<TSource> Перетнути<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
            => Enumerable.Intersect(first, second);
        public static IEnumerable<TSource> Перетнути<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
            => Enumerable.Intersect(first, second, comparer);
        public static IEnumerable<TSource> ПеретнутиПо<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector)
            => Enumerable.IntersectBy(first, second, keySelector);
        public static IEnumerable<TSource> ПеретнутиПо<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, EqualityComparer<TKey>? comparer)
            => Enumerable.IntersectBy(first, second, keySelector, comparer);
        public static IEnumerable<TResult> Поєднати<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
            => Enumerable.Join(outer, inner, outerKeySelector, innerKeySelector, resultSelector);
        public static IEnumerable<TResult> Поєднати<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.Join(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        public static TSource Останній<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Last(source);
        public static TSource Остання<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Last(source);
        public static TSource Останній<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Last(source, predicate);
        public static TSource Остання<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Last(source, predicate);
        public static TSource ОстаннійАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
            => Enumerable.LastOrDefault(source, predicate, defaultValue);
        public static TSource? ОстаннійАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source)
            => Enumerable.LastOrDefault(source);
        public static TSource ОстаннійАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
            => Enumerable.LastOrDefault(source, defaultValue);
        public static TSource? ОстаннійАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.LastOrDefault(source, predicate);
        public static TSource ОстанняАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
            => Enumerable.LastOrDefault(source, predicate, defaultValue);
        public static TSource? ОстанняАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source)
            => Enumerable.LastOrDefault(source);
        public static TSource ОстанняАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
            => Enumerable.LastOrDefault(source, defaultValue);
        public static TSource? ОстанняАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.LastOrDefault(source, predicate);
        public static long ДовгаКількість<TSource>(this IEnumerable<TSource> source)
            => Enumerable.LongCount(source);
        public static long ДовгаКількість<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.LongCount(source, predicate);
        public static double Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
            => Enumerable.Max(source, selector);
        public static int Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
            => Enumerable.Max(source, selector);
        public static decimal? Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
            => Enumerable.Max(source, selector);
        public static long Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
            => Enumerable.Max(source, selector);
        public static double? Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
            => Enumerable.Max(source, selector);
        public static float? Макс(this IEnumerable<float?> source)
            => Enumerable.Max(source);
        public static long? Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
            => Enumerable.Max(source, selector);
        public static float? Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
            => Enumerable.Max(source, selector);
        public static float Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
            => Enumerable.Max(source, selector);
        public static TResult? Макс<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            => Enumerable.Max(source, selector);
        public static decimal Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
            => Enumerable.Max(source, selector);
        public static int? Макс<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
            => Enumerable.Max(source, selector);
        public static TSource? Макс<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer)
            => Enumerable.Max(source, comparer);
        public static double? Макс(this IEnumerable<double?> source)
            => Enumerable.Max(source);
        public static float Макс(this IEnumerable<float> source)
            => Enumerable.Max(source);
        public static long? Макс(this IEnumerable<long?> source)
            => Enumerable.Max(source);
        public static int? Макс(this IEnumerable<int?> source)
            => Enumerable.Max(source);
        public static decimal? Макс(this IEnumerable<decimal?> source)
            => Enumerable.Max(source);
        public static long Макс(this IEnumerable<long> source)
            => Enumerable.Max(source);
        public static int Макс(this IEnumerable<int> source)
            => Enumerable.Max(source);
        public static double Макс(this IEnumerable<double> source)
            => Enumerable.Max(source);
        public static decimal Макс(this IEnumerable<decimal> source)
            => Enumerable.Max(source);
        public static TSource? Макс<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Max(source);
        public static TSource? МаксПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
            => Enumerable.MaxBy(source, keySelector, comparer);
        public static TSource? МаксПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => Enumerable.MaxBy(source, keySelector);
        public static decimal? Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
            => Enumerable.Min(source, selector);
        public static double Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
            => Enumerable.Min(source, selector);
        public static int Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
            => Enumerable.Min(source, selector);
        public static long Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
            => Enumerable.Min(source, selector);
        public static double? Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
            => Enumerable.Min(source, selector);
        public static decimal Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
            => Enumerable.Min(source, selector);
        public static long? Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
            => Enumerable.Min(source, selector);
        public static float? Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
            => Enumerable.Min(source, selector);
        public static float Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
            => Enumerable.Min(source, selector);
        public static TResult? Мин<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            => Enumerable.Min(source, selector);
        public static int? Мин<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
            => Enumerable.Min(source, selector);
        public static TSource? Мин<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer)
            => Enumerable.Min(source, comparer);
        public static int Мин(this IEnumerable<int> source)
            => Enumerable.Min(source);
        public static long Мин(this IEnumerable<long> source)
            => Enumerable.Min(source);
        public static decimal Мин(this IEnumerable<decimal> source)
            => Enumerable.Min(source);
        public static float Мин(this IEnumerable<float> source)
            => Enumerable.Min(source);
        public static float? Мин(this IEnumerable<float?> source)
            => Enumerable.Min(source);
        public static long? Мин(this IEnumerable<long?> source)
            => Enumerable.Min(source);
        public static int? Мин(this IEnumerable<int?> source)
            => Enumerable.Min(source);
        public static double? Мин(this IEnumerable<double?> source)
            => Enumerable.Min(source);
        public static decimal? Мин(this IEnumerable<decimal?> source)
            => Enumerable.Min(source);
        public static double Мин(this IEnumerable<double> source)
            => Enumerable.Min(source);
        public static TSource? Мин<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Min(source);
        public static TSource? МинПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
            => Enumerable.MinBy(source, keySelector, comparer);
        public static TSource? МинПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => Enumerable.MinBy(source, keySelector);
        public static IEnumerable<TResult> ВказанногоТипу<TResult>(this IEnumerable source)
            => Enumerable.OfType<TResult>(source);
        public static IOrderedEnumerable<T> Впорядкувати<T>(this IEnumerable<T> source, IComparer<T>? comparer)
            => Enumerable.Order(source, comparer);
        public static IOrderedEnumerable<T> Впорядкувати<T>(this IEnumerable<T> source)
            => Enumerable.Order(source);
        public static IOrderedEnumerable<TSource> ВпорядкуватиПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => Enumerable.OrderBy(source, keySelector);
        public static IOrderedEnumerable<TSource> ВпорядкуватиПо<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
            => Enumerable.OrderBy(source, keySelector, comparer);
        public static IOrderedEnumerable<TSource> ВпорядкуватиПоСпаданню<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => Enumerable.OrderByDescending(source, keySelector);
        public static IOrderedEnumerable<TSource> ВпорядкуватиПоСпаданню<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
            => Enumerable.OrderByDescending(source, keySelector, comparer);
        public static IOrderedEnumerable<T> ВпорядкуватиСпадаючи<T>(this IEnumerable<T> source, IComparer<T>? comparer)
            => Enumerable.OrderDescending(source, comparer);
        public static IOrderedEnumerable<T> ВпорядкуватиСпадаючи<T>(this IEnumerable<T> source)
            => Enumerable.OrderDescending(source);
        public static IEnumerable<TSource> ВПочаток<TSource>(this IEnumerable<TSource> source, TSource element)
            => Enumerable.Prepend(source, element);
        public static IEnumerable<int> Діапазон(int start, int count)
            => Enumerable.Range(start, count);
        public static IEnumerable<TResult> Повторити<TResult>(TResult element, int count)
            => Enumerable.Repeat(element, count);
        public static IEnumerable<TSource> Розвернути<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Reverse(source);
        public static IEnumerable<TResult> Вибрати<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
            => Enumerable.Select(source, selector);
        public static IEnumerable<TResult> Вибрати<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            => Enumerable.Select(source, selector);
        public static IEnumerable<TResult> ВибратиБагато<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
            => Enumerable.SelectMany(source, collectionSelector, resultSelector);
        public static IEnumerable<TResult> ВибратиБагато<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
            => Enumerable.SelectMany(source, selector);
        public static IEnumerable<TResult> ВибратиБагато<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
            => Enumerable.SelectMany(source, selector);
        public static IEnumerable<TResult> ВибратиБагато<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
            => Enumerable.SelectMany(source, collectionSelector, resultSelector);
        public static bool ПослідовнеДорівнює<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
            => Enumerable.SequenceEqual(first, second);
        public static bool ПослідовнеДорівнює<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
            => Enumerable.SequenceEqual(first, second, comparer);
        public static TSource Один<TSource>(this IEnumerable<TSource> source)
            => Enumerable.Single(source);
        public static TSource Один<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Single(source, predicate);
        public static TSource? ОдинАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source)
            => Enumerable.SingleOrDefault(source);
        public static TSource ОдинАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
            => Enumerable.SingleOrDefault(source, defaultValue);
        public static TSource? ОдинАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.SingleOrDefault(source, predicate);
        public static TSource ОдинАбоЗаЗамовчанням<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
            => Enumerable.SingleOrDefault(source, predicate, defaultValue);
        public static IEnumerable<TSource> Пропустити<TSource>(this IEnumerable<TSource> source, int count)
            => Enumerable.Skip(source, count);
        public static IEnumerable<TSource> ПропуститиЗКінця<TSource>(this IEnumerable<TSource> source, int count)
            => Enumerable.SkipLast(source, count);
        public static IEnumerable<TSource> ПропуститиПоки<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.SkipWhile(source, predicate);
        public static IEnumerable<TSource> ПропуститиПоки<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
            => Enumerable.SkipWhile(source, predicate);
        public static float Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
            => Enumerable.Sum(source, selector);
        public static int Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
            => Enumerable.Sum(source, selector);
        public static long Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
            => Enumerable.Sum(source, selector);
        public static decimal? Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
            => Enumerable.Sum(source, selector);
        public static double Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
            => Enumerable.Sum(source, selector);
        public static int? Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
            => Enumerable.Sum(source, selector);
        public static long? Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
            => Enumerable.Sum(source, selector);
        public static float? Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
            => Enumerable.Sum(source, selector);
        public static double? Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
            => Enumerable.Sum(source, selector);
        public static decimal Сума<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
            => Enumerable.Sum(source, selector);
        public static double? Сума(this IEnumerable<double?> source)
            => Enumerable.Sum(source);
        public static float? Сума(this IEnumerable<float?> source)
            => Enumerable.Sum(source);
        public static long? Сума(this IEnumerable<long?> source)
            => Enumerable.Sum(source);
        public static int? Сума(this IEnumerable<int?> source)
            => Enumerable.Sum(source);
        public static decimal? Сума(this IEnumerable<decimal?> source)
            => Enumerable.Sum(source);
        public static long Сума(this IEnumerable<long> source)
            => Enumerable.Sum(source);
        public static int Сума(this IEnumerable<int> source)
            => Enumerable.Sum(source);
        public static double Сума(this IEnumerable<double> source)
            => Enumerable.Sum(source);
        public static decimal Сума(this IEnumerable<decimal> source)
            => Enumerable.Sum(source);
        public static float Сума(this IEnumerable<float> source)
            => Enumerable.Sum(source);
        public static IEnumerable<TSource> Взяти<TSource>(this IEnumerable<TSource> source, Range range)
            => Enumerable.Take(source, range);
        public static IEnumerable<TSource> Взяти<TSource>(this IEnumerable<TSource> source, int count)
            => Enumerable.Take(source, count);
        public static IEnumerable<TSource> ВзятиЗКінця<TSource>(this IEnumerable<TSource> source, int count)
            => Enumerable.TakeLast(source, count);
        public static IEnumerable<TSource> ВзятиПоки<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
            => Enumerable.TakeWhile(source, predicate);
        public static IEnumerable<TSource> ВзятиПоки<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.TakeWhile(source, predicate);
        public static IOrderedEnumerable<TSource> ПотімПо<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => Enumerable.ThenBy(source, keySelector);
        public static IOrderedEnumerable<TSource> ПотімПо<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
            => Enumerable.ThenBy(source, keySelector, comparer);
        public static IOrderedEnumerable<TSource> ПотімПоСпаданню<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => Enumerable.ThenByDescending(source, keySelector);
        public static IOrderedEnumerable<TSource> ПотімПоСпаданню<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
            => Enumerable.ThenByDescending(source, keySelector, comparer);
        public static TSource[] ДоМасиву<TSource>(this IEnumerable<TSource> source)
            => Enumerable.ToArray(source);
        public static Dictionary<TKey, TElement> ДоСловника<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer) where TKey : notnull
            => Enumerable.ToDictionary(source, keySelector, elementSelector, comparer);
        public static Dictionary<TKey, TElement> ДоСловника<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TKey : notnull
            => Enumerable.ToDictionary(source, keySelector, elementSelector);
        public static Dictionary<TKey, TSource> ДоСловника<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TKey : notnull
            => Enumerable.ToDictionary(source, keySelector, comparer);
        public static Dictionary<TKey, TSource> ДоСловника<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) where TKey : notnull
            => Enumerable.ToDictionary(source, keySelector);
        public static Dictionary<TKey, TValue> ДоСловника<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source) where TKey : notnull
            => Enumerable.ToDictionary(source);
        public static Dictionary<TKey, TValue> ДоСловника<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer) where TKey : notnull
            => Enumerable.ToDictionary(source, comparer);
        public static Dictionary<TKey, TValue> ДоСловника<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source) where TKey : notnull
            => Enumerable.ToDictionary(source);
        public static Dictionary<TKey, TValue> ДоСловника<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> source, IEqualityComparer<TKey>? comparer) where TKey : notnull
            => Enumerable.ToDictionary(source, comparer);
        public static HashSet<TSource> ДоХешованоїМножини<TSource>(this IEnumerable<TSource> source)
            => Enumerable.ToHashSet(source);
        public static HashSet<TSource> ДоХешованоїМножини<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer)
            => Enumerable.ToHashSet(source, comparer);
        public static List<TSource> ДоСписку<TSource>(this IEnumerable<TSource> source)
            => Enumerable.ToList(source);
        public static ILookup<TKey, TElement> ДоПошуку<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            => Enumerable.ToLookup(source, keySelector, elementSelector);
        public static ILookup<TKey, TElement> ДоПошуку<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.ToLookup(source, keySelector, elementSelector, comparer);
        public static ILookup<TKey, TSource> ДоПошуку<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            => Enumerable.ToLookup(source, keySelector);
        public static ILookup<TKey, TSource> ДоПошуку<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.ToLookup(source, keySelector, comparer);
        public static bool СпробуватиВзятиНеПеречисляємуКількість<TSource>(this IEnumerable<TSource> source, out int count)
            => Enumerable.TryGetNonEnumeratedCount(source, out count);
        public static IEnumerable<TSource> Обєднати<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
            => Enumerable.Union(first, second);
        public static IEnumerable<TSource> Обєднати<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
            => Enumerable.Union(first, second, comparer);
        public static IEnumerable<TSource> ОбєднатиПо<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
            => Enumerable.UnionBy(first, second, keySelector);
        public static IEnumerable<TSource> ОбєднатиПо<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
            => Enumerable.UnionBy(first, second, keySelector, comparer);
        public static IEnumerable<TSource> Коли<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
            => Enumerable.Where(source, predicate);
        public static IEnumerable<TSource> Коли<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
            => Enumerable.Where(source, predicate);
        public static IEnumerable<(TFirst First, TSecond Second, TThird Third)> Зазіпувати<TFirst, TSecond, TThird>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third)
            => Enumerable.Zip(first, second, third);
        public static IEnumerable<(TFirst First, TSecond Second)> Зазіпувати<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
            => Enumerable.Zip(first, second);
        public static IEnumerable<TResult> Зазіпувати<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
            => Enumerable.Zip(first, second, resultSelector);
    }
}
