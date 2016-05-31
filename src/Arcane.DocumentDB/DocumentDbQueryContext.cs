using System.Linq.Expressions;

namespace Arcane.DocumentDB
{
    public class DocumentDbQueryContext : QueryContext<DatabaseQueryConfig>
    {
        public override IQuery<T> Query<T>(string name = null)
        {
            return new DocumentDbQuery<T>(Context.CreateDocumentQuery<T>(name), this, Context);
        }

        protected override void EvaluateExpression(Expression expression)
        {
            throw new System.NotImplementedException();
        }

        protected override void DisposeCore(bool disposing)
        {
            if (disposing)
            {
                Context?.Client?.Dispose();
            }
        }
    }
}
