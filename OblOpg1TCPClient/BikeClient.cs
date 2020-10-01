using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using BikeLib;
using Newtonsoft.Json;

namespace TCPClient
{
    public class BikeClient
    {
        public void Start()
        {
            TcpClient socket = new TcpClient("localhost",4646);
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                Bike bike = new Bike(7,34,6,"green");

                string json = JsonConvert.SerializeObject(bike);
                
                sw.WriteLine(json);
            }
            socket?.Close();
        }
    }
}
