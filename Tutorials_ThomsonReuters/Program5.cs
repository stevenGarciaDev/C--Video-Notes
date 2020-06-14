using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tutorials_ThomsonReuters
{
    public class Program5
    {
        public static void Main(string[] args)
        {
            /* ---------------------
            80) Some useful methods of List collection class
            ---------------------- */

            // TrueForAll() 
            // Returns true or false depending on whether every element in the list matches the 
            // conditions defined by the specified predicate 

            // AsReadOnly()
            // Returns a read-only wrapper for the current collection.
            // Use this method if you don't want the client code to modify the collection 
            // so no adding or removing from the collection
            // The ReadOnlyCollection will not have methods to add or remove items from the collection 
            // you can only read items from this collection

            // TrimExcess()
            // Sets the capacity to the actual number of elements in the list,
            // if that number is less than a threshold value 
            // NOTE:
            // This method can be used to minimize a collection's memory overhead if no new elements 
            // will be added to the collection. The cost of reallocating and copying a large List<T>
            // can be considerable. So the TrimExcess method does nothing if the list is at more than 90 
            // percent of capacity. This avoids incurring a large reallocation cost for a relatively 
            // small gain.  The current threshold is 90 percent, but this could change in the future. 

            List<NewCustomer> listCustomers = new List<NewCustomer>() 
            {
                new NewCustomer() { ID = 1, Name = "Steven", Salary = 52000 },
                new NewCustomer() { ID = 1, Name = "Joe", Salary = 65000 },
                new NewCustomer() { ID = 1, Name = "Tony", Salary = 88000 }
            };

            Console.WriteLine(listCustomers.TrueForAll(x => x.Salary > 5000));

            ReadOnlyCollection<NewCustomer> readOnlyListCustomers = listCustomers.AsReadOnly();
            foreach (NewCustomer customer in readOnlyListCustomers)
            {
                Console.WriteLine($"{customer.Name}");
            }
            Console.WriteLine("First employee in the collection is {0}", readOnlyListCustomers[0].Name);

            Console.WriteLine("Capacity before trimming = " + listCustomers.Capacity);
            listCustomers.TrimExcess(); // So now this instance of List<> has a fixed size 
            Console.WriteLine("Capacity after trimming = " + listCustomers.Capacity);

            // So the .TrimExcess() method is beneficial for saving memory if you know that you are not going 
            // to be adding any new elements to the specific List<> instance

            /* ---------------------
            81) When to use a dictionary over list in C#
            ---------------------- */

            // Find() method of the List class loops through each object in the list until a match is found.
            // So if you want to lookup a value using a key dictionary is better for performance over list.
            // So use dictionary when you know the collection will be primarily used for lookups.

            Country country1 = new Country() { Code = "USA", Name = "UNITED STATES", Capital = "Washington D.C." };
            Country country2 = new Country() { Code = "IND", Name = "INDIA", Capital = "New Delhi" };
            Country country3 = new Country() { Code = "CAN", Name = "CANADA", Capital = "Ottawa" };

            List<Country> listCountries = new List<Country>()
            {
                country1,
                country2,
                country3
            };

            string strUserChoice = string.Empty;
            do {
                Console.WriteLine("Please enter country code");
                string strCountryCode = Console.ReadLine().ToUpper();

                Country resultCountry = listCountries.Find(country => country.Code == strCountryCode);

                if (resultCountry == null)
                {
                    Console.WriteLine("Country code not valid");
                }
                else 
                {
                    Console.WriteLine("Name = {0}, Capital = {1}", resultCountry.Name, resultCountry.Capital);
                }

                do {
                    Console.WriteLine("Do you want to continue? (Y or N)");
                    strUserChoice = Console.ReadLine().ToUpper();
                } while (strUserChoice != "Y" || strUserChoice != "N");

            } while (strUserChoice == "Y");

            // So for the above code, the data structure of List is not most efficient 
            // as we are utilizing that data structure primarily for the use of retrieval.
            // Therefore since we would already know the 'key' using the dictionary would allow us 
            // to retrieve the value we want in O(1) time. (lookups)
            // As compared to O(n) time for the List.

            Dictionary<string, Country> countriesTable = new Dictionary<string, Country>();
            countriesTable.Add(country1.Code, country1);
            countriesTable.Add(country2.Code, country2);
            countriesTable.Add(country3.Code, country3);

            do 
            {
                Console.WriteLine("Please enter country code");
                string countryCodeInput = Console.ReadLine().ToUpper();

                // Need to check if a key is within a dictionary otherwise 
                // .NET will throw an exception.
                if (countriesTable.ContainsKey(countryCodeInput))
                {
                    var resultCountry = countriesTable[countryCodeInput];
                    Console.WriteLine("Name = {0}, Capital = {1}", resultCountry.Name, resultCountry.Capital);
                }
                else 
                {
                     Console.WriteLine("Country code not valid");
                }

                do {
                    Console.WriteLine("Do you want to continue? (Y or N)");
                    strUserChoice = Console.ReadLine().ToUpper();
                } while (strUserChoice != "Y" || strUserChoice != "N");
            } while (strUserChoice == "Y");

            /* ---------------------
            82) Generic queue collection class 
            ---------------------- */
            // Queue is a generic FIFO (first in, first out) collection class 
            // that is found in the System.Collections.Generic namespace.
            // The first one to be added (enqueued) to the queue,
            // will also be the first item to be removed (dequeued).

            // To add items to the end, use Enqueue()

            // To remove at item that is at the beginning use Dequeue()

            // A foreach loop iterates through the queue, but will not remove it 
            // from the queue.

            // To check if an item exists, use Contains()

            // Peek() can be used to return the item at the beginning of the queue,
            // without removing it.

            NewCustomer customer3 = new NewCustomer() { ID = 3, Name = "Dan", Salary = 72000 };

            Queue<NewCustomer> queueCustomers = new Queue<NewCustomer>();
            queueCustomers.Enqueue(new NewCustomer() { ID = 1, Name = "Steven", Salary = 52000 });
            queueCustomers.Enqueue(new NewCustomer() { ID = 2, Name = "Joe", Salary = 90000 });
            queueCustomers.Enqueue(customer3);
            queueCustomers.Enqueue(new NewCustomer() { ID = 4, Name = "Tony", Salary = 65000 });

            NewCustomer firstCustomer = queueCustomers.Dequeue();
            Console.WriteLine($"The first customer is {firstCustomer.Name}");
            Console.WriteLine($"Total items in the Queue = {queueCustomers.Count}");

            foreach (NewCustomer c in queueCustomers)
            {
                Console.WriteLine($"ID = {c.ID}, Name = {c.Name}");
            }

            // To get the item at the beginning of the queue without removing it.

            firstCustomer = queueCustomers.Peek();
            Console.WriteLine($"ID = {firstCustomer.ID}, Name = {firstCustomer.Name}");

            if (queueCustomers.Contains(customer3))
            {
                Console.WriteLine("Customer 3 is in the queue.");
            }
            else 
            {
                Console.WriteLine("The customer does not exist in the queue.");
            }



            /* ---------------------
            83) Generic stack collection class
            ---------------------- */

            // Stack is a generic LIFO (last in, first out) collection class that is present 
            // in System.Colllections.Generic namespace.
            // Think of it as a stack of plates.
            // The last item is added (pushed) to the stack,
            // and will be the first item to be removed (popped) from the stack.

            // To insert an item at the top of the stack, use Push().

            // To remove and return the item at the top of the stack, use Pop()

            // A foreach loop iterates through the items in the stack, but it will not remove 
            // them from the stack. 
            // The last element added to the stack is the first one to be returned.

            // To check if an item exists in the stack use Contains()

            // Peek() returns the item at the top of the stack without removing it.

            Stack<NewCustomer> stackCustomers = new Stack<NewCustomer>();
            stackCustomers.Push(new NewCustomer() { ID = 1, Name = "Steven", Salary = 52000 });
            stackCustomers.Push(new NewCustomer() { ID = 2, Name = "Joe", Salary = 90000 });
            stackCustomers.Push(customer3);
            stackCustomers.Push(new NewCustomer() { ID = 4, Name = "Tony", Salary = 65000 });

            NewCustomer customerOnStack = stackCustomers.Pop();
            Console.WriteLine($"First on stack is {customerOnStack.Name}");

            Console.WriteLine($"The amount of customers on the stack is {stackCustomers.Count}");

            foreach (NewCustomer current in stackCustomers)
            {
                Console.WriteLine($"The current customer on the stack is {current.Name}.");
            }

            Console.WriteLine($"Retrieve item on top without removing it: {stackCustomers.Peek()}");

            if (stackCustomers.Contains(customer3))
            {
                Console.WriteLine("Yes customer 3 is in the stack.");
            }
            else 
            {
                Console.WriteLine("No customer 3 is not in the stack.");
            }

            /* ---------------------
            84) Real time example of queue collection class in C#
            ---------------------- */



             /* ---------------------
            85) Real time example of stack collection class in C#
            ---------------------- */

            /* ---------------------
            86) Multithreading in C#
            ---------------------- */

            // What is a process?
            // A process is what the operating system uses to facilitate the execution of a program
            // by providing the resources required. Each process has a unique process id
            // associated with it. You can view the process within which a program is being 
            // executing using windows task manager.

            // What is a thread?
            // A thread is a light weight process. A process has at least one thread which is 
            // commonly called as main thread which actually executes the application code. 
            // A single process can have multiple threads.

            // NOTE: All the threading related classes are present in System.Threading namespace.

            // So pass in a function name
            //Thread workerThread = new Thread(DoTimeConsumingWork);
            // So here we create a new thread such that the UI of the application remains responsive.
            // workerThread will start execution will begin with 
            // workerThread.Start();

            // So the job is offloaded to the thread.
            // So the benefit of multithreading is that it can make your application more responsive,
            // as you can offload the work of time consuming functions.

            /* ---------------------
            87) Advantages and disadvantages of multithreading
            ---------------------- */

            // Advantages of multithreading:
            // 1. To maintain a responsive user interface.
            // 2. To make efficient use of processor time while waiting for I/O operations to complete.
            // 3. To split large, CPU-bound tasks to be processed simultaneously on a machine that has 
            // multiple processors/cores.
            // Multithreaded applications can improve the performance by taking advantages of multiple processors/cores 
            // ability to have multiple threads.

            // Disadvantages of multithreading:
            // 1. On a single processor/core machine threading can affect performance negatively as there is overhead involved 
            // with context-switching.
            // As the processor must allocate its time equally amongst its threads. Also time involved to switch between threads.
            // 2. Have to write more lines of code to accomplish the same task.
            // 3. Multitheading applications are difficult to write, understand, debug, and maintain.

            // NOTE: Only use multithreading when the advantages of doing so outweigh the disadvantages.

            /* ---------------------
            88) ThreadStart delegate
            ---------------------- */

            // To create a THREAD, create an instance of Thread class and to it's constructor,
            // pass the name of the function that we want the thread to execute.

            Thread T1 = new Thread(Number.PrintNumbers);
            T1.Start();

            // Now rewrite it using ThreadStart delegate 

            // There are 4 overloaded version of the Thread constructor,
            // One option is a ThreadStart delegate 

            // A delegate is a type-safe function pointer.
            // The signature of the function which the delegate point to should match 
            // the signature of the delegate otherwise you will get a compile error.

            Thread T2 = new Thread(new ThreadStart(Number.PrintNumbers));

            // Why does a delegate need to be passed as a parameter to the Thread class constructor?
            // The purpose of creating a Thread is to execute a function. A delegate is a type safe function pointer,
            // meaning that it points to a function that the thread has to execute.
            // In short, all threads require an entry point to start execution. Any thread you create will 
            // need an explicitly defined entry point i.e. a pointer to the function where they should 
            // begin execution. 
            // So threads always require a delegate.

            // In the code showed above in the example where we just do 
            // new Thread(Number.PrintNumbers)
            // It's working in spite of not creating the ThreadStart delegate explicitly because the 
            // framework is doing it automatically for us.

            // You could also rewrite the same line using delegate() keyword
            Thread t3 = new Thread(delegate() { Number.PrintNumbers(); });

            // The same line written using lambda expression 
            Thread t4 = new Thread(() => Number.PrintNumbers());

            // Thread functions do not need to be static functions always.
            // It can also be a non-static function. In the case of a non-static 
            // function we have to create an instance of the class.

            Number number = new Number();
            Thread t5 = new Thread(number.DisplayNumbers);

            /* ---------------------
            89) ParameterizedThreadStart delegate
            ---------------------- */

            // Use ParameterizedThreadStart delegate to pass data to the thread function.

            Console.WriteLine("Plesae enter the target number");
            object target = Console.ReadLine();

            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(Number.OutputNumbers);
            Thread t6 = new Thread(parameterizedThreadStart);
            t6.Start(target);

            // Could also be written as...
            Console.WriteLine("Please enter the target number");
            object setTarget = Console.ReadLine();

            Thread t7 = new Thread(Number.OutputNumbers);
            t7.Start(setTarget);

            // Here we are not explicitly creating an instance of ParameterizedThreadStart 
            // delegate. Then how is it working?

            // It's working because the compiler implicitly converts
            // new Thread(Number.PrintNumbers);
            // to 
            // new Thread(new ParameterizedThreadStart(Number.PrintNumbers));

            // When to use ParameterizedThreadStart over ThreadStart delegate?
            // Use parameterizedThreadStart delegate if you have some data to pass to the 
            // Thread function. Otherwise just use ThreadStart delegate.

            // NOTE: Using ParameterizedThreadStart delegate and Thread.Start(Object)
            // method to pass data to the thread function is not type safe as they operate 
            // on object datatype and any type of data can be passed.

            // If you try to change the data type of the target parameter of OutputNumbers() function 
            // from object to int, a compiler error will be raised as the signature of OutputNumbers()
            // function does not match with the signature of 
            // ParameterizedThreadStart delegate.


            /* ---------------------
            90) Passing data to the Thread function in a type safe manner
            ---------------------- */

            // To pass data to the Thread function in a type safe manner,
            // encapsulate the thread function and the data it needs in a helper class 
            // and use the ThreadStart delegate to execute the thread functino.

            Console.WriteLine("Please enter the target number");
            int target8 = Convert.ToInt32(Console.ReadLine());

            MyNumber myNumber = new MyNumber(target8);
            Thread t8 = new Thread(new ThreadStart(myNumber.PrintNumbers));
            t8.Start();


        }
    }

    public class Country
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Capital { get; set; }
    }

    public class NewCustomer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }
    }

    public class Number 
    {
        public static void PrintNumbers()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        public void DisplayNumbers()
        {
            for (int i = 0; i < 10; i++) 
            {
                Console.WriteLine(i);
            }
        }

        public static void OutputNumbers(object target)
        {
            int number = 0;
            if (int.TryParse(target.ToString(), out number))
            {
                for (int i = 1; i <= number; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }

    class MyNumber
    {
        private int _target;
        SumOfNumbersCallback _callBackMethod;

        public MyNumber(int target, SumOfNumbersCallback callBackMethod)
        {
            this._target = target;
            this._callBackMethod = callBackMethod;
        }

        public void PrintNumbers()
        {
            for (int i = 1; i < _target; i++)
            {
                Console.WriteLine(i);
            }
        }

        public void PrintSumOfNumbers()
        {
            int sum = 0;
            for (int i = 1; i < _target; i++)
            {
                sum += i;
            }

            if (_callBackMethod != null)
            {
                _callBackMethod(sum);
            }
        }
    }

    
}