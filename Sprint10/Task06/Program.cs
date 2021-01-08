using System;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface IFlyable
    {
        void Fly();
    }

    interface IEating
    {
        void Eat();
    }

    interface IMoving
    {
        void Move();
    }

    interface IBasking
    {
        void Bask();
    }

    interface IKryaking
    {
        void Krya();
    }

    class Bird : IFlyable, IEating, IMoving
    {
        public void Fly() => Console.WriteLine("I believe, I can fly");
        public virtual void Eat() => Console.WriteLine("Oh! My corn!");
        public virtual void Move() => Console.WriteLine("I can jump!");
    }

    class Duck : Bird, IKryaking
    {
        public void Krya() => Console.WriteLine("Krya-Krya!");
        public override void Eat() => Console.WriteLine("Oh! My corn!");
        public override void Move() => Console.WriteLine("I can swimm!");
    }

    class Cat : IEating, IMoving, IBasking
    {
        public void Eat() => Console.WriteLine("Oh! My milk!");
        public void Move() => Console.WriteLine("I can jump!");
        public void Bask() => Console.WriteLine("Mrrr-Mrrr-Mrrr...");
    }

    class Parrot : Bird, IKryaking, IBasking
    {
        public override void Eat() => Console.WriteLine("Oh! My seeds and fruits!");
        public override void Move() => Console.WriteLine("I can jump!");
        public void Krya() => Console.WriteLine("Krya-Krya-Krya...");
        public void Bask() => Console.WriteLine("Chuh-Chuh-Chuh...");
    }
}
