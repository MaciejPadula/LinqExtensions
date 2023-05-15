namespace LinqExtensions.Extensions;

public static class WhereExtensions
{
    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> enumerable, Func<T, bool> where,  bool condition)
    {
        if (!condition)
        {
            return enumerable;
        }

        return enumerable.Where(where);
    }
}
