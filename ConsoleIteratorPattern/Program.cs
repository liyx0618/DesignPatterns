using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//迭代模式
namespace ConsoleIteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            NameRepository namesRepository = new NameRepository();

            for (Iterator iter = namesRepository.getIterator(); iter.hasNext(); )
            {
                String name = (String)iter.next();
                Console.WriteLine("Name : " + name);
            }
            Console.ReadKey();
        }
    }


    public interface Iterator
    {
        bool hasNext();
        Object next();
    }

    public interface Container
    {
        Iterator getIterator();
    }

    public class NameRepository : Container
    {
        public static String[] names = { "Robert", "John", "Julie", "Lora" };

        public Iterator getIterator()
        {
            return new NameIterator();
        }

        private class NameIterator : Iterator
        {
            int index;

            public bool hasNext()
            {
                if (index < names.Length)
                {
                    return true;
                }
                return false;
            }

            public Object next()
            {
                if (this.hasNext())
                {
                    return names[index++];
                }
                return null;
            }
        }
    }
}
