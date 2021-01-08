using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new CircleOfChildren(new string[] { "Halya1", "Olya2", "Ira3", "Andriy4", "Josh5" });
            OutputUtils.ExitOutput(circle, 3);
        }
    }

    public class CircleOfChildren
    {
        private List<string> children;

        public CircleOfChildren(IEnumerable<string> children)
        {
            this.children = children.ToList();
        }

        public IEnumerable GetChildrenInOrder(int syllablesCount, int childrenCount = 0)
        {
            if (syllablesCount <= 0)
                yield break;
            if (childrenCount > children.Count || childrenCount <= 0)
                childrenCount = children.Count;

            int oldChildIndex = 0;
            for (int i = 0; i < childrenCount; i++)
            {
                int childIndex = oldChildIndex + syllablesCount - 1;
                while (childIndex >= children.Count)
                    childIndex -= children.Count;
                string child = (string)children[childIndex].Clone();
                children.RemoveAt(childIndex);
                oldChildIndex = childIndex;
                yield return child;
            }
        }
    }

    public class OutputUtils
    {
        public static void ExitOutput(CircleOfChildren circle, int syllablesCount, int childrenCount = 0)
        {
            foreach (var child in circle.GetChildrenInOrder(syllablesCount, childrenCount))
            {
                Console.Write(child + " ");
            }
        }
    }
}
