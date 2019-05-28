using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impl
{
    public class Singleton
    {
        public static readonly Singleton Instance = new Singleton();

        private string Context = null;

        public Singleton()
        {
            Console.WriteLine("              ※ Singleton class has been instantiated...");
        }

        public string GetContext()
        {
            return Context;
        }

        public void SetContext(string context)
        {
            this.Context = context;
        }
    }
}
