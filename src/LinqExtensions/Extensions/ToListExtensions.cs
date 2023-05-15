namespace LinqExtensions.Extensions;

public static class ToListExtensions
{
    public static IEnumerable<T> ToList<T>(this IEnumerable<T> enumerable, Func<T, bool> where)
    {
        var tConvert = where is null ? enumerable : enumerable.Where(where);

        return tConvert.ToList();
    }

    public static IEnumerable<T> ToListIf<T>(this IEnumerable<T> enumerable, bool condition)
    {
        if (!condition)
        {
            return enumerable;
        }

        return enumerable.ToList();
    }
}
