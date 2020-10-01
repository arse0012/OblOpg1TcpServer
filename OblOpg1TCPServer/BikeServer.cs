using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BikeLib;
using Newtonsoft.Json;

namespace TCPServer
{
    public class BikeServer
    {
        private static List<Bike> _bikes = new List<Bike>()
        {
            new Bike(1,  29.9, 5,"Red"),
            new Bike(2, 36.3, 8,"Green"),
            new Bike(3, 43.5, 23, "Red"),
            new Bike(4, 53.9, 14, "Yellow"),
            new Bike(5, 50.0, 20, "Black")
        };
        public void Start()
        {
            
            TcpListener bikeServer = new TcpListener(IPAddress.Loopback, 4646);
            bikeServer.Start();

            while (true)
            { 
                TcpClient socket = bikeServer.AcceptTcpClient(); 
                Task.Run(
                    () => 
                    { 
                        TcpClient tmpSocket = socket; 
                        DoClient(tmpSocket);
                    }
                );
            }

        }

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                string bikeString = sr.ReadLine();

                Bike bike = JsonConvert.DeserializeObject<Bike>(bikeString);

                Console.WriteLine("Received bike json string" + bikeString);
                Console.WriteLine("Received bike : " + bike);
            }
            socket?.Close();
        }
    }
}
