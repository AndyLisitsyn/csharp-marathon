using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            new EventProgram();
        }

        class EventProgram
        {
            event EventHandler Show;

            public EventProgram()
            {
                Show += Dog;
                Show += Cat;
                Show += Mouse;
                Show += Elephant;
                Show(this, null);
            }

            static void Dog(object sender, EventArgs e)
            {
                Console.WriteLine("Dog");
            }

            static void Cat(object sender, EventArgs e)
            {
                Console.WriteLine("Cat");
            }

            static void Mouse(object sender, EventArgs e)
            {
                Console.WriteLine("Mouse");
            }

            static void Elephant(object sender, EventArgs e)
            {
                Console.WriteLine("Elephant");
            }
        }
    }
}
