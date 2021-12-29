using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//备忘录模式
namespace ConsoleMementoPattern
{
    /// <summary>
    /// 记忆碎片
    /// </summary>
    public class Memento
    {
        private String state;

        public Memento(String state)
        {
            this.state = state;
        }

        public String getState()
        {
            return state;
        }
    }
    /// <summary>
    /// 发起人
    /// </summary>
    public class Originator
    {
        private String state;

        public void setState(String state)
        {
            this.state = state;
        }

        public String getState()
        {
            return state;
        }

        public Memento saveStateToMemento()
        {
            return new Memento(state);
        }

        public void getStateFromMemento(Memento Memento)
        {
            state = Memento.getState();
        }
    }
    /// <summary>
    /// 守护者
    /// </summary>
    public class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();

        public void add(Memento state)
        {
            mementoList.Add(state);
        }

        public Memento get(int index)
        {
            return mementoList[index];
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();
            originator.setState("State #1");
            originator.setState("State #2");
            careTaker.add(originator.saveStateToMemento());
            originator.setState("State #3");
            careTaker.add(originator.saveStateToMemento());
            originator.setState("State #4");

            Console.WriteLine("Current State: " + originator.getState());
            originator.getStateFromMemento(careTaker.get(0));
            Console.WriteLine("First saved State: " + originator.getState());
            originator.getStateFromMemento(careTaker.get(1));
            Console.WriteLine("Second saved State: " + originator.getState());

            Console.ReadKey();
        }
    }
}