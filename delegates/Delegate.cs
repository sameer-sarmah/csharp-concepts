using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace csharp_concepts.delegates
{
    public delegate int addReference(int num1, int num2);
    public delegate int binaryOpClosureReference();
    class Delegate
    {
        private int[] numbers;
        public Delegate(params int[] numbers) {
            this.numbers = numbers;
        }
        public static int add(int num1, int num2)
        {
            return num1 + num2;
        }

        private int add()
        {
            return this.numbers.OfType<int>().ToList().Aggregate((total,current)=> total+current);
        }

        //a delegate refers to a function
        public static void delegateDemo()
        {
            //addReference delegateInstance = add;
            addReference delegateInstance = new addReference(add);
            var result = delegateInstance.Invoke(2, 3);
            Console.WriteLine(delegateInstance.Method.Name);
            Console.WriteLine(delegateInstance.Target);
            Console.WriteLine(delegateInstance.GetType());
            Console.WriteLine($"{result}");
        }

        public binaryOpClosureReference getDelegateInstance()
        {
            binaryOpClosureReference delegateInstance = new binaryOpClosureReference(add);
            return delegateInstance;
        }

        public Func<int> getFunctionReference() {
            return this.add;
        }
    }

}
