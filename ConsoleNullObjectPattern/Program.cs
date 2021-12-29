using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 空对象设计模式
/// </summary>
namespace ConsoleNullObjectPattern

    public abstract class AbstractCustomer
    {
        protected String name;

        public abstract Boolean isNil();

        public abstract String getName();
    }

    public class RealCustomer : AbstractCustomer
    {
        public RealCustomer(String name)
        {
            this.name = name;
        }

        public override String getName()
        {
            return name;
        }

        public override Boolean isNil()
        {
            return false;
        }
    }

    public class NullCustomer : AbstractCustomer
    {
        public override String getName()
        {
            return "Not Available in Customer Database";
        }

        public override Boolean isNil()
        {
            return true;
        }
    }

    public class CustomerFactory
    {
        public static String[] names = { "Rob", "Joe", "Julie" };

        public static AbstractCustomer getCustomer(String name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return new RealCustomer(name);
                }
            }
            return new NullCustomer();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            AbstractCustomer customer1 = CustomerFactory.getCustomer("Rob");
            AbstractCustomer customer2 = CustomerFactory.getCustomer("Bob");
            AbstractCustomer customer3 = CustomerFactory.getCustomer("Julie");
            AbstractCustomer customer4 = CustomerFactory.getCustomer("Laura");

            Console.WriteLine("Customers");
            Console.WriteLine(customer1.getName());
            Console.WriteLine(customer2.getName());
            Console.WriteLine(customer3.getName());
            Console.WriteLine(customer4.getName());

            Console.ReadKey();
        }
    }
}