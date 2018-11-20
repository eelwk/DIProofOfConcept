using Microsoft.Extensions.DependencyInjection;
using System;
using ClassLibrary;

namespace DiProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var services = new ServiceCollection();
            services.AddClassLibraryDependencies();

            var provider = services.BuildServiceProvider();

            var testClass = provider.GetService<IPrimaryInterface>();
            Console.WriteLine(testClass.ThisIsAMethod("test", "class"));

            Console.ReadLine();
        }
    }
}
