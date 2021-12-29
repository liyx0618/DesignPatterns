using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//模板模式
namespace ConsoleTemplatePattern
{
    public abstract class Game
    {
         protected abstract void initialize();

         protected abstract void startPlay();

         protected abstract void endPlay();

        //模板
        public void play()
        {
            //初始化游戏
            initialize();

            //开始游戏
            startPlay();

            //结束游戏
            endPlay();
        }
    }

    public class Cricket : Game
    {
        protected override void endPlay()
        {
            Console.WriteLine("Cricket Game Finished!");
        }

        protected override void initialize()
        {
            Console.WriteLine("Cricket Game Initialized! Start playing.");
        }

        protected override void startPlay()
        {
            Console.WriteLine("Cricket Game Started. Enjoy the game!");
        }
    }

    public class Football : Game
    {
        protected override void endPlay()
        {
            Console.WriteLine("Football Game Finished!");
        }

        protected override void initialize()
        {
            Console.WriteLine("Football Game Initialized! Start playing.");
        }

        protected override void startPlay()
        {
            Console.WriteLine("Football Game Started. Enjoy the game!");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Cricket();
            game.play();
            Console.WriteLine();
            game = new Football();
            game.play();
            Console.ReadKey();
        }
    }
}