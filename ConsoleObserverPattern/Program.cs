using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//观察者模式
namespace ConsoleObserverPattern
{
    public class Subject
    {
        private List<Observer> observers = new List<Observer>();
        private int state;

        public int getState()
        {
            return state;
        }

        public void setState(int state)
        {
            this.state = state;
            notifyAllObservers();
        }

        public void attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void notifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update();
            }
        }
    }

    public abstract class Observer
    {
        protected Subject subject;

        public abstract void update();
    }

    public class BinaryObserver : Observer
    {
        public BinaryObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            //Console.WriteLine("Binary String: " + Integer.toBinaryString(subject.getState()));
            Console.WriteLine("Binary String: " + Convert.ToString(subject.getState(), 2));
        }
    }

    public class OctalObserver : Observer
    {
        public OctalObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            //Console.WriteLine("Octal String: " + Integer.toOctalString(subject.getState()));
            Console.WriteLine("Octal String: " + Convert.ToString(subject.getState(), 8));
        }
    }

    public class HexaObserver : Observer
    {
        public HexaObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            //Console.WriteLine("Hex String: " + Integer.toHexString( subject.getState() ).toUpperCase() );
            Console.WriteLine("Hex String: " + Convert.ToString(subject.getState(), 16).ToUpper());
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Subject subject = new Subject();

            new HexaObserver(subject);
            new OctalObserver(subject);
            new BinaryObserver(subject);

            Console.WriteLine("First state change: 15");
            subject.setState(15);
            Console.WriteLine("Second state change: 10");
            subject.setState(10);

            Console.ReadKey();
        }
    }
}