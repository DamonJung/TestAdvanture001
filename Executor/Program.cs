using ContainerRegister;
using Impl;
using Interface;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Regist a container.
            Register register = new Register();

            Console.WriteLine("Getting an instance from the IoC container.");
            var biz = register.container.GetInstance<ISomeInterface>();

            Console.WriteLine("See if the context in the singleton class is null");
            biz.CheckContext();
            var s = Singleton.Instance.GetContext();
            if (s == null)
            {
                Console.WriteLine("     Context is null from Singleton.Instance.GetContext");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Setting a context in the singleton class");
            biz.SetContext("Hello");
            Singleton.Instance.SetContext("Local Hello");

            Console.WriteLine("Recheck the context");
            biz.CheckContext();
            s = Singleton.Instance.GetContext();
            if (s == null)
            {
                Console.WriteLine("     Context is null from Singleton.Instance.GetContext");
            }
            else
            {
                Console.WriteLine($"     It's alive : {s}");
            }
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Reloading the assembly...");
            register.Reload();

            Console.WriteLine("See if the context in the singleton class is null again. It should survive.");
            biz.CheckContext();
            s = Singleton.Instance.GetContext();
            if (s == null)
            {
                Console.WriteLine("     Context is null from Singleton.Instance.GetContext");
            }
            else
            {
                Console.WriteLine($"     It's alive : {s}");
            }
            Console.WriteLine();
            Console.WriteLine();

            // THIS IS THE PROBLEM...
            // Even after I reloaded the assembly, the Singleton is still supposed to be holding the context... I guess.
            Console.WriteLine("What if I get the instance via IoC container?");
            var biz2 = register.container.GetInstance<ISomeInterface>();
            biz2.CheckContext();
            s = Singleton.Instance.GetContext();
            if (s == null)
            {
                Console.WriteLine("     Context is null from Singleton.Instance.GetContext");
            }
            else
            {
                Console.WriteLine($"     It's alive : {s}");
            }

            Console.WriteLine("Set context on biz2 and see if biz3 holds the value... it should be fine..");
            biz2.SetContext("biz2 Hello");
            var biz3 = register.container.GetInstance<ISomeInterface>();
            biz3.CheckContext();

            Console.ReadLine();
        }
    }
}
