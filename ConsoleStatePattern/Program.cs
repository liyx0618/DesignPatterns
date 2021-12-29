using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//状态模式
namespace ConsoleStatePattern
{
    public interface State
    {
        void doAction(Context context);
    }

    public class StartState : State
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.setState(this);
        }

        public String toString()
        {
            return "Start State";
        }
    }

    public class StopState : State
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.setState(this);
        }

        public String toString()
        {
            return "Stop State";
        }
    }

    public class Context
    {
        private State state;

        public Context()
        {
            state = null;
        }

        public void setState(State state)
        {
            this.state = state;
        }

        public State getState()
        {
            return state;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Context context = new Context();

            StartState startState = new StartState();
            startState.doAction(context);

            Console.WriteLine(context.getState().ToString());

            StopState stopState = new StopState();
            stopState.doAction(context);

            Console.WriteLine(context.getState().ToString());

            Console.ReadKey();
        }
    }
}