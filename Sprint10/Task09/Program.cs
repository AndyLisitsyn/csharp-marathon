using System;

namespace Task09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface ILead
    {
        void CreateSubTask();
        void AssignTask();
    }

    interface IProgrammer
    {
        void WorkOnTask();
    }

    class TeamLead : ILead, IProgrammer
    {
        public void CreateSubTask() { }
        public void AssignTask() { }
        public void WorkOnTask() { }
    }

    class Manager : ILead
    {
        public void CreateSubTask() { }
        public void AssignTask() { }
    }

    class Programmer : IProgrammer
    {
        public void WorkOnTask() { }
    }
}
