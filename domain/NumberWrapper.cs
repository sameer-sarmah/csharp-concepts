using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts.domain
{
    public class NumberWrapper
    {
        private int number;
        private const int ZERO = 0;
        public NumberWrapper(int number)
        {
            this.number = number;
        }

        public int GetValue()
        {
            return this.number;
        }

        //method must be public and static.
        public static NumberWrapper operator +(NumberWrapper first, NumberWrapper second)
        {
            return new NumberWrapper(first.number + second.number);
        }

        public static NumberWrapper operator -(NumberWrapper first, NumberWrapper second)
        {
            return new NumberWrapper(first.number - second.number);
        }

        public static NumberWrapper operator *(NumberWrapper first, NumberWrapper second)
        {
            return new NumberWrapper(first.number * second.number);
        }

        public static NumberWrapper operator /(NumberWrapper first, NumberWrapper second)
        {
            if (second.number != 0)
            {
                return new NumberWrapper(first.number / second.number);
            }
            throw new ArithmeticException("denominator can't be 0");

        }

    }
}
