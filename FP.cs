using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts
{
    class FP
    {
        delegate void OnSuccess(Result<string> result);
        delegate void OnError(Exception exception);
        private class Result<T>
        {
            T value;
            public Result(T value)
            {
                this.value = value;
            }

            public T getValue()
            {
                return this.value;
            }
        }


        public static void functionalProg()
        {

            Func<int, string, Func<Tuple<int, string, string>>> method = (int errorCode, string exception) =>
             {
                 var desp = "Error encountered while processing request";
                 Func<Tuple<int, string, string>> innerFunct = () =>
                 {
                     return Tuple.Create(errorCode, exception, desp);
                 };
                 return innerFunct;
             };
            Func<Tuple<int, string, string>> methodRef = method.Invoke(404, "UnauthorisedException");
            Tuple<int, string, string> tuple = methodRef.Invoke();
            int errorCode = tuple.Item1;
            string exception = tuple.Item2;
            string desp = tuple.Item3;
            Console.WriteLine($"errorCode is {errorCode} ,exception is {errorCode},description is {desp}");

            void onSuccess(Result<string> result)
            {
                Console.WriteLine($"operation completed successfully, result is {result.getValue()}");
            }

            void onError(Exception exception)
            {
                Console.WriteLine($"operation failed, exception is {exception.Message}");
            }

            Func<bool> greaterThanFive = () => {
                var random = new Random();
                var val = random.Next(0, 10);
                return val > 5;
            };

            void performOperationWithLambda(Action<Result<string>> successCallback,Action<Exception> errorCallback) {
                if (greaterThanFive()) {
                    successCallback(new Result<string>("Functional programming paradigm"));
                }
                else {
                    onError(new Exception("unexpected error"));
                }
            }
            performOperationWithLambda(onSuccess, onError);

            void performOperationWithDelegate(OnSuccess successCallback,OnError onErrorCallback) {
                if (greaterThanFive())
                {
                    successCallback(new Result<string>("Functional programming paradigm"));
                }
                else
                {
                    onError(new Exception("unexpected error"));
                }
            }
            performOperationWithDelegate(onSuccess, onError);

        }
    }

}
