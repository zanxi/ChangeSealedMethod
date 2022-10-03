using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using HarmonyLib;
using Newtonsoft.Json;

// Задача: Изменить поведение метода
// public string GetValue(int id) <<<получает пакет данных с сервера>>>
// sealed класса  DumpInit
// в ситуации когда его нельзя переопределить (если это внешняя библиотека!!!)
// Например если пришедший трафик не прошел проверку
// Для данной операции используется библиотека Harmony


namespace ChangeSealedMethod
{
    internal class Program
    {
        static void Main(string[] args)     
        {

            //var harmony = new Harmony("FakeMethod - GetVlaue");

            //var original = typeof(JsonConverter).GetMethod("SerializeObject", new[] { typeof(object) } );
            //var prefix = typeof(TimeSpanCounter).GetMethod(nameof(TimeSpanCounter.Before));
            //var postfix = typeof(TimeSpanCounter).GetMethod(nameof(TimeSpanCounter.After));
            //harmony.Patch(original, new HarmonyMethod(prefix), new HarmonyMethod(postfix));

            
            DumpInit d0;
            d0 = new DumpInit("dump0", "127.0.0.1");
            // оригинад метода класса
            d0.GetValue_();
            Thread.Sleep(300);

            // здесь происходят основные чудеса подмены метода основного класса
            // на метод фейкового класса
            var source = typeof(DumpInit).GetMethod(nameof(DumpInit.GetValue_));
            var dest = typeof(DumpInitFake).GetMethod(nameof(DumpInitFake.GetValue_));
            HarmonyLib.Memory.DetourMethod(source, dest);




            DumpInit d1,d2,d3;
            
            d1 = new DumpInit("dump1", "127.0.0.1");            
            d1 = new DumpInit("dump1", "127.0.0.1");
            d2 = new DumpInit("dump2", "127.0.0.1");
            d3 = new DumpInit("dump3", "127.0.0.1");
                        

            for (int k=0; k<3;k++)
            {                
                d1.GetValue_();
                d2.GetValue_();
                Thread.Sleep(500);
            }


            d0.Close();
            d1.Close();
            d2.Close();
            d3.Close();

            Console.WriteLine("Press key");
            Console.ReadKey();

        }
    }
}
