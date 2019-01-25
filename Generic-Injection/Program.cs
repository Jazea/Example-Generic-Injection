using Microsoft.Extensions.DependencyInjection;
using System;

namespace Generic_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddTransient(typeof(IFactory<>),typeof(Factory<>));
            var serviceProvider = services.BuildServiceProvider();

            //获得A实例
            var aFactory = serviceProvider.GetService<IFactory<A>>();
            var a = aFactory.Instance;
            Console.WriteLine(a.Name);
            //获得B实例
            var bFactory = serviceProvider.GetService<IFactory<B>>();
            var b= aFactory.Instance;
            Console.WriteLine(b.Name);
            //获得C实例
            var cFactory = serviceProvider.GetService<IFactory<C>>();
            var c = aFactory.Instance;
            Console.WriteLine(c.Name);

            Console.ReadLine();
        }
    }


    public interface IBase {
        string Name { get; }
    }

    public class A : IBase {
        public string Name => "This A instance.";
    }
    public class B : IBase {
        public string Name => "This B instance.";
    }
    public class C : IBase {
        public string Name => "This C instance.";
    }




    public interface IFactory<T>
        where T : IBase
    {
        T Instance { get; }
    }
    public class Factory<T>: IFactory<T>
        where T : IBase
    {
        public T Instance => Activator.CreateInstance<T>();
    }
}


