using ArcaneTests.EntityFramework.Data;
using ArcaneTests.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ArcaneTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tests = new ArcaneTests.EntityFramework.EntityFrameworkQueryContextTests();
            tests.GetTheFirst24Authors();
        }
    }
}