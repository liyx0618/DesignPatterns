using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//代理模式
namespace ConsoleProxyPattern
{
    public interface Image
    {
        void display();
    }

    public class RealImage : Image
    {
        private String fileName;

        public RealImage(String fileName)
        {
            this.fileName = fileName;
            loadFromDisk(fileName);
        }

        public void display()
        {
            Console.WriteLine("Displaying " + fileName);
        }

        private void loadFromDisk(String fileName)
        {
            Console.WriteLine("Loading " + fileName);
        }
    }

    public class ProxyImage : Image
    {
        private RealImage realImage;
        private String fileName;

        public ProxyImage(String fileName)
        {
            this.fileName = fileName;
        }

        public void display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.display();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Image image = new ProxyImage("test_10mb.jpg");

            //图像将从磁盘加载
            image.display();
            Console.WriteLine("");
            //图像将无法从磁盘加载
            image.display();
            Console.ReadKey();
        }
    }
}