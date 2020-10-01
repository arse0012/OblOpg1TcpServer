using System;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            BikeServer bike1 = new BikeServer();
            bike1.Start();

            Console.ReadLine();
        }
    }
}
