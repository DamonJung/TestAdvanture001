using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impl
{
    public class SomeInterface : ISomeInterface
    {
        public void CheckContext()
        {
            var s = Singleton.Instance.GetContext();
            if(s == null)
            {
                Console.WriteLine("     Context is null...");
            }
            else
            {
                Console.WriteLine($"     Context is alive... the value is : {s}");
            }
        }

        public void SetContext(string word)
        {
            Singleton.Instance.SetContext(word);
        }
    }
}
