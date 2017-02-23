using System.Linq;
using Alachisoft.NosDB.Client;

namespace Arcane.NosDB
{
    /// <summary>
    /// A factory for creating <see cref="NosDBQuery{T}"/> instances.
    /// </summary>
    public class NosDBQueryFactory : QueryFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NosDBQueryFactory"/> class.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="context"></param>
        public NosDBQueryFactory(Database database, IQueryContext context) : base(context)
        {
            Database = database;
        }

        private Database Database { get; }

        /// <inheritdoc />
        public override IQuery<T> CreateQuery<T>(string name = null)
        {
            return new NosDBQuery<T>(Database.GetDBCollection<T>(name).AsQueryable(), Context);
        }
    }
}