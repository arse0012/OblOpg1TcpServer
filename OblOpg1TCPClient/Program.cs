using System;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BikeClient bike1= new BikeClient();
            bike1.Start();

            Console.ReadLine();
        }
    }
}
