using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeSealedMethod
{
    public class Variable
    {
        public short id;
        public String name;
        public String description;
        public byte format;
        public int address;
        public int size; // 17 октября 2018 - появление массивов переменных в описании устройств

        public int lenData()
        {
            switch (format)
            {
                case 1: return 1;
                case 2:
                case 3: return 2;
                case 4:
                case 5:
                case 8: return 4;
                case 11:
                case 14:
                    return 8;
            }
            return 0;
        }
        public int lenDataWithError()
        {
            return lenData() + 1;
        }
        public int lenFullSize()
        {
            return lenDataWithError() * size;
        }

    }
}
