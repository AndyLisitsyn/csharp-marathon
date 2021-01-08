using System;
using System.Collections.Generic;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            var rec1 = new Rectangle
            {
                Length = 10,
                Width = 20
            };
            Room<Rectangle> room1 = new Room<Rectangle>()
            {
                Height = 3,
                Floor = rec1
            };
            Room<Rectangle> room2 = (Room<Rectangle>)room1.Clone();

            Console.WriteLine(room1.Height);
            Console.WriteLine(room2.Height);
            Console.WriteLine(room1.Floor.Area());
            Console.WriteLine(room2.Floor.Area());
            Console.WriteLine(room1.Volume());
            Console.WriteLine(room2.Volume());
            Console.WriteLine(room1.CompareTo(room2));
        }
    }

    interface IShape : ICloneable
    {
        double Area() => 0;
    }

    class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Area() => Length * Width;
        public object Clone() => MemberwiseClone();
    }

    class Trapezoid : IShape
    {
        public double Length1 { get; set; }
        public double Length2 { get; set; }
        public double Width { get; set; }
        public double Area() => (Length1 + Length2) / 2 * Width;
        public object Clone() => MemberwiseClone();
    }

    class Room<T> : IComparable, ICloneable where T : IShape
    {
        public double Height { get; set; }
        public T Floor { get; set; }
        public double Volume() => Floor.Area() * Height;
        public object Clone()
        {
            T floor = (T)Floor.Clone();
            return new Room<T>
            {
                Height = Height,
                Floor = floor
            };
        }
        public int CompareTo(object o)
        {
            if (o is Room<T> r)
                return Floor.Area().CompareTo(r.Floor.Area());
            else
                throw new Exception("Unable to compare");
        }
    }

    class RoomComparerByVolume<T> : IComparer<Room<T>> where T : IShape
    {
        public int Compare(Room<T> room1, Room<T> room2)
        {
            if (room1.Volume() > room2.Volume())
                return 1;
            else if (room1.Volume() < room2.Volume())
                return -1;
            else
                return 0;
        }
    }
}
