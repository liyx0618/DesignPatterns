using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//享元模式
namespace ConsoleFlyweightPattern
{
    public interface Shape
    {
        void draw();
    }

    public class Circle : Shape
    {
        private String color;
        private int x;
        private int y;
        private int radius;

        public Circle(String color)
        {
            this.color = color;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void setRadius(int radius)
        {
            this.radius = radius;
        }

        public void draw()
        {
            string str = string.Format("Circle: Draw() [Color:{0}, x:{1}, y:{2}, radius:{3}", color, x, y, radius);
            Console.WriteLine(str);
        }
    }

    public class ShapeFactory
    {
        private static IDictionary<String, Shape> circleMap = new Dictionary<String, Shape>();

        public static Shape getCircle(String color)
        {
            Circle circle = null; //= (Circle)circleMap[color];
            Shape shape;
            if (circleMap.TryGetValue(color, out shape))
                circle = (Circle)shape;

            if (circle == null)
            {
                circle = new Circle(color);
                circleMap.Add(color, circle);
                Console.WriteLine("Creating circle of color : " + color);
            }
            return circle;
        }
    }

    internal class Program
    {
        private static String[] colors = { "Red", "Green", "Blue", "White", "Black" };

        private static void Main(string[] args)
        {
            for (int i = 0; i < 20; ++i)
            {
                Circle circle = (Circle)ShapeFactory.getCircle(getRandomColor());
                circle.setX(getRandomX());
                System.Threading.Thread.Sleep(100);
                circle.setY(getRandomY());
                circle.setRadius(100);
                circle.draw();
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadKey();
        }

        private static String getRandomColor()
        {
            Random math = new Random();
            double random = math.NextDouble();
            //Console.WriteLine("getRandomColor random:" + random);
            return colors[(int)(random * colors.Length)];
        }

        private static int getRandomX()
        {
            Random math = new Random();
            double random = math.NextDouble();
            //Console.WriteLine("getRandomColor random:" + random);
            return (int)(random * 100);
        }

        private static int getRandomY()
        {
            Random math = new Random();
            double random = math.NextDouble();
            //Console.WriteLine("getRandomColor random:" + random);
            return (int)(random * 100);
        }
    }
}