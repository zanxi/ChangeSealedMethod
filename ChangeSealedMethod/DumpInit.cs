using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeSealedMethod
{    
    public sealed class DumpInit
    {
        public DumpBulkPacket dump;
        Thread thrDump;
        public string ip;
        public string nameSub;
        public List<Variable> listVar = new List<Variable>();
        //Project project = null;
        public DumpInit(string nameSystem, string ip)
        {
            this.ip = ip;
            this.nameSub = nameSystem;
            //this.project = project;


            //GetHoldAndCoil(project.subs[this.nameSub], dump);

            listVar = new List<Variable>();
            //listVar = project.subs[this.nameSub].variables.Values.ToList();

            dump = new DumpBulkPacket(nameSystem, ip);
            //ThreadStart thr = new ThreadStart();
            thrDump = new Thread(
                () =>
                {
                    while (true)
                    {
                        while (!(dump.isConnected()))
                        {
                            dump.Connect();
                            Thread.Sleep(1000);
                            //Util.message("Устройство <" + ip + "> не отвечает");
                        }
                        Thread.Sleep(400);
                    }
                });
            thrDump.IsBackground = true;
            thrDump.Start();
        }

        internal string GetValue(string name)
        {
            if (dump != null)
                if (dump.isConnected())
                    return dump.GetValueStr(name);
                else return "нет значения";
            throw new NotImplementedException();
        }


        public void GetValue_()
        {
            Console.WriteLine("DumpInit - GetValue_ - " + nameSub);
        }

        internal void SetValue(int id, string name)
        {
            if (dump != null)
                if (dump.isConnected()) dump.SetValue(id, name);

            throw new NotImplementedException();
        }

        internal void Recalc()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            if (thrDump != null)
            {
                if (thrDump.IsAlive)
                {
                    thrDump.Abort();
                    thrDump = null;
                }
                else thrDump = null;
            }
            Console.WriteLine("Stop DumpInit - "+nameSub);
            dump.Close();
        }
               

    }
}
