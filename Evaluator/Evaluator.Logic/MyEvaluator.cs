using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Logic
{
    public class MyEvaluator
    {
        public static double Evaluate(string infix)
        {
            var postfix = ToPostfix(infix);
            return Calculate(postfix);
        }

        private static double Calculate(string postfix)
        {
            throw new NotImplementedException();
        }

        private static string ToPostfix(string infix)
        {
            var stack = new Stack<char>(100);
            var posfix=string.Empty;

            for (int i = 0; i < infix.Length; i++)
            {
                if (IsOperator(infix[i]))
                {
                    if (stack.IsEmpty)
                    {
                        stack.Push(infix[i]);
                    }

                    else
                    {
                        if (infix[i] == ')')
                        {
                            do
                            {
                                posfix += stack.Pop();
                            }
                            while (stack.GetItemInTop() != '(');
                            stack.Pop();
                        }
                        else
                        {
                            if (PriorityInExpression(infix[i]) > PriorityInStack((stack.GetItemInTop())))
                            {
                                stack.Push(infix[i]);
                            }
                            else
                            {
                                posfix += stack.Pop();
                                stack.Push(infix[i]);
                            }
                        }
                    }
                }
                else
                {
                    posfix += infix[i];
                }
                while(!stack.IsEmpty)
                {
                    posfix += stack.Pop();
                }
                
            }
            return posfix;
        }


        private static bool IsOperator(char item)
        {
            if (item == '(' || item == ')' || item == '^' || item == '/' || item == '*' || item == '+' || item == '-')
            {
                return true;
            }
            return false;
        }

        private static int PriorityInExpression(char @operator)
        {
            switch (@operator)
            {
                case '^': return 4;
                case '*': return 2;
                case '/': return 2;
                case '+': return 1;
                case '-': return 1;
                case '(': return 5;
                default: throw new Exception("Not valid operator");
            }
        }

        private static int PriorityInStack(char @operator)
        {
            switch (@operator)
            {
                case '^': return 3;
                case '*': return 2;
                case '/': return 2;
                case '+': return 1;
                case '-': return 1;
                case '(': return 0;
                default: throw new Exception("Not valid operator");
            }
        }
    }
}
