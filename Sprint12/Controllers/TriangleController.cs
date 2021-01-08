using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sprint12_Task01.Models;

namespace Sprint12_Task01.Controllers
{
    public class TriangleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Area(int side1, int side2, int side3)
        {
            Triangle triangle = new Triangle(side1, side2, side3);
            ViewBag.Title = "Area";
            ViewBag.Result = Math.Round(triangle.CalcArea(), 0);
            return View("Index");
        }

        public IActionResult Perimeter(int side1, int side2, int side3)
        {
            Triangle triangle = new Triangle(side1, side2, side3);
            ViewBag.Title = "Perimeter";
            ViewBag.Result = triangle.CalcPerimeter();
            return View("Index");
        }

        public string Info(int side1, int side2, int side3)
        {
            Triangle triangle = new Triangle(side1, side2, side3);
            ViewBag.Title = "Info";
            ViewBag.Result = triangle.GetInfo();
            return triangle.GetInfo();
            /*  return View("Index");*/
        }

        public IActionResult GreatesByPerimeter(Triangle[] tr)
        {
            double[] perim = new double[tr.Length];
            for (int i = 0; i < tr.Length; i++)
            {
                if (tr[i].isValidTriangle())
                {
                    perim[i] = tr[i].CalcPerimeter();
                }
                else
                {
                    throw new ArgumentException("Cannot created Triangle with such sides");
                }
            }
            ViewBag.Title = "GreatesByPerimeter";
            ViewBag.Result = perim.OrderByDescending(item => item).First();
            return View("Index");
        }

        public IActionResult GreatestByArea(Triangle[] tr)
        {
            double[] area = new double[tr.Length];
            for (int i = 0; i < tr.Length; i++)
            {
                if (tr[i].isValidTriangle())
                {
                    area[i] = tr[i].CalcArea();
                }
                else
                {
                    throw new ArgumentException("Cannot created Triangle with such sides");
                }

            }
            ViewBag.Title = "GreatestByArea";
            ViewBag.Result = Math.Round(area.OrderByDescending(item => item).First(), 0);

            return View("Index");
        }

        public IActionResult IsEquilateral(int side1, int side2, int side3)
        {
            Triangle triangle = new Triangle(side1, side2, side3);
            ViewBag.Title = "IsEquilateral";
            ViewBag.Result = triangle.IsEquilateral();
            return View("Index");
        }

        public IActionResult IsIsosceles(int side1, int side2, int side3)
        {
            Triangle triangle = new Triangle(side1, side2, side3);
            ViewBag.Title = "IsIsosceles";
            ViewBag.Result = triangle.IsIsosceles();
            return View("Index");
        }

        public IActionResult AreCongruent(Triangle tr1, Triangle tr2)
        {
            ViewBag.Title = "AreCongruent";
            if (tr1.isValidTriangle() && tr2.isValidTriangle())
            {
                ViewBag.Result = tr1.AreCongruent(tr2);
                return View("Index");
            }
            else
            {
                throw new ArgumentException("Cannot created Triangle with such sides");
            }
        }

        public IActionResult AreSimilar(Triangle tr1, Triangle tr2)
        {
            ViewBag.Title = "AreSimilar";
            if (tr1.isValidTriangle() && tr2.isValidTriangle())
            {
                ViewBag.Result = tr1.IsSimilar(tr2);
                return View("Index");
            }
            else
            {
                throw new ArgumentException("Cannot created Triangle with such sides");
            }
        }

        public IActionResult IsRightAngled(Triangle tr1)
        {
            ViewBag.Title = "IsRightAngled";
            if (tr1.isValidTriangle())
            {
                ViewBag.Result =  tr1.IsRightAngled();
                return View("Index");
            }
            else
            {
                throw new ArgumentException("Cannot created Triangle with such sides");
            }
        }

        public string PairwiseNonSimilar(Triangle[] tr)
        {
            ViewBag.Title = "NonSimilar";
            return Triangle.PairwiseNonSimilar(tr);
        }
    }
}
