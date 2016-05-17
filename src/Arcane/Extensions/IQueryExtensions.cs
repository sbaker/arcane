namespace Arcane.Extensions
{
    public static class IQueryExtensions
    {
        public static IQuery<T> ToDbSet<T>(this IQuery<T> query)
        {
            return query;
        }
    }
}
