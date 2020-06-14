using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // NOTE: any lambda expression can be converted to a delegate type
            // with a delegate being the types of its parameters and return type

            // if the lambda expression doesn't return a value then 
            // it can be one of the Action delegate types 

            // if it does return a value then it can be 
            // converted to one of the Func delegate types 

            //Func<int, int> square = x => x * x;
            //Console.WriteLine(square(5));

            // can be converted into expression tree types
            //System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            //Console.WriteLine(e);

            // lambda expressions are often utilized when using LINQ
            //int[] numbers = { 2, 3, 4, 5 };
            //var squaredNumbers = numbers.Select(x => x * x);
            //Console.WriteLine(string.Join(" ", squaredNumbers));

            // so there are expression lambdas (conditionals or computations that return a value)
            // and statement lambdas (a code block that is wrapped in { } )

            // a statement lambda
            //Action<string> greet = name =>
            //{
            //    string greeting = $"Hello {name}!";
            //    Console.WriteLine(greeting);
            //};
            //greet("World!");


            // can use lambdas in place for handling events 

            // ... reread this part 

            // lambda expressions and tuples
            // C# has built in support for tuples 
            // 
        }
    }
}
