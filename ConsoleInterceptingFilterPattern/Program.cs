using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//拦截过滤器模式
namespace ConsoleInterceptingFilterPattern
{
    public interface Filter
    {
        void execute(String request);
    }

    public class AuthenticationFilter : Filter
    {
        public void execute(String request)
        {
            Console.WriteLine("Authenticating request: " + request);
        }
    }

    public class DebugFilter : Filter
    {
        public void execute(String request)
        {
            Console.WriteLine("request log: " + request);
        }
    }

    public class Target
    {
        public void execute(String request)
        {
            Console.WriteLine("Executing request: " + request);
        }
    }

    public class FilterChain
    {
        private List<Filter> filters = new List<Filter>();
        private Target target;

        public void addFilter(Filter filter)
        {
            filters.Add(filter);
        }

        public void execute(String request)
        {
            foreach (Filter filter in filters)
            {
                filter.execute(request);
            }
            target.execute(request);
        }

        public void setTarget(Target target)
        {
            this.target = target;
        }
    }

    public class FilterManager
    {
        private FilterChain filterChain;

        public FilterManager(Target target)
        {
            filterChain = new FilterChain();
            filterChain.setTarget(target);
        }

        public void setFilter(Filter filter)
        {
            filterChain.addFilter(filter);
        }

        public void filterRequest(String request)
        {
            filterChain.execute(request);
        }
    }

    public class Client
    {
        private FilterManager filterManager;

        public void setFilterManager(FilterManager filterManager)
        {
            this.filterManager = filterManager;
        }

        public void sendRequest(String request)
        {
            filterManager.filterRequest(request);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            FilterManager filterManager = new FilterManager(new Target());
            filterManager.setFilter(new AuthenticationFilter());
            filterManager.setFilter(new DebugFilter());

            Client client = new Client();
            client.setFilterManager(filterManager);
            client.sendRequest("HOME");

            Console.ReadKey();
        }
    }
}