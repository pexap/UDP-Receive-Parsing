using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Tes_Parsing
{
    public class Program
    {

        static void Main(string[] args)
        {
            //string dataIn;

            Console.Write("Menunggu data yang akan diparsing : ");

            UdpClient udp = new UdpClient(6300);
            IPEndPoint IP = new IPEndPoint(IPAddress.Any, 0);
            byte[] receive = udp.Receive(ref IP);
            string dataIn = Encoding.ASCII.GetString(receive);
           
        }

        public static void ParsingData(string data)
        {
            string[] dt = new string[10];
            int i;
            int j = 0;

            string dataIn = data;
            //dataIn = Console.ReadLine();
            Console.WriteLine("Data : " + dataIn);

            //Parsing
            for (i = 1; i < dataIn.Length; i++)
            {
                if ((dataIn[i] == '*') || (dataIn[i] == '#') || (dataIn[i] == ','))
                {
                    j++;
                    dt[j] = "";
                }
                else
                {
                    dt[j] = dt[j] + dataIn[i];
                }
            }

            Console.WriteLine("Hasil Parsing: ");
            Console.WriteLine("Data Bola X : " + dt[0]);
            Console.WriteLine("Data Bola Y : " + dt[1]);
            Console.WriteLine("Data Robot X : " + dt[2]);
            Console.WriteLine("Data Robot Y : " + dt[3]);
            Console.WriteLine("Data Robot T : " + dt[4]);
            Console.WriteLine("Data Robot VX : " + dt[5]);
            Console.WriteLine("Data Robot VY : " + dt[6]);
        }
    }
}
