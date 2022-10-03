using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeSealedMethod
{

    // Создаем класс  с методом с идентичным именем
    // как у класса DumpBulkPacket
    public class DumpInitFake
    {
        public string GetValue(int id)
        {
            return "FakeValue";
        }

        public void GetValue_()
        {
            Console.WriteLine("DumpInitFake - GetValue_ !!!!!!!!!!!!!!!!!! ");
        }
    }
}
