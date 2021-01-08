using System;

namespace Question05
{
    class Program
    {
        static void Main(string[] args)
        {
            Acinonychini puma = new Puma
            {
                Speed = 50
            };
            puma.Move();
        }
    }

    abstract class Acinonychini
    {
        public int Speed { get; set; }

        public virtual void Move()
        {
            Console.WriteLine($" is moving at speed {Speed} mph");
        }
    }

    sealed class Acinonyx : Acinonychini
    {
        public override void Move()
        {
            Console.Write("Acinonyx");
            base.Move();
        }
    }

    class Puma : Acinonychini
    {
        public override void Move()
        {
            Console.Write("Puma");
            base.Move();
        }
    }
}
