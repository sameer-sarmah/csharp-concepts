using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.domain;

namespace csharp_concepts
{
    public class ExtensionMethodDemo
    {

        public void extension() {
            NumberWrapper five = new NumberWrapper(5);
            var result = 6.add(five);

        }
    }

    public static class NumberWrapperExt {

        public static int add(this int number,NumberWrapper numberWrapper) {
            return number + numberWrapper.GetValue();
        }

        public static int substract(this int number, NumberWrapper numberWrapper)
        {
            return number - numberWrapper.GetValue();
        }

        public static int multiply(this int number, NumberWrapper numberWrapper)
        {
            return number * numberWrapper.GetValue();
        }

        public static int divide(this int number, NumberWrapper numberWrapper)
        {
            if (numberWrapper.GetValue() > 0)
                return number + numberWrapper.GetValue();

            else throw new ArithmeticException("denominator can't be 0");
        }

    }
}
