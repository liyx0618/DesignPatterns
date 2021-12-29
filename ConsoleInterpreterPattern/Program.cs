using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//解释器模式
namespace ConsoleInterpreterPattern
{
    /// <summary>
    /// 表示
    /// </summary>
    public interface Expression
    {
        /// <summary>
        /// 解释
        /// </summary>
        /// <param name="context">内容</param>
        /// <returns></returns>
        Boolean interpret(String context);
    }
    /// <summary>
    /// 最终表示
    /// </summary>
    public class TerminalExpression : Expression
    {
        private String data;

        public TerminalExpression(String data)
        {
            this.data = data;
        }

        public Boolean interpret(String context)
        {
            if (context.Contains(data))
            {
                return true;
            }
            return false;
        }
    }

    public class OrExpression : Expression
    {
        private Expression expr1 = null;
        private Expression expr2 = null;

        public OrExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public Boolean interpret(String context)
        {
            return expr1.interpret(context) || expr2.interpret(context);
        }
    }

    public class AndExpression : Expression
    {
        private Expression expr1 = null;
        private Expression expr2 = null;

        public AndExpression(Expression expr1, Expression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public Boolean interpret(String context)
        {
            return expr1.interpret(context) && expr2.interpret(context);
        }
    }

    internal class Program
    {
        //规则：Robert 和 John 是男性
        public static Expression getMaleExpression()
        {
            Expression robert = new TerminalExpression("Robert");
            Expression john = new TerminalExpression("John");
            return new OrExpression(robert, john);
        }

        //规则：Julie 是一个已婚的女性
        public static Expression getMarriedWomanExpression()
        {
            Expression julie = new TerminalExpression("Julie");
            Expression married = new TerminalExpression("Married");
            return new AndExpression(julie, married);
        }

        private static void Main(string[] args)
        {
            Expression isMale = getMaleExpression();
            Expression isMarriedWoman = getMarriedWomanExpression();

            Console.WriteLine("John is male? " + isMale.interpret("John"));
            Console.WriteLine("Julie is a married women? " + isMarriedWoman.interpret("Married Julie"));
            Console.ReadKey();
        }
    }
}