using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//访问者模式
namespace ConsoleVisitorPattern
{
    /// <summary>
    /// 计算机零件
    /// </summary>
    public interface ComputerPart
    {
        void accept(ComputerPartVisitor computerPartVisitor);
    }

    /// <summary>
    /// 键盘
    /// </summary>
    public class Keyboard : ComputerPart
    {
        public void accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }

    /// <summary>
    /// 显示器
    /// </summary>
    public class Monitor : ComputerPart
    {
        public void accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }

    /// <summary>
    /// 鼠标
    /// </summary>
    public class Mouse : ComputerPart
    {
        public void accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }

    /// <summary>
    /// 主机
    /// </summary>
    public class Computer : ComputerPart
    {
        private ComputerPart[] parts;

        public Computer()
        {
            parts = new ComputerPart[] { new Mouse(), new Keyboard(), new Monitor() };
        }

        public void accept(ComputerPartVisitor computerPartVisitor)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].accept(computerPartVisitor);
            }
            computerPartVisitor.visit(this);
        }
    }

    /// <summary>
    /// 主机部件访问
    /// </summary>
    public interface ComputerPartVisitor
    {
        /// <summary>
        /// 访问
        /// </summary>
        /// <param name="computer"></param>
        void visit(Computer computer);

        /// <summary>
        /// 访问
        /// </summary>
        /// <param name="mouse"></param>
        void visit(Mouse mouse);

        /// <summary>
        /// 访问
        /// </summary>
        /// <param name="keyboard"></param>
        void visit(Keyboard keyboard);

        /// <summary>
        /// 访问
        /// </summary>
        /// <param name="monitor"></param>
        void visit(Monitor monitor);
    }

    /// <summary>
    /// 计算机显示访问者
    /// </summary>
    public class ComputerPartDisplayVisitor : ComputerPartVisitor
    {
        public void visit(Computer computer)
        {
            Console.WriteLine("Displaying Computer.");
        }

        public void visit(Mouse mouse)
        {
            Console.WriteLine("Displaying Mouse.");
        }

        public void visit(Keyboard keyboard)
        {
            Console.WriteLine("Displaying Keyboard.");
        }

        public void visit(Monitor monitor)
        {
            Console.WriteLine("Displaying Monitor.");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            ComputerPart computer = new Computer();
            computer.accept(new ComputerPartDisplayVisitor());
            Console.ReadKey();
        }
    }
}