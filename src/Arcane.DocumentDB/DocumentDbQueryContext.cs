//using System.Linq.Expressions;

//namespace Arcane.DocumentDB
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class DocumentDbQueryContext : QueryContext<DatabaseQueryConfig>
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="config"></param>
//        public DocumentDbQueryContext(DatabaseQueryConfig config) : base(null, config)
//        {
//        }

//        /// <summary>
//        /// When implemented in a derived class, creates a query for the given <typeparamref name="T"/> model representing a table or collection.
//        /// </summary>
//        /// <typeparam name="T">The type representing the table or collection.</typeparam>
//        /// <param name="name">Optional, parameter is only used in some implementations of the <see cref="IQueryContext"/></param>
//        /// <returns></returns>
//        public override IQuery<T> Query<T>(string name = null)
//        {
//            return new DocumentDbQuery<T>(Context.CreateDocumentQuery<T>(name), this, Context);
//        }

//        /// <summary>
//        /// When implemented in a derived class will evaluate the <paramref name="expression"/> if <see cref="QueryContext.SuppressCompatibilityErrors"/> is false.
//        /// </summary>
//        /// <param name="expression"></param>
//        protected override void EvaluateExpression(Expression expression)
//        {
//            throw new System.NotImplementedException();
//        }

//        /// <summary>
//        /// Disposes of the current instance's <see cref="QueryContext{TContext}.Context"/> if it implements IDisposable.
//        /// </summary>
//        /// <param name="disposing">True if the object is wrapped in a using, false if the GC is collecting the current instance.</param>
//        protected override void DisposeCore(bool disposing)
//        {
//            if (disposing)
//            {
//                Context?.Client?.Dispose();
//            }
//        }
//    }
//}
