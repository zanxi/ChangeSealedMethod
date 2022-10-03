using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeSealedMethod
{
    public class Subsystem
    {
        public short id;
        public String name;
        public String description;
        public String main;
        public String second;
        public String path;
        public String resultpath;
        public String keyname;
        public int delaycycle;
        public String shema;
        public String file;
        public String key; // on/off 19 марта 2019 
        public int step;
        public int sizeBuffer;
        public int max_id;
        public String status;
        public String varxml;
        public String namesavefile;
        //public List<Device> devices;
        //public List<ModbusDevice> modbuses;
        //public List<Save> saves;
        public Dictionary<String, Variable> variables;
        public Dictionary<int, String> ids;
        public String rezult;



        public Subsystem()
        {
            //devices = new List<Device>();
            //modbuses = new List<ModbusDevice>();
            //saves = new List<Save>();
            variables = new Dictionary<String, Variable>();
            ids = new Dictionary<int, string>();
            max_id = 0;
        }

        public string VerifyNames()
        {
            //String result = "";
            //foreach (Save sv in saves)
            //{
            //    if (!variables.ContainsKey(sv.name))
            //    {
            //        result += "Переменная для сохранения " + sv.name + " отсутствует\n";
            //    }
            //}
            //foreach (ModbusDevice mb in modbuses)
            //{
            //    result += mb.VerifyNames(variables);
            //}

            //if (devices == null)
            //{
            //    return result += "\nError XML - СМ. LOG File";
            //}

            //foreach (Device dv in devices)
            //{
            //    result += dv.VerifyNames(variables);
            //}
            //return result;

            return "";
        }

        //public string MakeCode(Project pr, string path)
        //{
        //    String result = "";
        //    //using (StreamWriter sw = File.CreateText(this.rezult+"/"+name+".h"))
        //    using (StreamWriter sw = File.CreateText(Operate.d.SelectedPath + "/" + this.rezult + "/" + "master.h")) // правка 20 февраля 2019
        //    {
        //        sw.WriteLine("#ifndef " + name.ToUpper() + "_H");
        //        sw.WriteLine("#define " + name.ToUpper() + "_H");
        //        sw.WriteLine("// Подсистема " + name + ":" + description);
        //        sw.WriteLine("static char SimulOn=" + (pr.simul ? "1" : "0") + ";");
        //        // Правка Иван 9:56 11 мая 2018
        //        //if (pr.simul)

        //        sw.WriteLine("static short CodeSub=" + id + ";");
        //        sw.WriteLine("static char SimulIP[]=\"" + pr.ip + "\\0\";");
        //        sw.WriteLine("static int SimulPort=" + pr.port + ";");

        //        sw.WriteLine("static int StepCycle=" + step + ";\t // Время цикла в ms");

        //        // 18 октября
        //        //sw.WriteLine("static float takt;");
        //        sw.WriteLine("float takt;");

        //        sw.WriteLine("#define SIZE_BUFFER " + sizeBuffer.ToString() + "");

        //        sw.WriteLine("static char BUFFER[" + sizeBuffer.ToString() + "];");

        //        // здесь добавляем код -------------------------------
        //        string ip_pti = "192.168.10.60";
        //        //if (this.main != ip_pti)
        //        if (this.main != this.second)
        //        {
        //            //if (this.main != this.second) sw.WriteLine("#include <fp8/UDPTrasport.h>");
        //            //else
        //            //sw.WriteLine("#include \"" + "fp8/UDPTrasport.h+ "+"\"\n");

        //            sw.WriteLine("#include <fp8/UDPTrasport.h>");
        //            sw.WriteLine("SetupUDP setUDP = {\"" + this.main + "\\0\", 5432, \"" + this.second + "\\0\", 5432, BUFFER, sizeof(BUFFER),};");
        //            sw.WriteLine("int master = 1;");
        //            sw.WriteLine("int nomer = 1;");
        //        }
        //        // здесь добавляем код -------------------------------


        //        foreach (Variable var in variables.Values)
        //        {
        //            sw.WriteLine("#define " + var.name + "\t BUFFER[" + var.address + "]\t//" + var.description);
        //            sw.WriteLine("#define id" + var.name + "\t " + var.id + "\t//" + var.description);
        //        }

        //        sw.WriteLine("#pragma pack(push,1)");
        //        sw.WriteLine("static VarCtrl allVariables[]={      // Описание всех переменных");
        //        foreach (Variable var in variables.Values)
        //        {
        //            // правка 18 октября
        //            sw.WriteLine("\t{ " + var.id + "\t," + var.format + "\t," + var.size + "\t, &" + var.name + "},\t//" + var.description);
        //        }
        //        sw.WriteLine("\t{-1,0,NULL},");
        //        sw.WriteLine("};");
        //        sw.WriteLine("static char NameSaveFile[]=\"" + namesavefile + "\\0\";   // Имя файла для сохранения констант");
        //        sw.WriteLine("#pragma pop");
        //        sw.WriteLine("static VarSaveCtrl saveVariables[]={      // Id переменных для сохранения");
        //        foreach (Save sv in saves)
        //        {
        //            Variable var = variables[sv.name];
        //            //sw.Write(var.id + ",");
        //            sw.Write("{" + var.id + ",\"" + sv.name + "\\0\"" + "}, \n");
        //        }
        //        sw.WriteLine("{0,NULL}\n};");
        //        string ModStr = "static ModbusDevice modbuses[]={\n";
        //        foreach (ModbusDevice mb in modbuses)
        //        {
        //            String coil = "#pragma pack(push,1)\nstatic ModbusRegister coil_" + mb.name + "[]={  // \n";
        //            String di = "#pragma pack(push,1)\nstatic ModbusRegister di_" + mb.name + "[]={  // \n";
        //            String ir = "#pragma pack(push,1)\nstatic ModbusRegister ir_" + mb.name + "[]={  // \n";
        //            String hr = "#pragma pack(push,1)\nstatic ModbusRegister hr_" + mb.name + "[]={  // \n";
        //            if (mb.registers != null)
        //                foreach (Register reg in mb.registers)
        //                {
        //                    String str = "\t{&" + reg.name + "," + reg.format + "," + reg.address + "},\t//" + reg.description + "\n";
        //                    switch (reg.type)
        //                    {
        //                        case 0:
        //                            coil += str;
        //                            break;
        //                        case 1:
        //                            di += str;
        //                            break;
        //                        case 2:
        //                            ir += str;
        //                            break;
        //                        case 3:
        //                            hr += str;
        //                            break;
        //                    }
        //                }
        //            coil += "\t{NULL,0,0},\n};";
        //            di += "\t{NULL,0,0},\n};";
        //            ir += "\t{NULL,0,0},\n};";
        //            hr += "\t{NULL,0,0},\n};";
        //            sw.WriteLine(coil);
        //            sw.WriteLine("#pragma pop");
        //            sw.WriteLine(di);
        //            sw.WriteLine("#pragma pop");
        //            sw.WriteLine(ir);
        //            sw.WriteLine("#pragma pop");
        //            sw.WriteLine(hr);
        //            sw.WriteLine("#pragma pop");
        //            if (mb.isMaster())
        //            {
        //                sw.WriteLine("static char " + mb.name + "_ip1[]={\"" + mb.ip1 + "\\0\"};");
        //                sw.WriteLine("static char " + mb.name + "_ip2[]={\"" + mb.ip2 + "\\0\"};");
        //            }
        //            //sw.WriteLine("#pragma pack(push,1)");
        //            ModStr += "\t{" + (mb.type ? 1 : 0) + "," + mb.port + ",&coil_" + mb.name + "[0],&di_" + mb.name + "[0],&ir_" + mb.name + "[0],&hr_" + mb.name + "[0]";
        //            ModStr += ",NULL";
        //            if (mb.isMaster())
        //            {
        //                ModStr += "," + mb.name + "_ip1";
        //                ModStr += "," + mb.name + "_ip2";
        //                ModStr += "," + mb.step;
        //            }
        //            else
        //            {
        //                ModStr += ",NULL,NULL,0";

        //            }
        //            ModStr += "},\t //" + mb.description + "\n";

        //            //sw.WriteLine("#pragma pop");
        //        }
        //        sw.WriteLine("#pragma pack(push,1)");
        //        sw.WriteLine(ModStr);
        //        sw.WriteLine("\t{0,-1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0},};");
        //        sw.WriteLine("#pragma pop");

        //        foreach (Device dev in devices)
        //        {
        //            Driver drv = LoadingUtils.defdrv[dev.driver];
        //            drv.main = this.main;
        //            drv.second = this.second;
        //            sw.WriteLine(drv.MakeDrvString(dev));
        //        }
        //        sw.WriteLine("#pragma pack(push,1)");
        //        sw.WriteLine("static Driver drivers[]={");

        //        foreach (Device dev in devices)
        //        {
        //            sw.WriteLine(dev.MakeDeviceString());
        //        }
        //        sw.WriteLine("\t{0,0,0,0,NULL,NULL},\n};");
        //        sw.WriteLine("#pragma pop");

        //        sw.WriteLine("void InitSetConst(void){      // Инициализация  переменных для сохранения");
        //        foreach (Save sv in saves)
        //        {
        //            if (sv.value == null) continue;
        //            Variable var = variables[sv.name];
        //            switch (var.format)
        //            {
        //                case 1:
        //                case 18:
        //                    sw.WriteLine("\tsetAsBool(" + var.id + "," + sv.value + ");");
        //                    break;
        //                case 2:
        //                case 3:
        //                    sw.WriteLine("\tsetAsShort(" + var.id + "," + sv.value + ");");
        //                    break;
        //                case 4:
        //                case 5:
        //                    sw.WriteLine("\tsetAsInt(" + var.id + "," + sv.value + ");");
        //                    break;
        //                case 8:
        //                    sw.WriteLine("\tsetAsFloat(" + var.id + "," + sv.value + ");");
        //                    break;
        //                case 11:
        //                    sw.WriteLine("\tsetAsLong(" + var.id + "," + sv.value + ");");
        //                    break;
        //                case 14:
        //                    sw.WriteLine("\tsetAsDouble(" + var.id + "," + sv.value + ");");
        //                    break;
        //            }
        //        }
        //        sw.WriteLine("}");

        //        // 6 августа
        //        //if(this.description.ToLower().Contains("aknp"))sw.WriteLine(AddCodeAknp());                
        //        // 7 сентября 2018 -- Иван генерация нового файла 1.h
        //        if (this.description.ToLower().Contains("aknp") ||
        //            this.description.ToLower().Contains("rpu"))
        //            sw.WriteLine(AddCodeAknp());

        //        result += "File " + path + name + ".h" + " done...\n";

        //        string st = this.rezult.Substring(0, this.rezult.Length - 3) + @"Scheme\";
        //        if (FindFile("Scheme.h", st))
        //        {
        //            sw.WriteLine(AddCode_H(st + "Scheme.h"));
        //        }
        //        else
        //        {
        //            sw.WriteLine("void Scheme(void)");
        //            sw.WriteLine("{");
        //            sw.WriteLine("}");
        //        }

        //        // 

        //        sw.WriteLine("#endif");
        //    }
        //    return result;
        //}

        string AddCodeAknp()
        {
            //StreamReader fs = new StreamReader(@"Add_Aknp__.h", Encoding.GetEncoding(1251));
            //string s = "";
            //string line = "";
            //while ((line = fs.ReadLine()) != null)
            //{
            //    s += line + "\r\n";
            //}
            //string m = "";
            //m = "11";
            //return s;

            return "";

        }


        bool FindFile(string nameFileH, string path)
        {
            ////foreach (string s in Operate.ListDirectoryFiles(Operate.Replace(path)))
            //foreach (string s in Operate.ListDirectoryFilesH(path))
            //{
            //    if (s.Contains(nameFileH)) return true;
            //}
            //return false;
            return false;
        }

        string AddCode_H(string path)
        {
            //StreamReader fs = new StreamReader(
            //    //@"D:\MD\pti\pr\scm\scheme\Scheme.h",
            //    Operate.d.SelectedPath + "\\" + path,   // правка 20 февраля 2019 - добавлены \\ флэша
            //    Encoding.GetEncoding(1251));
            //if (fs.ReadLine() == null)
            //{
            //    return "notfilescheme.h";
            //}
            //string s = "";
            //string line = "";
            //int m = 0;
            //String nn = "";
            //while ((line = fs.ReadLine()) != null)
            //{
            //    string newLine = "";

            //    string a = "";
            //    string b = "";
            //    //string c = "";

            //    string nnn = this.name;
            //    if (this.key == "on")
            //    {
            //        if (line.Contains("void Scheme()"))
            //            if (this.name == "DU" || this.name == "Baz1" || this.name == "Baz2" || this.name == "scm")
            //            {
            //                if (this.name == "DU" || this.name == "Baz1" || this.name == "Baz2") a = "int freebuff = 0," + " delay = 0;\n";
            //                else a = "int freebuff = 0;\n";
            //            }

            //        if (line.ToLower().Contains("getAsBool(idbFirstEnterFlag".ToLower()))
            //            //a = "if ((getAsInt(idR0MW11IP1) == 2) || (getAsInt(idR0MW11IP1) == 3)) { \n";
            //            a = "if ((getAsShort(id" + this.keyname + ") == 2) || (getAsShort(id" + this.keyname + ") == 3)) { \n" +
            //            ((this.name == "DU" || this.name == "Baz1" || this.name == "Baz2") ?
            //            ((this.name == "DU") ? "     if(delay++ < " + this.delaycycle + ") return;\n" :
            //            ((this.name == "Baz1" || this.name == "Baz2") ? "     if(delay++ < " + this.delaycycle + ") return;\n" : "")) : ((this.name == "scm") ? "" : "")) +
            //            "     freebuff = 0;\n" +
            //            ((this.name == "DU" || this.name == "Baz1" || this.name == "Baz2") ? "     delay = delay > 32000 ? 32000 : delay; \n" : "");


            //        if (line.ToLower().Contains("setAsBool(idbFirstEnterFlag".ToLower()))
            //        {
            //            //if (this.name == "DU") c = " else delay = 0; ";
            //            b = " \n }" +
            //                ((this.name == "DU" || this.name == "Baz1" || this.name == "Baz2" || this.name == "scm") ? "\n else {" +
            //            ((this.name == "DU" || this.name == "Baz1" || this.name == "Baz2") ? "\n      delay = 0;\n" : "\n") +
            //            "      if (freebuff)\n" +
            //            "            return;\n" +
            //            "       else{\n" +
            //            "           freebuff = 1;\n" +
            //                "           memset(BUFFER, 0, SIZE_BUFFER);\n" +
            //            "           InitSetConst();\n" +
            //                        "           initAllDrivers(drivers);\n" +
            //                "           }\n" +
            //        "       }\n"
            //        : "\n");
            //        }



            //    }
            //    newLine = a + line + b;



            //    //if (line.Contains("InitInternalParametr(void)"))
            //    if (line.Contains("_1[i] = &(&") && line.Contains(")[i]"))
            //    {
            //        m = 2;
            //        //string str = line.Substring("internal1_m1099_trz".Length, line.Length-3);
            //        string varName = (line.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries))[1].Substring(1);
            //        //string ss3 = variables[varName].size.ToString();
            //        if (variables.ContainsKey(varName)) newLine = line.Substring(0, line.Length - 2) + "*" + variables[varName].lenDataWithError() + "];";
            //        else newLine = line;
            //        m = 4;
            //    }
            //    s += newLine + "\r\n";
            //    nn += newLine + "\r\n";
            //}
            //m = 5;
            ////s = Win1251ToUTF8(s);
            ////nn = Win1251ToUTF8(nn);

            ////string text = "Р—Р°РєР°Р· Р·РІРѕРЅРєР° С‚РµС…РЅРёС‡РµСЃРєРѕР№ РїРѕРґРґРµСЂР¶РєРё";
            //string text = nn;
            //Encoding utf8 = Encoding.GetEncoding("UTF-8");
            //Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            //byte[] utf8Bytes = win1251.GetBytes(text);
            //byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);

            ////Console.WriteLine(win1251.GetString(win1251Bytes));

            //return text;
            return "";
        }

        private string Win1251ToUTF8(string source)
        {

            Encoding utf8 = Encoding.GetEncoding("utf-8");
            Encoding win1251 = Encoding.GetEncoding("windows-1251");

            //Encoding win1251 = Encoding.GetEncoding("utf-8");
            //Encoding utf8 = Encoding.GetEncoding("windows-1251");

            byte[] utf8Bytes = win1251.GetBytes(source);
            byte[] win1251Bytes = Encoding.Convert(win1251, utf8, utf8Bytes);
            source = win1251.GetString(win1251Bytes);
            return source;

        }
    }
}
