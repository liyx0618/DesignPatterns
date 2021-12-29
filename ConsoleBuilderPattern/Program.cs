using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//建造者模式
namespace ConsoleBuilderPattern
{
    /// <summary>
    /// 包装
    /// </summary>
    public interface Packing
    {
        String pack();
    }

    public interface Item
    {
        String name();

        Packing packing();

        float price();
    }

    /// <summary>
    /// 包装器
    /// </summary>
    public class Wrapper : Packing
    {
        public String pack()
        {
            return "Wrapper";
        }
    }

    /// <summary>
    /// 瓶
    /// </summary>
    public class Bottle : Packing
    {
        public String pack()
        {
            return "Bottle";
        }
    }

    /// <summary>
    /// 汉堡
    /// </summary>
    public abstract class Burger : Item
    {
        public Packing packing()
        {
            return new Wrapper();
        }

        public abstract float price();

        public abstract String name();
    }

    /// <summary>
    /// 冷饮抽象类
    /// </summary>
    public abstract class ColdDrink : Item
    {
        public Packing packing()
        {
            return new Bottle();
        }

        public abstract float price();
        public abstract String name();
    }

    /// <summary>
    /// 蔬菜汉堡
    /// </summary>
    public class VegBurger : Burger
    {
        public override float price()
        {
            return 25.0f;
        }

        public override String name()
        {
            return "Veg Burger";
        }
    }

    /// <summary>
    /// 鸡肉汉堡
    /// </summary>
    public class ChickenBurger : Burger
    {
        public override float price()
        {
            return 50.5f;
        }

        public override String name()
        {
            return "Chicken Burger";
        }
    }

    /// <summary>
    /// 碳酸冷饮
    /// </summary>
    public class Coke : ColdDrink
    {
        public override float price()
        {
            return 30.0f;
        }

        public override String name()
        {
            return "Coke";
        }
    }

    /// <summary>
    /// 百事可乐
    /// </summary>
    public class Pepsi : ColdDrink
    {
        public override float price()
        {
            return 35.0f;
        }

        public override String name()
        {
            return "Pepsi";
        }
    }

    /// <summary>
    /// 膳食
    /// </summary>
    public class Meal
    {
        private List<Item> items = new List<Item>();

        public void addItem(Item item)
        {
            items.Add(item);
        }

        public float getCost()
        {
            float cost = 0.0f;
            foreach (Item item in items)
            {
                cost += item.price();
            }
            return cost;
        }

        public void showItems()
        {
            foreach (Item item in items)
            {
                Console.WriteLine("Item : " + item.name());
                Console.WriteLine(", Packing : " + item.packing().pack());
                Console.WriteLine(", Price : " + item.price());
            }
        }
    }

    /// <summary>
    /// 膳食生成器
    /// </summary>
    public class MealBuilder
    {
        public Meal prepareVegMeal()
        {
            Meal meal = new Meal();
            meal.addItem(new VegBurger());
            meal.addItem(new Coke());
            return meal;
        }

        public Meal prepareNonVegMeal()
        {
            Meal meal = new Meal();
            meal.addItem(new ChickenBurger());
            meal.addItem(new Pepsi());
            return meal;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.prepareVegMeal();
            Console.WriteLine("Veg Meal");
            vegMeal.showItems();
            Console.WriteLine("Total Cost: " + vegMeal.getCost());

            Meal nonVegMeal = mealBuilder.prepareNonVegMeal();
            Console.WriteLine("\n\nNon-Veg Meal");
            nonVegMeal.showItems();
            Console.WriteLine("Total Cost: " + nonVegMeal.getCost());

            Console.ReadKey();
        }
    }
}