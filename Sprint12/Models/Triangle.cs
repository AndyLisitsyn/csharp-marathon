using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint12_Task01.Models
{
    public class Triangle
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }

        public Triangle() { }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (isValidTriangle(sideA,  sideB,  sideC))
            {
                Side1 = sideA;
                Side2 = sideB;
                Side3 = sideC;
            }
            else
            {
                throw new ArgumentException("Triangle with such sides cannot be created");
            }
        }

        public double CalcArea()
        {
            double halfPerimeter = CalcPerimeter() / 2.0;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - Side1) * (halfPerimeter - Side2) * (halfPerimeter - Side3));
        }

        public double CalcPerimeter()
        {
            return Side1 + Side2 + Side3;
        }

        public bool isValidTriangle()
        {
            if ((Side1 + Side2) > Side3 && (Side2 + Side3) > Side1 && (Side1 + Side3) > Side2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isValidTriangle(double side1, double side2, double side3)
        {
            if ((side1 + side2) > side3 && (side2 + side3) > side1 && (side1 + side3) > side2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEquilateral()
        {
            return Side1 == Side2 && Side2 == Side3;
        }

        public bool IsIsosceles()
        {
            return Side1 == Side2 || Side1 == Side3 || Side2 == Side3;
        }

        public bool AreCongruent(Triangle tr)
        {
            double[] s1 = { Side1, Side2, Side3 };
            double[] s2 = { tr.Side1, tr.Side2, tr.Side3 };
            Array.Sort(s1);
            Array.Sort(s2);
            return s1[0] == s2[0] && s1[1] == s2[1] && s1[2] == s2[2];
        }

        public bool IsSimilar(Triangle tr)
        {
            double[] s1 = { Side1, Side2, Side3 };
            double[] s2 = { tr.Side1, tr.Side2, tr.Side3 };
            Array.Sort(s1);
            Array.Sort(s2);
            return s1[0] / s2[0] == s1[1] / s2[1] &&
                s1[1] / s2[1] == s1[2] / s2[2] &&
                s1[2] / s2[2] == s1[0] / s2[0];
        }

        public bool IsRightAngled()
        {
            double[] s1 = { Side1, Side2, Side3 };
            Array.Sort(s1);
            if (Math.Pow(s1[2], 2) == (Math.Pow(s1[1], 2) + Math.Pow(s1[0], 2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string GetInfo()
        {
            double[] s2 = { Side1, Side2, Side3 };
            Array.Sort(s2);

            var perimeter = CalcPerimeter();
            var area = Math.Round(CalcArea(), 0);
            var reduce = $"{Math.Round(s2[0] / CalcPerimeter(), 2)}, {Math.Round(s2[1] / CalcPerimeter(), 2)}, {Math.Round(s2[2] / CalcPerimeter(), 2)}";

            return $"Triangle:{s2[0]}, {s2[1]}, {s2[2]}\nReduced:{reduce}\n\nArea = {area}\nPerimeter = {perimeter}\n";
        }

        public static string PairwiseNonSimilar(Triangle[] trs)
        {
            string result = "";
            for (int i = 0; i < trs.Length - 1; i++)
                if (!trs[i].IsSimilar(trs[i + 1]))
                    result += trs[i].GetInfo() + "\n";
            result += trs[trs.Length - 1].GetInfo();
            return result;
        }
    }
}
