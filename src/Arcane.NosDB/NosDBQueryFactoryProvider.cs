using Alachisoft.NosDB.Client;

namespace Arcane.NosDB
{
    /// <summary>
    /// A provider for <see cref="NosDBQueryFactory"/> objects.
    /// </summary>
    public class NosDBQueryFactoryProvider : QueryFactoryProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NosDBQueryFactoryProvider"/> class.
        /// </summary>
        /// <param name="session"></param>
        public NosDBQueryFactoryProvider(Database session)
        {
            Session = session;
        }

        private Database Session { get; }

        /// <inheritdoc />
        public override IQueryFactory GetQueryFactory(IQueryContext context)
        {
            return new NosDBQueryFactory(Session, context);
        }
    }
}