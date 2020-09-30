using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    public class BikeServer
    {
        public void Start()
        {
            //opret server
            TcpListener bikeServer = new TcpListener(IPAddress.Loopback, 4646);
            bikeServer.Start();

            TcpClient socket = bikeServer.AcceptTcpClient();


        }

        public void DoClient(TcpClient socket)
        {
            //net Stream
            NetworkStream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            string str = sr.ReadLine();

            //skriv til klient
            //resultatet af integers
            sw.WriteLine();
            sw.Flush();//tømmer buffer
        }
    }
}
