using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class OperatorTreeParser
    {
        public static Operator Parse(string str)
        {
            str = Normalize(str);

            // If a number
            try { return new NumberOperator(double.Parse(str)); } catch { }

            int opIndex;

            // Plus or minus
            opIndex = LastIndexOfAnyWithZeroDepth(str, new char[] { '+', '-' });
            if (opIndex != -1)
            {
                return GetBinaryOperatorAtIndex(str, opIndex);
            }

            // Div or mul
            opIndex = LastIndexOfAnyWithZeroDepth(str, new char[] { '*', '/' });
            if (opIndex != -1)
            {
                return GetBinaryOperatorAtIndex(str, opIndex);
            }

            throw new ArgumentException("couldn't parse string");
        }
        private static int LastIndexOfAnyWithZeroDepth(string str, char[] chars)
        {
            int currentDepth = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                char ch = str[i];

                switch (ch)
                {
                    case ')':
                        currentDepth++;
                        break;
                    case '(':
                        currentDepth--;
                        break;
                }

                if (chars.Contains(ch) && currentDepth == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        private static string Normalize(string str)
        {
            str = str.Trim();
            int rightBracketsToAdd = str.Count((ch) => ch == '(') - str.Count((ch) => ch == ')');
            str += new string(')', rightBracketsToAdd);
            while (str.Length >= 2 && str[0] == '(' && str[^1] == ')')
            {
                str = str[1..^1];
            }
            return str;
        }
        private static Operator GetBinaryOperatorAtIndex(string str, int index)
        {
            if (index == -1)
            {
                throw new ArgumentException("invalid index");
            }
            char op = str[index];

            string op1Str = str[..index];
            string op2Str = str[(index + 1)..];

            Operator op1 = Parse(op1Str);
            Operator op2 = Parse(op2Str);

            switch (op)
            {
                case '+':
                    return new PlusOperator(op1, op2);
                case '-':
                    return new MinusOperator(op1, op2);
                case '*':
                    return new MulOperator(op1, op2);
                case '/':
                    return new DivOperator(op1, op2);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
