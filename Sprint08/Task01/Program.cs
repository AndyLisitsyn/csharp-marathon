using System;
using System.Threading;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class ParallelUtils<T, TR>
    {
        T operand1;
        T operand2;
        Func<T, T, TR> operation;
        public TR Result { get; set; }

        public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
        {
            this.operation = operation;
            this.operand1 = operand1;
            this.operand2 = operand2;
        }

        public void GetResult()
        {
            Result = operation(operand1, operand2);
        }

        public void StartEvaluation()
        {
            Thread thread = new Thread(new ThreadStart(GetResult));
            thread.Start();
        }

        public void Evaluate()
        {
            Thread thread = new Thread(new ThreadStart(GetResult));
            thread.Start(); ;
            thread.Join();
        }
    }
}
