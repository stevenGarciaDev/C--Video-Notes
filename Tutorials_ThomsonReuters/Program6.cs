using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Tutorials_ThomsonReuters
{
    public delegate void SumOfNumbersCallback(int sumOfNumbers);


    public class Program6
    {
        public static void PrintSumOfNumbers(int sum)
        {
            Console.WriteLine("Sum of numbers = " + sum);
        }
        
        // video 93
        static int Total = 0;

        public static void Main(string[] args)
        {
            /* ---------------------
            91) Retrieving data from Thread function using callback method
            -------------------- */

            // Example
            // Please enter the target number 
            // 5 
            // Sum of numbers is 15

            // So 
            // Main thread retreives the target number from the user 
            // Main thread creates a child thread and pass the target number to the child thread.

            // The child thread computes the sum of numbers and then returns the sum to the Main
            // thread using callback functions.

            // The callback method prints the sum of numbers. 

            // Step 1: Create a callback delegate. The actual callback method signature should 
            // match with the signature of this delegate.

            // refer to MyNumber class in Program5.cs 

            Console.WriteLine("Please enter the target number");
            int target = Convert.ToInt32(Console.ReadLine());

             // so just pass the name of the function
            SumOfNumbersCallback callback = new SumOfNumbersCallback(PrintSumOfNumbers);

            MyNumber number = new MyNumber(target, callback);
            Thread T1 = new Thread(new ThreadStart(number.PrintSumOfNumbers));
            T1.Start();
        
            /* ---------------------
            92) Significance of Thread Join and Thread IsAlive functions
            -------------------- */

            // Thread.Join and Thread.IsAlive functions

            // Join blocks the current thread and makes it wait until the thread 
            // on which Join method is invoked completes.
            // Join method also has an overload where we can specify the timeout. 
            // If we don't specify the timeout the calling thread waits indefinitely,
            // until the thread on which Join() is invoked completes.
            // This overloaded Join(int millisecondsTimeout) method returns a boolean 
            // True if the thread has terminated otherwise false 

            // Join is particularly useful when we need to wait and collect a result from 
            // a thread execution or if we need to do some clean-up after the thread has completed.

            // IsAlive returns boolean. True if the thread is still executing otherwise false

            // View static function definitions at the end of the class 

            Console.WriteLine("Main started");

            // a worker thread
            Thread T2 = new Thread(Program6.Thread1Function);
            T2.Start();

            Thread T3 = new Thread(Program6.Thread2Function);
            T3.Start();

            Console.WriteLine("Main completed");

            // The order of the output 
            // will differ a bit every time it executes
            // The statements are not guarantee in any order 
            // which is the nature of multithreaded programming.

            // for example the output COULD BE 
            // Main started 
            // Thread1Function started 
            // Main completed 
            // Thread2Function started

            // So the Main function, we get one thread for free
            // then the Main thread creates two additional threads, T2 and T3

            // Once the Main thread creates the additional thread,
            // the Main thread will not wait for that thread to complete,
            // it will proceed to the next line 

            // Main thread doesn't wait, it proceeds 

            // Sometimes you may need to make the Main thread wait while 
            // worker threads are doing their work 
            // since you may want to collect the result from worker threads and 
            // based on that we want the main thread to do something.

            // That's when Join is useful 

             Console.WriteLine("Main started");

            // a worker thread
            Thread T4 = new Thread(Program6.Thread1Function);
            T4.Start();

            Thread T5 = new Thread(Program6.Thread2Function);
            T5.Start();

            // once this line is executed, the Main thread is going to suspend 
            // its execution and wait for T4 to return from its method 
            // and once it has completed its exeuction 
            T4.Join();
            Console.WriteLine("Thread1Function completed");

            // Main thread will wait until this thread completes its execution 
            T5.Join();
            Console.WriteLine("Thread2Function completed");

            // SO now with the above code which uses .Join()
            // you will always get the same output 
            // as we force the Main thread to wait. 
             
            Console.WriteLine("Main completed");

            //
            // There is another overload of the .Join() method where you can specify the timeout
            // you could pass the timeout in milliseconds for the time that you are willing to wait 
            // until the thread completes its execution 

            Thread T6 = new Thread(Program6.Thread1Function);
            if (T6.Join(1000))
            {
                Console.WriteLine("Thread1Function completed!");
            }
            else 
            {
                Console.WriteLine("Thread1Function has not completed in 1 second");
            }

            if (T6.IsAlive)
            {
                Console.WriteLine("Thread1Function is still processing");
            } 
            else 
            {
                Console.WriteLine("Thread1Function has completed execution");
            }

            // to check every 500 milliseconds

            for (int i = 1; i < 10; i++) 
            {
                 if (T6.IsAlive)
                {
                    Console.WriteLine("Thread1Function is still processing");
                    Thread.Sleep(500);
                } 
                else 
                {
                    Console.WriteLine("Thread1Function has completed execution");
                    break;
                }
            }

            /* ---------------------
            93) Protecting shared resources from concurrent access
            -------------------- */

            // What happens if shared resources are not protected from concurrent access 
            // in multithreaded programs?

            // The output or behavior of the program can become inconsistent if the shared 
            // resourcecs are not protected from concurrent access in multithreaded program.

            // This program is a single-threaded program. 
            // In the Main() method, AddOneMillion() method is called 3 times 
            // and it updates the total field correctly as expected 

            // so far this program is single threaded,
            // where a single thread is used to execeute all of this code
            // and protecting shared resources is not a concern 
            // and you always get the same output.
            AddOneMillion();
            AddOneMillion();
            AddOneMillion();
            Console.WriteLine("Total = " + Total);

            

            // now rewrite the program to use multiple threads 
            // Everytime we run the below program we get a different output.
            // The inconsistent output is because the Total field is a shared 
            // resource is not protected from concurrent access by multiple threads.
            // The operator ++ is not thread safe. 

            Thread thread1 = new Thread(Program6.AddOneMillion);
            Thread thread2 = new Thread(Program6.AddOneMillion);
            Thread thread3 = new Thread(Program6.AddOneMillion);

            thread1.Start();
            thread2.Start(); 
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Total = " + Total);


            // And how to protect shared resources from concurrent access.

            // There are several ways to fix this.

            // using Interlocked.Increment() method 
            // increments a specified variable and stores the result as an atomic operation 

            // Interlocked.Increment(ref Total);
            // instead of 
            // Total++;

            // Or with Locking:

            // shown below this class
            // so when we use lock,
            // only one thread at a time could enter that piece of code 

            Stopwatch stopwatch = Stopwatch.StartNew();
            Thread thread4 = new Thread(Program6.AddOneMillionLock);
            Thread thread5 = new Thread(Program6.AddOneMillionLock);
            Thread thread6 = new Thread(Program6.AddOneMillionLock);

            thread4.Start();
            thread5.Start(); 
            thread6.Start();

            thread4.Join();
            thread5.Join();
            thread6.Join();

            Console.WriteLine("Total = " + Total);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
            // A tick is a measurement of time, so 
            // one millisecond contains 10,000 ticks

            Console.WriteLine(TimeSpan.TicksPerHour);
            // for example, it has other useful methods

            // Which option is better?
            // From a performance perspective, using Interlocked class is better 
            // over using locking.
            // Locking locks out all the other threads except a single therad to read 
            // and increment the Total variable.
            // This will ensure that the Total variable is updated safely.
            // The downside is that since all the other threads are locked out,
            // there is a performance hit.

            // The interlocked class can be used with addition/subtraction
            // (increment, decrement, add, etc.) on an int or long field.
            // The Interlocked class has methods for incrementing,
            // decrementing, adding, and reading variables atomincally.

            // Anything other than that we will wil have to resort to locking.

            /* ---------------------
            94) Difference between Monitor and lock in C#
            -------------------- */

            // Both monitor class and lock provides a mechanism that synchronizes access 
            // to objects.
            // Lock is the shortcut for Monitor.Enter with try and finally.

            // see code below this class for example

            // They are equally valid.

            // for lock(_lock)
            // that code will acquire an exclusive lock 
            // and the same is the case for Monitor.Enter

            // in C# 4, it's implemented slightly differently 

            // as shown in function below this class 

            // So in short, lock is a shortcut and it's the option for basic usage.
            // If you need more congtrol to implement advanced multithreading solutions 
            // using TryEnter(), Wait(), Pulse(), and PulseAll() methods 
            // then the Monitor class is your option


            /* ---------------------
            95) Deadlock in a multithreaded program 
            -------------------- */

            // When a deadlock can occur.
            // Lets say we have 2 threads.
            // a) Thread 1
            // b) Thread 2

            // and 2 resources 
            // a) Resource 1
            // b) Resource 2

            // Thread 1 has already acquired a lock on Resource 1 and wants to acquire a lock on resource 2.
            // At the same time Thread 2 has already acquired a lock on Resource 2 and wants to acquire a 
            // lock on Resource 1.

            // Two threads never give up their locks, hence a deadlock.
            // They are waiting for each other.

            Console.WriteLine("Started");

            var accountA = new Account(101, 5000);
            var accountB = new Account(102, 3000);

            AccountManager accountManagerA = new AccountManager(accountA, accountB, 1000);
            Thread t10 = new Thread(accountManagerA.Transfer);
            t10.Name = "t10";

            AccountManager accountManagerB = new AccountManager(accountB, accountA, 2000);
            Thread t11 = new Thread(accountManagerB.Transfer);
            t11.Name = "t11";

            t10.Start();
            t11.Start();

            t10.Join();
            t11.Join();
            Console.WriteLine("Main completed");

            // The above code is going to deadlock!!
            // The Transfer methods are being executed on two different threads.
            // 2 different resources, and the lock is performed.

            // NOTE: Many modern computers have many processors 
            // which enable them to execute in parallel.
            // Enable multiple processes as to make your applications 
            // faster and more responsive.

            // A process is an instance of a program or an application.
            // So when you open/run an application, your operating system 
            // loads that application within a process.

            // A process contains an image of that application's code.
            // Your operating system can execute many processes at the same time.
            // You could also have concurrency within each application 
            // using threads.

            // A thread is a sequence of instructions.
            // A thread is "that thing which executes your code."


             /* ---------------------
            96) How to resolve a deadlock in a multithreaded program 
            -------------------- */

            // There are several techniques to avoid and resolve deadlocks.
            // 1) Acquiring locks in a specific defined order
            // 2) Mutex class 
            // 3) Monitor.TryEnter() method 

            // In this video, will discuss, acquiring locks in a specific defined order 
            // to resolve a deadlock.

            // We need to define a specific order. View the updated transfer method.

            // The possibility of having deadlocks is reduced.

            /* ---------------------
            97) Performance of a multithreaded program 
            -------------------- */

            // Performance when run on a single core/processor machine 
            // versus multi core/processor machine.

            // To find out how many processors you have on your machine.
            // 1) Using Task Manager 

            // 2) Use the following code in any .NET application.
            // Environment.ProcessorCount
            // Console.WriteLine("Processor count " + Environment.ProcessorCount);

            // 3) On the windows command prompt window, type the following 
            // echo %NUMBER_OF_PROCESSORS%

            // On a machine that has multiple processors. Multiple threads can execute 
            // application code in parallel on different cores. For example,
            // if there are two threads and two cores, then each thread would run on an 
            // individual core. This means, performance is better.

            // If two threads take 10 milli-seconds each to complete, then on a machine with 
            // 2 processors, the total time taken is 10 milli-seconds.

            // On a machine taht has a single processor, multiple threads execute, one after 
            // the other or wait until one thread finishes. 
            // It is not possible for a single processor system to execute multiple threads 
            // in parallel. Since the operating system switches between the threads so fast,
            // it just gives the illusion that the threads run in parallel.
            // On a single core/processor machine multiple threads can affect performance 
            // negatively as there is overhead involved with context switching.

            // If two threads take 10 milli-seconds each to complete, then on a machine with 1 
            // processor, the total time taken is
            // 20 milli-seconds + (Thread context switching time, if any)

            // using System.Diagnostics;

            // StopWatch stopWatch = new StopWatch.StartNew();
            // ....
            // stopWatch.Stop();
            // Console.WriteLine("Total milliseconds without multiple threads");

        
            /* ---------------------
            98) Anonymous methods in C#
            -------------------- */

            // An anonymous method is a method without a name.
            // They provide a way of creating delegate instances without having to 
            // write a separate method.

            // Step 1: Create a method whose signature matches 
            // with the signature of Predicate<Employee> delegate
            // private static bool FindEmplyee(Employee employee)
            // {
            //     return employee.ID == 102;
            // }

            // Step 2: Create an instance of Predicate<Employee> delegate and pass the 
            // method name as an argument to the delegate constructor.
            // Predicate<Employee> predicateEmployee = new Predicate<Employee>(FindEmployee);

            // Step 3: Now pass the delegate instance as the argument for Find() method
            // Employee employee = listEmployees.Find(XmlWriterTraceListener => predicateEmployee(x));
            // Console.WriteLine("ID = {0}, Name {1}", employee.ID, employee.Name);

            // Anonymous method is being passed as an argument to the Find() method
            // This anonymous method replaces the need for step 1, 2, and 3
            // employee = listEmployees.Find(delegate(Employee x) { return x.ID == 102; });
            // Console.WriteLine("ID = {0}, Name {1}", employee.ID, employee.Name);

            // Also used for subscribing for an event handler.
            // private void Form1_Load(object sender, EventArgs e)
            // {
            //     Button Button1 = new Button();
            //     Button1.Text = "Click Me";
            //     Button1.Click += new EventHandler(Button1_Click);
            //     this.Controls.Add(Button1);
            // }

            // void Button1_Click(object sender, EventArgs e)
            // {
            //     MessageBox.Show("Button Clicked");
            // }

            // Anonymous Method 
            // private void Form1_Load(object sender, EventArgs e)
            // {
            //     Button Button1 = new Button();
            //     Button1.Text = "Click Me";
            //     Button1.Click += delegate(object obj, EventArgs eventArgs)
            // {
            //     MessageBox.Show("Button Clicked");
            // }
            //     this.Controls.Add(Button1);
            // }

            /* ---------------------
            99) Lambda expression in C#
            -------------------- */

            // What are lambda expressions?
            // Anonymous methods and Lambda expressions are very similar. 
            // Anonymous methods were introduced in C# 2 and Lambda expressions in C# 3.

            // To find an employee with Id == 102, using anonymous method.
            //Employee employee = listEmployees.Find(Employee => Employee.ID == 102);

            // You can also explicitly specify the Input but not required.

            // You can also explicitly specify the input type but this is not required.
            //Employee employee = listEmployees.Find((Employee Emp) => Emp.ID == 102);

            // int count = listEmployees.Count(x => x.Name.StartsWith("M"));

            // => is called lambda expression and reads as GOES TO
            // Notice that with a lambda expression you don't have to use the delegate 
            // keyword explicitly. The parameter type is inferred.
            // Lambda expressions are more convenient to use than anonymous methods. 
            // Lambda expressions are particularly helpful for writing LINQ query expressions.\

            // In most of the cases, lambda expressions supersedes anonymous methods.
            // The only time you would prefer anonymous methods over lambdas,
            // is when we have to omit the parameter list when it's 
            // not use within the body.

            // Anonymous methods allow the parameter list to be omitted entirely when it's not 
            // used within the body, where as with lambda expressions this is not th ecase.

            // For example, with anonymous method, notice we have omitted the parameter list 
            // as we are not using them within the body.
            // Button1.Clilck += delegate
            // {
            //     MessageShow.Show("Button Clicked");
            // };

            // The above code can be rewritten using lambda expressions as show.
            // Notice that we cannot omit the parameter list.
            // Buttton1.Click += (eventSender, eventArgs) => 
            // {
            //     MessageBox.Show("Button Clicked");
            // };

            /* ---------------------
            100) Func delegate in C#
            -------------------- */

            // Purpose of Func<T, TResult> delegate in C#

            // In simple terms, Func<T, TResult> is just a generic delegate.
            // Depending on the requirement, the type parameters 
            // can be replaced with the corresponding type arguments.

            // For example,
            // Func<Employee, string> is a delegate that represents a function
            // expecting Employee object as an input parameter and returns a string.

            // public class Employee 
            // {
            //     public int ID { get; set; }

            //     public string Name { get; set; }
            // }

            // List<Employee> listEmployees = new List<Employee>()
            // {
            //     new Employee{ ID = 101, Name = "Mark"},
            //     new Employee{ ID = 102, Name = "John"},
            //     new Employee{ ID = 103, Name = "Mary"}
            // };

            // Func<Employee, string> selector = employee => "Name = " + employee.Name;
            // IEnumerable<string> names = listEmployees.Select(selector);

            // foreach (string name in names)
            // {
            //     Console.WriteLine(name);
            // }

            // lambda expressions can also be used to achieve the same thing 
            //IEnumerable<string> names  = listEmployees.Select(employee => "Name = " + employee.Name);

            // What is the difference between the Func delegate and lambda expression?
            // They're the same, just two different ways to do the same thing.
            // The lambda syntax is newer, more concise, and easy way to write.

            // What if I have to pass two or more input parameters?
            // There are 17 overloaded versions of Func.
            // Enables you to write a modern version of a delegate. (function pointer)
            // as a reference to refer to a function (and its signature).

            /* ---------------------
            101) Async and await in C#
            -------------------- */

            // For retrieving some data from a dependency such as the network,
            // or disk, that is going to have some latency.
            // We don't want the thread to have to wait and reduce performance by blocking.

            // Should still be able to interact with the application.

            // To make it responsive.
            // Task class, can think of it as a verb.
            // Decorate with 
            // private async void btnProcessFile(object sender, EventArgs e)
            // {
            //      Task<int> task = new Task<int>(CountCharacters);
            //      task.Start(); // so will execute the function asynchronously
            //      int count = await task; // wait for the task to return,
            //

            /* ---------------------
            102) C# wait for thread to finish without blocking
            -------------------- */

            // So could implement it using Threads.
            // however it would creating blocking.

            // Have to wait for the worker thread to finish.

            // To make the main thread wait to finish we have to call 
            // thread.Join();

            // It will now perform as expected.
            // We have introduced a problem which is blocking the UI.

            // The thread that is in control should be modifying its properties,
            // no other thread should be doing that.

            // The right way is to use the begin invoke method.
            // Action delegate 
            // Action action = () => { ...... }
            // this.BeginInvoke(action); // this ask the UI thread to execute asynchronusly
            
        }

        // For video #95 
        public class Account 
        {
            double _balance; int _id;
            
            public Account(int id, double balance)
            {
                _id = id;
                _balance = balance;
            }

            public int ID 
            {
                get { return _id; }
            }

            public void Withdraw(double amount)
            {
                _balance -= amount;
            }

            public void Deposit(double amount)
            {
                _balance += amount;
            }
        }

        // For video #95
        public class AccountManager 
        {
            Account _fromAccount; Account _toAccount; double _amountToTransfer;
            public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
            {
                _fromAccount = fromAccount;
                _toAccount = toAccount;
                _amountToTransfer = amountToTransfer;
            }

            // Implementation of the Transfer() method which produces a deadlock.
            // public void Transfer()
            // {
            //     Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {_fromAccount.ID.ToString()}.");
            //     lock(_fromAccount)
            //     {
            //         Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {_fromAccount.ID.ToString()}.");
            //         Console.WriteLine($"{Thread.CurrentThread.Name} suspended for 1 second.");
            //         Thread.Sleep(1000);
            //         Console.WriteLine($"{Thread.CurrentThread.Name} back in action and trying to acquire lock on {_toAccount.ID.ToString()}");
            //         lock (_toAccount)
            //         {
            //             // Due to previous line having a deadlock.
            //             Console.WriteLine("This code will not be executed");
            //             _fromAccount.Withdraw(_amountToTransfer);
            //             _toAccount.Deposit(_amountToTransfer);
            //         }
            //     }
            // }

            public void Transfer()
            {
                object _lock1, _lock2;
                if (_fromAccount.ID < _toAccount.ID)
                {
                    _lock1 = _fromAccount; _lock2 = _toAccount;
                }
                else 
                {
                    _lock1 = _toAccount; _lock2 = _fromAccount;
                }

                // Notice we are not hardcoding the resource to lock.
                // Rather are passing a reference to it.
                lock (_lock1)
                {
                    Thread.Sleep(1000);
                    lock (_lock2)
                    {
                        _fromAccount.Withdraw(_amountToTransfer);
                        _toAccount.Deposit(_amountToTransfer);
                    }
                }
            }
        }

        // for Video #92
        public static void Thread1Function()
        {   
            Console.WriteLine("Thread1Function started");
            Thread.Sleep(5000);
            Console.WriteLine("Thread1Function is about to return");
        }

        public static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started");
        }

        // for 93)
        public static void AddOneMillion()
        {
            for (int i = 1; i < 1000000; i++)
            {
                Total++;
            }
        }

        static object _lock = new object();

        public static void AddOneMillionLock()
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock(_lock)
                {
                    Total++;
                }
            }
        }

        // so the long form version of the above function is.
        public static void AddOneMillionLongVersion()
        {
            for (int i = 1; i < 1000000; i++)
            {
                Monitor.Enter(_lock);
                try 
                {
                    Total++;
                }
                finally 
                {
                    Monitor.Exit(_lock);
                }
            }
        }

        // in C# 4 
        public static void AddOneMillion4()
        {
            for (int i = 0; i < 1000000; i++)
            {
                bool lockTaken = false;

                Monitor.Enter(_lock, ref lockTaken);
                try 
                {
                    Total++;
                }
                finally 
                {
                    if (lockTaken)
                        Monitor.Exit(_lock);
                }
        }
        
    }

}
