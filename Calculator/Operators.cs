using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class Operator
    {
        public abstract double Calculate();
        public abstract string Repr();
    }
    public abstract class UnaryOperator : Operator
    {
        protected readonly Operator op;
        public UnaryOperator(Operator op)
        {
            this.op = op;
        }
    }
    public abstract class BinaryOperator : Operator
    {
        protected readonly Operator op1;
        protected readonly Operator op2;
        protected readonly string operatorStr;
        public BinaryOperator(Operator op1, Operator op2, string operatorStr)
        {
            this.op1 = op1;
            this.op2 = op2;
            this.operatorStr = operatorStr;
        }

        public override string Repr()
        {
            return $"{op1.Repr()} {operatorStr} {op2.Repr()}";
        }
    }
    public class NumberOperator : Operator
    {
        private double number;
        public NumberOperator(double number)
        {
            this.number = number;
        }
        public override double Calculate()
        {
            return this.number;
        }

        public override string Repr()
        {
            return $"{this.number}";
        }
    }
    public class PlusOperator : BinaryOperator
    {
        public PlusOperator(Operator op1, Operator op2) : base(op1, op2, "+") { }
        public override double Calculate()
        {
            return op1.Calculate() + op2.Calculate();
        }
    }
    public class MinusOperator : BinaryOperator
    {
        public MinusOperator(Operator op1, Operator op2) : base(op1, op2, "-") { }
        public override double Calculate()
        {
            return op1.Calculate() - op2.Calculate();
        }
    }
    public class MulOperator : BinaryOperator
    {
        public MulOperator(Operator op1, Operator op2) : base(op1, op2, "*") { }
        public override double Calculate()
        {
            return op1.Calculate() * op2.Calculate();
        }
    }
    public class DivOperator : BinaryOperator
    {
        public DivOperator(Operator op1, Operator op2) : base(op1, op2, "/") { }
        public override double Calculate()
        {
            return op1.Calculate() / op2.Calculate();
        }
    }
}
