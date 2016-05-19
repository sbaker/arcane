using LiteDB;
using Arcane;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Arcane.LiteDb
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class LiteDbQueryContext : QueryContext
    {
        public LiteDbQueryContext(LiteDatabase database)
        {
            throw new NotImplementedException();
            //Database = database;
        }

        protected LiteDatabase Database { get; }

        public override IQuery<T> Query<T>(string name = null)
        {
            throw new NotImplementedException();
            //return Database.GetCollection<T>(nameof(T)).FindAll().AsQueryable();
        }
        
        protected override void DisposeCore(bool disposing)
        {
            throw new NotImplementedException();

            //if (disposing && Database != null)
            //{
            //    Database.Dispose();
            //}
        }
    }
}
