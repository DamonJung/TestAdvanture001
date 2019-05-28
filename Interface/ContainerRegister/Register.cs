using SimpleInjector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContainerRegister
{
    public class Register
    {
        public string path = @"E:\ResearchJob\DLLPath\Impl.dll";
        public Container container = new Container();

        public Register()
        {
            Reload();
        }

        public void Reload()
        {
            container = new Container();

            // 플러그인 폴더에서 dll 가져와서 로드함            
            byte[] arr = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] d = new byte[fs.Length];
                fs.Read(d, 0, d.Length);
                arr = d;
            }
            var ass = Assembly.Load(arr);

            // 타입 정보 얻어와서 컨테이너에서 등록함.
            var types = ass.GetExportedTypes();
            Console.WriteLine($"Service Type : {types[1].GetInterfaces().First().FullName}, Imple Type : {types[1].FullName}");
            container.Register(types[1].GetInterfaces().First(), types[1]);
        }
    }
}
