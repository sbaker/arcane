
namespace Arcane.DocumentDB
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class DocumentDbQueryContext : QueryContext<DatabaseQueryConfig>
    {
        public override IQuery<T> Query<T>(string name = null)
        {
            return new Query<T>(Context.CreateDocumentQuery<T>());
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
