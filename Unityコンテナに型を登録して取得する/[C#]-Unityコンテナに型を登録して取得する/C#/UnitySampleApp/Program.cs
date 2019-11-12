using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitySampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new UnityContainer())
            {
                // default
                container.RegisterType<Component1>();
                var componentInstance = container.Resolve<Component1>();
                var componentInstance2 = container.Resolve<Component1>();
                Console.WriteLine(object.ReferenceEquals(componentInstance, componentInstance2)); // False
            }

            using (var container = new UnityContainer())
            {
                // sigleton
                container.RegisterType<Component1>(new ContainerControlledLifetimeManager());
                var componentInstance = container.Resolve<Component1>();
                var componentInstance2 = container.Resolve<Component1>();
                Console.WriteLine(object.ReferenceEquals(componentInstance, componentInstance2)); // True
            }


        }
    }

    public class Component1
    {
    }
}
