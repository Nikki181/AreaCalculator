using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArea
{
    public class Areacalculator
    {
        int index = 0;
        public static void Main(string[] args)
        {
            //Using dictionary to store shape and it's area
            Dictionary<int, double> storearea = new Dictionary<int, double>();
            Dictionary<int, string> storeshape = new Dictionary<int, string>();

            Areacalculator p = new Areacalculator(); //Making object of the class to access different methods
            
            //Reading input file
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\nikki\Desktop\Coding Test\CalculateArea\UserInputFile.txt");

            foreach (string line in lines)
            {
                p.UserInput(storearea, storeshape,line.Trim());
            }

            Console.WriteLine("Area Calculator - Final Output:\n");
            foreach(var item in storearea.OrderByDescending(x => x.Value))
            {
                Console.WriteLine(storeshape[item.Key] +  " -> " + Math.Round(item.Value, 2));
            }
        }
        public void UserInput(Dictionary<int, double> storearea, Dictionary<int, string> storeshape,string choice)
        {
            double area = 0;            
            var width = 0.0;
            var height = 0.0;

            Areacalculator p = new Areacalculator();
            if (choice != "")
            {
                string[] elements = choice.Split(' ');
                var shape = elements[0].ToLower();
                switch (shape)
                {
                    case "rectangle":
                        if (elements.Length == 3)
                        {
                            width = Convert.ToDouble(elements[1]);
                            height = Convert.ToDouble(elements[2]);
                            if (width > 0 && height > 0)
                            {
                                area = p.Rectangle(width, height);
                                storeshape[index] = "Rectangle";
                                storearea[index++] = area;
                            }
                        }
                        break;
                    case "square":
                        if (elements.Length == 2)
                        {
                            width = Convert.ToDouble(elements[1]);
                            if (width > 0)
                            {
                                area = p.Square(width);
                                storeshape[index] = "Square";
                                storearea[index++] = area;
                            }
                        }
                        break;
                    case "triangle":
                        if (elements.Length == 3)
                        {
                            width = Convert.ToDouble(elements[1]);
                            height = Convert.ToDouble(elements[2]);
                            if (width > 0 && height > 0)
                            {
                                area = p.Triangle(width, height);
                                storeshape[index] = "Triangle";
                                storearea[index++] = area;
                            }
                        }
                        break;
                    case "circle":
                        if (elements.Length == 2)
                        {
                            width = Convert.ToDouble(elements[1]);
                            if (width > 0)
                            {
                                area = p.Circle(width);
                                storeshape[index] = "Circle";
                                storearea[index++] = area;
                            }
                        }
                        break;
                }                
            }
        }
        public double Rectangle(double width, double height)
        {
            return (height* width);
        }
        public double Circle(double diameter)
        {
            return ((3.14 * diameter * diameter)/4);
        }
        public double Square(double width)
        {
            return (width * width);
        }
        public double Triangle(double width, double height)
        {
            return ((width * height) / 2);
        }
    }
}
