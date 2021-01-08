using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Department
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Worker Manager { get; set; }

        public Department(string name, int id, Worker manager)
        {
            Name = name;
            Id = id;
            Manager = manager;
        }

        public Department() { }
    }

    class Worker
    {
        [JsonPropertyName("Full name")]
        public string Name { get; set; }
        [JsonIgnore]
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public Department Department { get; set; }

        public Worker(string name, decimal salary, Department department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public Worker() { }

        public string Serialize()
        {
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
        }

        public static Worker Deserialize(string json)
        {
            return JsonSerializer.Deserialize<Worker>(json);
        }
    }
}
