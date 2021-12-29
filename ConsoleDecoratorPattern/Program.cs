using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//装饰模式
namespace ConsoleDecoratorPattern
{
    public interface Shape
    {
        void draw();
    }

    public class Rectangle : Shape
    {
        public void draw()
        {
            Console.WriteLine("Shape: Rectangle");
        }
    }

    public class Circle : Shape
    {
        public void draw()
        {
            Console.WriteLine("Shape: Circle");
        }
    }

    public abstract class ShapeDecorator : Shape
    {
        protected Shape decoratedShape;

        public ShapeDecorator(Shape decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }

        public void draw()
        {
            decoratedShape.draw();
        }
    }

    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(Shape decoratedShape)
            : base(decoratedShape)
        {
        }

        public void draw()
        {
            decoratedShape.draw();
            setRedBorder(decoratedShape);
        }

        private void setRedBorder(Shape decoratedShape)
        {
            Console.WriteLine("Border Color: Red");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Shape circle = new Circle();

            Shape redCircle = new RedShapeDecorator(new Circle());

            Shape redRectangle = new RedShapeDecorator(new Rectangle());
            Console.WriteLine("Circle with normal border");
            circle.draw();

            Console.WriteLine("\nCircle of red border");
            redCircle.draw();

            Console.WriteLine("\nRectangle of red border");
            redRectangle.draw();
            Console.ReadKey();
        }
    }
}