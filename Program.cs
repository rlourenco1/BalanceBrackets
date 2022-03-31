using System;
using System.Collections.Generic;

namespace BalanceBrackets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Strings of brackets examples for testing:
            //string exp1 = "[()]{}{[()()]()}";
            //string exp2 = "(){}[]";
            //string exp3 = "[{()}](){}";
            //string exp4 = "[]{()";
            //string exp5 = "[{)]";

            Console.WriteLine("Enter your string of brackets... ");
            string exp = Console.ReadLine();

            // Function call
            if (AreBracketsBalanced(exp))
                Console.WriteLine("Balanced");
            else
                Console.WriteLine("Not Balanced");
        }

        public static bool AreBracketsBalanced(string exp)
        {
            Stack<Char> items = new Stack<Char>();

            foreach(char c in exp)
            {
                // Check if it is an opening bracket
                if (c == '(' || c == '[' || c == '{')
                {
                    //Console.WriteLine($"OPENING CHAR: {c}");

                    // Push the element in the stack
                    items.Push(c);
                }

                // If current character is not an opening bracket,
                // Stack cannot be empty or it isn't balanced already.
                if (items.Count == 0)
                    return false;

                // Check if it is a closing bracket
                if (c == ')' || c == ']' || c == '}')
                {
                    //Console.WriteLine($"CLOSING CHAR: {c}");

                    char lastItem = items.Pop();

                    switch (c)
                    {
                        case ')':
                            if(lastItem == '[' || lastItem == '{')
                                return false;
                            break;
                        case '}':
                            if (lastItem == '[' || lastItem == '(')
                                return false;
                            break;
                        case ']':
                            if (lastItem == '(' || lastItem == '{')
                                return false;
                            break;
                    }
                }

            }

            return items.Count == 0;
        }
    }
}
