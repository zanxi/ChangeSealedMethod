using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Collections.Concurrent;

namespace ChangeSealedMethod
{
    // Создаем класс DumpBulkPacket
    // По протоколу TCP идет отправка и чтение пакета данных
    // для простоты строковые данные

    public sealed class DumpBulkPacket
    {

        // адрес и порт сервера, к которому будем подключаться
        int port; // порт сервера
        string address; // адрес сервера
        int max_id=1024*10;
        bool connect = false;
        Thread getPhoto;

        String[] values;
        String[] valuesMassive = { "Empty" };
        ConcurrentQueue<Val> que;
        int step_id = 1200;
        public bool Status = false;
        public Dictionary<String, Variable> variables;
        //public Project project = null;

        public DumpBulkPacket(string address, int port, int max_id)
        {
            this.address = address;
            this.port = port;
            this.max_id = max_id;
            values = new string[max_id + 1];
            que = new ConcurrentQueue<Val>();
            Status = true;
        }

        //public DumpBulkPacket(Project project, string nameSubs, string ip) // 23 мая 13:33 правка public Dumper(string nameSubs) 23 мая Zanxi
        public DumpBulkPacket(string nameSubs, string ip) // 23 мая 13:33 правка public Dumper(string nameSubs) 23 мая Zanxi
        {
            //if (project == null) return;
            //if (!(project.subs.ContainsKey(nameSubs)))
            //{
            //    return;
            //}

            //Subsystem sub = new Subsystem(); // project.subs[nameSubs];
            //variables = sub.variables;
            //max_id = 0;
            //foreach (Variable var in variables.Values)
            //{
            //    max_id = Math.Max(var.id, max_id);
            //}

            this.address = ip;
            this.port = 1080;
            values = new string[max_id + 1];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = "0";
            }
            que = new ConcurrentQueue<Val>();
            Status = true;
        }

        public string GetValueStr(string name)
        {
            //lock (lockDump)
            {
                if (!variables.ContainsKey(name)) return null;
                return values[variables[name].id];
            }
        }

        public string GetValue(int id)
        {
            return values[id];
        }


        public string GetValueMassive(int id, int size)
        {
            Socket socket_;
            string varMasValue = "Empty";
            try
            {
                byte[] data = new byte[128000]; // буфер для ответа
                int bytes = 0; // количество полученных байт
                Val val = new Val();

                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                socket_ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket_.Connect(ipPoint);
                socket_.ReceiveTimeout = 1000;
                socket_.SendTimeout = 100;
                StringBuilder builder = new StringBuilder();
                byte[] breq = Encoding.ASCII.GetBytes("A" + id + " " + size);
                socket_.Send(breq);
                do
                {
                    if (socket_.Connected == false)
                        break;
                    bytes = socket_.Receive(data, data.Length, 0);
                    builder.Append(Encoding.ASCII.GetString(data, 0, bytes));

                }
                while (bytes > 0);
                varMasValue = builder.ToString();
                socket_.Close();
            }
            catch (Exception err)
            {
                string str = err.Message;
                int m = 0;
            }

            return varMasValue;
        }




        public void SetValue(int id, string value)
        {
            que.Enqueue(new Val(id, value));
        }
        public void SetValue(string name, string value)
        {
            if (!variables.ContainsKey(name)) return;
            que.Enqueue(new Val(variables[name].id, value));
        }
        public bool isConnected()
        {
            return connect;
        }
        public bool Connect()
        {
            connect = false;
            try
            {
                //                socket.ReceiveTimeout = 1;
                getPhoto = new Thread(Run);
                getPhoto.IsBackground = true;
                getPhoto.Start();
                connect = true;
            }
            catch (Exception ex)
            {
                //Util.errorMessage("Dumper: ", ex.Message);
            }
            return connect;
        }

        public void Close()
        {
            connect = false;
            getPhoto.Abort();
        }

        //public object lockDump = new object();
        void Run()
        {

            while (true)
            {
                Thread.Sleep(500);
            }


            return; 


            Socket socket = null;
            byte[] data = new byte[128000]; // буфер для ответа
            int bytes = 0; // количество полученных байт
            Val val = new Val();
            try
            {
                while (true)
                {
                    while (que.TryDequeue(out val))
                    {
                        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        // подключаемся к удаленному хосту
                        values[val.id] = val.value;
                        socket.Connect(ipPoint);
                        string strValueSend = "W" + val.id + " " + val.value + "";
                        byte[] breq = Encoding.ASCII.GetBytes(strValueSend);
                        socket.Send(breq);
                        socket.Close();
                    }
                    Thread.Sleep(500);
                    int id = 1;
                    while (id <= max_id)
                    {
                        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        // подключаемся к удаленному хосту
                        socket.Connect(ipPoint);
                        socket.ReceiveTimeout = 1000;
                        socket.SendTimeout = 100;
                        StringBuilder builder = new StringBuilder();
                        //variables.si
                        byte[] breq = Encoding.ASCII.GetBytes("R" + id + " " + (id + step_id));
                        socket.Send(breq);
                        do
                        {
                            bytes = socket.Receive(data, data.Length, 0);
                            builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
                        }
                        while (!builder.ToString().Contains("</vals>"));
                        XmlDocument xmls = new XmlDocument();
                        xmls.LoadXml(builder.ToString());
                        foreach (XmlNode v in xmls.SelectNodes("vals/val"))
                        {
                            values[int.Parse(v.Attributes["id"].Value)] =
                                v.Attributes["value"].Value;
                        }
                        id += step_id;
                        socket.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!connect) return;
                //Util.message(ex.Message + " : " + this.address);
                socket.Close();
                connect = false;
                return;
            }
        }


        class Val
        {
            public int id;
            public string value;
            public Val()
            {
                id = 1;
                value = "0.0";
            }

            public Val(int id, string value)
            {
                this.id = id;
                this.value = value;
            }
        }
    }
}
