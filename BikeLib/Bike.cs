using System;
using System.Collections.Generic;
using System.Text;

namespace BikeLib
{
    public class Bike
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Gear { get; set; }
        public string Color { get; set; }

        public Bike()
        {

        }

        public Bike(int id, double price, int gear, string color)
        {
            Id = id;
            Price = price;
            Gear = gear;
            Color = color;
        }
    }
}
