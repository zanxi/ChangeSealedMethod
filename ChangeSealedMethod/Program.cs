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



            DumpInit d1,d2,d3;
            DumpInitFake d1f;

            d1 = new DumpInit("dump1", "127.0.0.1");
            d1f = new DumpInitFake();
            d1 = new DumpInit("dump1", "127.0.0.1");
            d2 = new DumpInit("dump2", "127.0.0.1");
            d3 = new DumpInit("dump3", "127.0.0.1");

            //var source = typeof(DumpInit).GetMethod(nameof(DumpInit.GetValue_));
            var source = d1.GetType().GetMethod(nameof(DumpInit.GetValue_),
                new Type[] {  });

            //var methodInfo = typeof(DumpInit).GetType().GetMethod("GetValue_", BindingFlags.Instance | BindingFlags.NonPublic);

            //System.Type t = System.Type.GetType("DumpInit");
            //System.Reflection.MethodInfo mi = t.GetMethod("GetValue_",
            //System.Reflection.BindingFlags.Static | BindingFlags.Public);

            //var dest = typeof(DumpInitFake).GetMethod(nameof(DumpInitFake.GetValue_));
            var dest = d1f.GetType().GetMethod(nameof(DumpInitFake.GetValue_));

            HarmonyLib.Memory.DetourMethod(source, dest);


            for (int k=0; k<10;k++)
            {
                d1.GetValue_();
                d2.GetValue_();
                d3.GetValue_();
                Thread.Sleep(1000);
            }


            d1.Close();
            d2.Close();

            d3.Close();

        }
    }
}
