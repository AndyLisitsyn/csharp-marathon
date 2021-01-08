using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Example.Do();
        }
    }

    enum ColourEnum
    {
        Red,
        Green,
        Blue
    }

    interface IColoured
    {
        ColourEnum Colour { get => ColourEnum.Red; }
    }

    interface IDocument
    {
        static string defaultText = "Lorem ipsum";
        int Pages { get => 0; set { } }
        string Name { get; set; }
        void AddPages(int increment) => Pages += increment;
        void Rename(string name) => Name = name;
    }

    class ColouredDocument : IColoured, IDocument
    {
        public string Name { get; set; }
        public int Pages { get; set; }
        public ColourEnum Colour { get; set; }

        public ColouredDocument(ColourEnum colour)
        {
            Colour = colour;
        }

        public ColouredDocument() { }
    }

    class Example
    {
        public static void Do()
        {
            IDocument doc1 = new ColouredDocument
            {
                Name = "Document1"
            };
            Console.WriteLine(doc1.Name);
            doc1.Rename("Document2");
            Console.WriteLine(doc1.Name);
        }
}
}

