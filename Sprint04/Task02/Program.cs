using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal dog = new Dog();
            dog.Voice();
        }
    }

    interface IAnimal
    {
        string Name { get; set; }
        void Voice();
        void Feed();
    }

    class Dog : IAnimal
    {
        public string Name { get; set; }
        public void Voice() => Console.WriteLine("Woof");
        public void Feed() => Console.WriteLine("I eat meat");
    }

    class Cat : IAnimal
    {
        public string Name { get; set; }
        public void Voice() => Console.WriteLine("Mew");
        public void Feed() => Console.WriteLine("I eat mice");
    }
}
