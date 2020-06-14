using System;

namespace Tutorials_ThomsonReuters
{
    class Program
    {
        static void Main(string[] args)
        {
            // NOTE that namespaces organize your code. 
            // Helps you organize a collection related classes, interfaces, structs, enums, and delegates.
            // namespaces can also contain other namespaces
            //Console.Write("Enter your name: ");
            //string userName = Console.ReadLine();
            //Console.WriteLine("Hello {0}", userName); // placeholder syntax

            // using Visual Studio you can calculate the MIN and MAX value of a data type 
            //int i = 0;
            //Console.WriteLine("Min. value is: {0}", int.MinValue);
            //Console.WriteLine("Max. value is: {0}", int.MaxValue);

            // decimal has 128 bit data type with more precision than double 

            // ----------------------------------------------
            // ternary operator 
            //int number = 18;
            //bool canDrink = number >= 21 ? true : false;
            //Console.WriteLine("Can drink?: {0}", canDrink);

            // ----------------------------------------------
            // by default value types are not nullable
            // you can make them nullable with ?
            //string name = null;
            //int? i = null; // this makes it nullable, 
            // this is used in the case where you have a null form (optional input)
            // this also corresponds to storage in a database if the column accepts a value of null

            // ----------------------------------------------

            //int? TicketsOnSale = null;
            //int AvailableTickets;

            //if (TicketsOnSale == null)
            //{
            //    AvailableTickets = 0;
            //} 
            //else
            //{
            //    // conversion between nullable and non nullable can be by accessing .Value property 
            //    // could also cast with (int)TicketsOnSale;
            //    AvailableTickets = TicketsOnSale.Value;
            //}
            //Console.WriteLine("AvailableTickets: {0}", AvailableTickets);

            // ----------------------------------------------
            // instead can use the Null Coalescing operator 
            // and pass the default value to assign if TicketsOnSale is null
            //int? TicketsOnSale = null;
            //int AvailableTickets = TicketsOnSale ?? 0; 

            // ----------------------------------------------
            // implicit conversion is done automatically by compiler as long as no loss 
            // of information and no possibility of a thrown exception

            // 2 ways to do the explicit conversion 
            // * typecasting with (typeName) before the variable to cast
            // * use the Convert class 
            //float f = 123.45f;
            //int i = (int)f;

            //int n = Convert.ToInt32(f);
            // this would throw an exception if not possible
            // So the difference is that the typeclass, 
            // would overflow and not throw an exception 

            // with the Convert class,
            // would throw an exception if an overflow would occur 
            // so basically the Convert class is safer to use 

            // ----------------------------------------------

            // to convert a string 
            // have 2 options to perform a cast 
            // * dataType.Parse()
            //      will throw an exception if string can't be parsed to the specified data type 
            // * dataType.TryParse()
            //      will return a boolean whether it can successfully parse or nah
            //string str = "123";
            //int num = int.Parse(str);

            //int result = 0;
            // so in this case, the method will take the first param 
            // parse it from a string to an int and then store the result 
            // into the second param (utilizing the out keyword)
            // (the return type is actually boolean)
            //bool IsConversionSuccessful = int.TryParse(str, out result);

            //if (IsConversionSuccessful)
            //{
            //    Console.WriteLine("Result: {0}", result);
            //}
            //else
            //{
            //    Console.WriteLine("Not a valid number.");
            //}

            // ----------------------------------------------

            // using object initialization syntax with default values
            //int[] numbers = new int[4] { 1, 2, 3, 4 };

            // ----------------------------------------------
            /// XML documentation comments
            // which will be between <summary>
            // which will be shown in intellisence 

            // ----------------------------------------------

            //Console.Write("Please enter a number: ");
            //int userNumber = int.Parse(Console.ReadLine());
            //Console.WriteLine("User number: {0}", userNumber);

            // ----------------------------------------------

            //int number = 2;

            //// can combine case conditions 
            //switch (number)
            //{
            //    case 0:
            //    case 1:
            //    case 2:
            //        Console.WriteLine("Your number is {0}. Cool!", number);
            //        break;
            //    case 3:
            //        Console.WriteLine("Nope");
            //        break;
            //    default:
            //        Console.WriteLine("Cool story bro");
            //        break;
            //}

            // ----------------------------------------------

            // so this behaves like a Jump in assembly code 
            // create a label (a marker in the program that you can jump to)
            // Start:
            // goto Start;
            // AVOID doing this, as debugging is very complex
            // instead use loops

            // ----------------------------------------------

            // foreach
            //int[] numbers = new int[3] { 1, 2, 3 };
            //foreach (int num in numbers)
            //{
            //    Console.WriteLine("Num: {0}", num);
            //}

            // ----------------------------------------------

            // methods in C#
            // can use ref to make a parameter whose value is of the value type 
            // to act as a reference within a method 

            // use the out keyword to return multiple values 
            // public static void Calculate(int FN, int SN, out int Sum, out int Product)
            // {
            //      Sum = FN + SN;
            //      Product = FN * SN;
            // }

            // int Total = 0;
            // int Product = 0;
            // Calculate(10, 20, out Total, out Product);

            // parameter arrays 
            // usually decorated with the params keyword 
            // for a variable number of parameters to pass in 
            // so params keyword makes it optional to pass the argument
            // public static void ParamsMethod(params int[] Numbers)
            // {
            //      Console.WriteLine("There are {0} elements.", Numbers.Length);
            //      foreach (int num in Numbers)
            //      {
            //          Console.WriteLine(num);
            //      }
            // }
            // 
            // greatest benefit is that you can just pass values, separated by commas 
            // ParamsMethod(1, 2, 3, 4, 5);
            // NOTE: that the params array must be the last one specified in the parameter list 

            // ----------------------------------------------

            // namespaces help you organize your program 
            // consider different parts of your development team,
            // each write code to contribute to their respective namespaces 


            //ProjectA.TeamA.ClassA.Print();

            // or at the top could import it with 
            // using ProjectA.TeamA;
            // can now use the method as ...
            // ClassA.Print();

            // if you were to import two namespaces which had conflicting names 
            // such as both having the same class name within their namespaces
            // could further specify 
            // using PATA = ProjectA.TeamA;
            // using PATB = ProjectA.TeamB;

            // hover mouse over the class to tell from which namespace the class comes from 
            // some suggest using a fully qualitifed name
            // but others argue that it's too much typing
            // so there are advantages and disadvantages of both

            // so you can consider using namespace alias
            // there's less typing and the code is more readable
            // so it fits in the middle to remove abuiguity

            // namespaces don't correspond to file or assembly names 
            // code is compiled into an assembly
            // bin/debug/
            // there you see the .exe assembly (the compiled)

            // .dll 
            // IL Disassembler 
            // can open the file inside bin/ for the .dll file 


            // namespaces could be written in separate files and assemblies
            // and still belong to the same namespace 
            // such as through a project having 'Add Reference' to another 
            // for means of importing them 

            // namespaces can be nested in 2 ways 
            // alias directives
            // for having a shorter name for a long namespace

            // ----------------------------------------------

            // a class is a blueprint that enables you to encapsulate
            // data/state (represented by fields)
            // and behavior (represented by methods)

            //Customer c1 = new Customer("Steven", "Garcia");
            //c1.PrintFullName();

            // ----------------------------------------------

            // static vs instance members 

            //Circle c1 = new Circle(5);
            //float Area = c1.CalculateArea();
            //Console.WriteLine("Area = {0}", Area);

            //Circle.Print();

            // so static does help save some memory if you are making
            // many instances of a particular class 

            // ----------------------------------------------

            // inheritance
            // helps reduce code duplication 
            // so can abstract away into base class 

            // less code to test and less probability of errors
            // promoting reusability

            // single inheritance
            // base classes are instantiated before derived class 
            // parent class constructor is invoked
            // before child class constructors 

            // in child class constructor you can specify what 
            // parent constructor is called 
            // public ChildClassName() : base("message")
            // {
            // }

            // ----------------------------------------------

            // method hiding
            // in a derived class 
            // so this will hide a base class member,
            // utilizing the 'new' keyword

            // public new void MethodName()
            // {
            // }

            // to call the base class method
            // you can use the base keyword

            // public new void MethodName()
            // {
            //      base.MethodName();
            // }

            // the other way is to typecast,
            // for data type conversion 

            // ((BaseClass)ChildVarName).MethodName()

            // another way with different syntax
            // BaseClass myVar = new DerivedClass();
            // so the parent class is the reference variable,

            // ----------------------------------------------

            // polymorphism
            // overriding virtual methods

            // in base class 
            // must mark as virtual 
            // so you are telling all derived classes
            // that they can override the marked virtual method

            // public virtual void PrintFullName()
            // {
            //      Console.WriteLine("Name is ..");
            // }

            // in derived class 
            // public override void PrintFullName()
            // {
            //      Console.WriteLine("{0} {1} - Part time", FirstName, LastName);
            // }

            // so polymorphism essentially allows you to invoke derived class methods 
            // through base class variables at runtime
            // (many shapes)

            // ----------------------------------------------

            // difference between method overriding and method hiding 

            // at runtime, the overridden method will be invoked 
            // by a base class variable 
            // (virtual)

            // a base class will invoke the hidden method 
            // (new)

            // ----------------------------------------------

            // method overloading
            // means having a method of the same name within the same class 
            // you diffentiate it by having a different signature,
            // meaning different number and/or type of parameters
            // (also includes ref or out parameters which count as differentiated type)

            // you can't perform method overloading by just changing the return type

            // signature of a method includes the name of the method, the type,
            // and the kind (value, reference, or output)

            // signature method doesn't include the return type or the params modifier

            // ----------------------------------------------

            // why properties
            // it creates encapsulation so you can ensure that your 
            // class's state is always in a valid state 
            // through getters and setters

            // properties essentially are the public access with some 
            // abstracted logic used to assign a valid value to the private field (the state)

            // accessible through member notation,
            // written in PascalCase
            // underlying private instance member (field) is _camelCase

            // if (string.IsNullOrEmpty(Name))
            // {
            //      throw new Exception("Name cannot be null or empty.");
            // }
            // this._Name = Name;

            // ----------------------------------------------

            // properties in C#
            // public int Id { get; set; }

            // to make a readonly property 
            // will only have the get accessor and don't specify the set mutator

            // write only, if you only specify a set

            // the advantage is that you can access them as if they were public fields 
            // and you encapsulate the logic to ensure that they are 
            // always in a valid state 

            // auto implemented properties are used due to you not needing 
            // and logic for your getters and/or setters 
            // so compiler will create it for you (the private field and getter/setter)

            // ----------------------------------------------

            // structs 
            // just like classes, structs have 
            // * private fields 
            // * public properties 
            // * constructors
            // * methods 

            // can also use object initializer syntax

            /*
             public struct Customer 
             {
                private int _id;
                private string _name;

                public int ID
                {
                    get { return this._id; }
                    set { this._id = value; }
                }

                public string Name { get; set; }

                public Customer(int id, string name) 
                {
                    this.ID = id;
                    this.Name = name;
                }

                public void PrintDetails()
                {
                    Console.WriteLine("Id = {0} && Name = {1}", this.ID, this.Name);
                }
             }

            Only difference in terms of syntax is the struct keyword rather than the class keyword


              for structs, use the same syntax to initialize 

            Customer c1 = new Customer(101, "Mark");
            c1.PrintDetails();

            // new syntax for object initializer
            Customer c2 = new Customer() { Name = "Steven", ID = 2 };

             * 
             */

            // ----------------------------------------------

            // the difference between classes and structs
            // a struct is a value type, (stack and pass by copy)

            // whereas a class is a reference type (heap and pass by reference)
            // NOTE that the actual reference variable that holds the memory address is on the stack 

            // ----------------------------------------------

            // interfaces 

            // CANNOT contain fields 
            // and can only contain the signature of methods 

            // prefix with I as to tell that it's an interface and not a class 

            // public access modifiers by default
            // they cannot have fields
            // they could also contain properties, methods, delegates, or events
            // and don't allow access modifiers

            // public interface ICustomer 
            // {
            //      void Print();
            // }

            // the interface can be implemented by a class,
            // and a class allow multiple interface 'inheritance' at the same time
            // so can implement multiple interfaces

            // NOTE: interfaces can inherit from other interfaces,
            // and cannot create instances of an interface,
            // but an interface reference variable can refer to a derived class object

            // public class Customer : ICustomer 
            // {
            //       public void Print()
            //       {
            //       }
            // }

            // ----------------------------------------------

            // explicit interface implementation
            // when you are implementing multiple interfaces
            // and there are conflicting names,
            // such that each interface requires a method 
            // and those methods have the same method name 

            // compiler doesn't know which one you are calling 
            // need to expliclty cast through typecasting 

            // Program p = new Program();
            // assuming that Program implements 2 interfaces 

            // one of the interfaces is I2 for this example
            // and the example of the method name is InterfaceMethod
            // but not good syntax
            // ((I2)p).InterfaceMethod();


            // THROUGH using EXPLICIT interface implementation

            // you are not allowed to use the access modifier 
            // and 
            // have to use the interface name and then . the method name 

            // void I2.InterfaceMethod()
            // {
            // 
            // }
            // void I1.InterfaceMethod()
            // {
            //
            // }

            // NOTE: you cannot say 
            // p.InterfaceMethod();
            // there will be ambiguity, .NET will not allow 

            // the only way to invoke is through the use of the typecasting 
            // note that p is just an object reference variable 

            // ((I1)p).InterfaceMethod();

            // can also have a default implementation
            // p.IntefaceMethod();
            // without any casting 

            // implement that member normally,
            // and the other member with the same method name
            // that you don't want to be default,
            // then you just use the explicit implementation syntax

            // ----------------------------------------------

            // abstract classes

            // it's an incomplete class and can't be instantiated
            // it can contain abstract members 
            // through methods, propertiers, indexers, events, but not mandatory 

            // non abstract class derived from abstract class MUST provide implementations
            // for its abstract members 

            // abstract class can only be used as a base class 

            // see code below this main method 

            // NOTE: abstract class could also be used as the data type 
            // for the reference variable as long as it refers to a derived class on the heap 

            // NOTE: an abstract class cannot be sealed,
            // you can't prevent it from being inherited from another class 
            // it can only be used as a base class 

            // you can't do 
            // public abstract sealed class Customer 

            // sealed means that you can't use it as a base class (can't inherit)

            // however abstract means that it can only be used as a base class 

            // so they contradict

            // -
            // NOTE: that a class marked as abstract
            // could have all of its members implemented without the abstract keyword
            // and still be considered abstract

            // however it if has at least one abstract method,
            // then the entire class MUST be marked as abstract

            // ----------------------------------------------

            // the differences between abstract classes and interfaces
            // several similiarties,
            // as in they can't be instantiated,
            // and they are incomplete

            // both can only act as base types

            // important interview question

            // interfaces cannot have fields 
            // whereas abstract class can have fields 

            // abstract class can have method implementation for its non abstract members
            // whereas for interfaces, no implemention is allowed for its methods

            // a class can inherit from multiple interfaces at the same time,
            // whereas a class cannot inherit from multiple classes at the same time 

            // abstract class members can have access modifiers whereas  (and are private by default)
            // interface members cannot have access modifiers (and are public by default)

            // an interface can inherit from another interface,
            // and cannot inherit from an abstract class 
            // whereas an abstract class can inherit from another abstract class 
            // or another interface 

            // ----------------------------------------------

            // 34) problems of multiple class inheritance 

            // due to the Diamond problem 
            // based on the shape of the inheritance diagram
            // refering to the ambuiguity of which version
            // of the method should be invoked on the derived class 

            // you can a superclass A for example,
            // with two derived classes, class B and class C
            // then have a derived class D

            // A has a method defined in it, that class B and C inherit,
            // lets say that they both override that method,
            // then when D invokes that method (if it has no overriden implementation)
            // class D : B, C
            // {
            // 
            // }

            // D doesn't know which overriden version to invoke!

            // ----------------------------------------------

            // 35) multiple class inheritance using interfaces

            // ----------------------------------------------

            // 36) delegates in C#

            // complicated subject, but love to work with them once you understand
            // and the flexiblity it provides 

            // a delegate is A FUNCTION POINTER 
            // (it's a type safe function pointer)

            // delegates should be specified outside of a class

            // it points to a function and when you invoke the delegate 
            // it'll invoke the corresponding function that it points to 

            // public static void Hello(string message)
            // {
            //      Console.WriteLine(message);
            // }

            // the syntax to a delegate is similar to a function 

            // use the delegate keyword 
            // you specify the return type,              
            // a name for the delegate
            // and parameters

            // public delegate void HelloFunctionDelegate(string message);
            // it looks like a method signature 

            // it can be used to point to a function that has a 'matching' signature 
            // meaning its return type and parameters 

            // create an instance of the delegate in order to point to a function 
            // NOTE: in the constructor of the delegate you pass in the name of the function 
            // to which you want the delegate to point to 

            // HelloFunctionDelegate del = new HelloFunctionDelegate(Program.Hello);

            // and then to invoke 
            // del("Hello");

            // how is it type safe?
            // it's because you specify the return type 
            // the signature of the delegate should match 
            // the signature of the function that it points to.

            // Why use a delegate?
            // It provides us a lot of flexiblity in real-time projects.

            // It has similar syntax to a method except that it uses the delegate keyword before the return type.

            // ----------------------------------------------

            // 37) Delegate usage.

            // So delegates are useful because it allows us to extend functionality 
            // without needing to change or have access to the original implementation.

            // Developers can plug in their logic and can also pass a method as a parameter 
            // into another method as a 'callback' function. 

            // ----------------------------------------------

            // 38) Delegate usage continued.

            // Delegates are used by framework developers as they want it to be reusable.

            // So it enables us to pass a method as a parameter.

            // Delegates also help us reduce hardcoded logic, thus making our methods more reusable.

            // NOTE: Lambda expressions are based on delegates so you can
            // reduce the steps needed for the same functionality. 

            // Lambda expression example.
            // Which is an inline, anonymous method. 
            // Employee.PromoteEmployee(empList, emp => emp.Experience >= 5);

            // ----------------------------------------------

            // 39) Multicast Delegates.

            // A multicast delegate is one that has reference to more than one function.
            // When you invoke it, all the functions that it points to are invoked.

            // To register a method with the delegate can use the syntax of + or +=.
            // To unregister a method, use - or -=.

            // It invokes methods in the invocation list in the same order that they are added.

            // If the delegate has a non-void return type, then only the last value,
            // for the last method in its invocation list will return the value.
            // Likewise if a parameter is marked with the out keyword then its value 
            // will be assigned by the last method.

            // Interview Question:
            // Where do you use multicast delegates?
            // Multicast delegates makes the implementation of the observer design pattern very simple.
            // Observer pattern is also called publish/subscribe pattern.

            // To make a delegate a multicast delegate there are two ways.

            // SampleDelegate del = new SampleDelegate(SampleMethodOne);
            // del += SampleMethodTwo;
            // del += SampleMethodThree;
            // del(); // this will invoke all methods in its invocation list

            // ----------------------------------------------

            // 40) Exception Handling.

            // An exception is an unforseen error that occurs during runtime.

            // Don't show an unhandled exception to the user as it contains 
            // information for hackers and annoys users.

            // An exception is a class that derives from System.Exception class.
            // It's an object.
            // It has several useful properties that provide valuable information about the exception.

            // Message: Gets a message that describes the current exception.
            // StackTrace: Provides the call back to the line number in the method 
            // where the exception occurred.

            // using System.IO;

            //try
            // {
            // StreamReader streamReader = new StreamReader(@"C:\Sample Files\Data.txt");
            // Console.WriteLine(streamReader.ReadToEnd());
            // streamReader.Close();
            // }
            // catch (Exception ex)
            // {
            //   Console.WriteLine(ex.Message);
            //   Console.WriteLine(ex.StackTrace);
            // }

            // All exceptions inherit from the base Exception class which provides default functionality.
            // alt + ctrl + e
            // will show all the exceptions.

            // FileNotFoundException
            // .FileName 

            // So by using a more specific Exception class, you have access to more specific properties
            // that can help you solve and track down where the problem occurred.

            // You log the exception to a logging database for further adminstrative/debugging work 
            // or perhaps send an email of the error message
            // and then you print out a meaningful message to the user.

            // A practical application of inheritance is for Exceptions 
            // as it enables you to handle it with specificity
            // as to have more specific and useful properties that apply in that context.

            // The finally block is used to be executed even if an exception is to occur.
            // It is guaranteed to execute.
            // In that block you release resources.

            // Why do you need the finally block?
            // The reason is that it throw an exception within a catch block.
            // The finally block is guaranteed to execute even if another exception 
            // is thrown within a catch block.
            // The finally block is optional.

            // Specific exceptions should be defined before the general exception catch blocks.

            // ----------------------------------------------

            // 41) Inner Exceptions.

            // Consider try catch blocks used to handle Format exceptions
            // when dealing with user input.

            // StreamWriter has to do with the input and output of files.

            // Exception ex

            // Can find the type of the exception with, 
            // ex.GetType().Name;
            // our could use the .FullName 
            // which will also provide the namespace.

            // What if there is an exception within our catch block?
            // If you were to throw an exception within,
            // you would pass the exception that was caught in the catch(Exception ex)
            // parameter variable as the argument for the exception being thrown.
            // (As the 2nd arg)

            // Ex:
            // throw new FileNotFoundException(filePath + " is not present", ex);
            // So you pass it to the constructor.
            // This enables you to retain the original exception.

            // So you want to wrap the entire code in another try catch.
            // So you have an outer try catch
            // with the original try catch inside.

            // try 
            // {
            //      try
            //      {
            // ...

            // Running your code in debug mode enables you to find the line causing the error quicker.

            // from that outer catch block 
            // Console.WriteLine("Current Exception = ", exception.GetType().Name);


            // So any time you are trying to retrieve the inner exception, you must check that it exist first.

            // if (exception.InnerException != null)
            // {
            // Console.WriteLine("Inner Exception = ", exception.InnerException.GetType().Name);
            // }

            // Overview Notes

            // The InnerException property returns the Exception instance that caused the current exception.

            // To retain the original exception, pass it as a parameter to the constructor of the current exception.

            // Always check if inner exception is not null before accessing any property of 
            // the inner exception object, else you may get Null reference Exception.

            // To get the type of InnerException, use GetType() method.

            // ----------------------------------------------

            // 42) Custom Exceptions.

            // When do you usually create your own custom exceptions?
            // If none of the existing .NET exceptions describe the problem adequately.

            // Know that an exception is nothing but a class that inherits from a base exception class
            // or a derived class of the exception class.

            // public class UserAlreadyLoggedInException : Exception
            // {
            // provide a constructor
            //      public UserAlreadyLoggedInException() 
            //          : base()
            //      {
            //      }

            //      public UserAlreadyLoggedInException(string message) : base(message)
            //      {
            //          
            //      }
            // }

            // So inner exceptions allow us to track the original exception.

            // Must provide that overloaded constructor as to allow inner exceptions to be accessible
            // and to keep track of the original exception.

            // public class UserAlreadyLoggedInException : Exception
            // {
            // provide a constructor
            //      public UserAlreadyLoggedInException() 
            //          : base()
            //      {
            //      }

            //      public UserAlreadyLoggedInException(string message) : base(message)
            //      {
            //          
            //      }

            //      public UserAlreadyLoggedInException(string message, Exception innerException)
            //          : base(message, innerException)
            //      {
            //          
            //      }
            // }

            // NOTE: serialization is breaking down an object into packets that can be transmitted 
            // over the network.

            // To make it serializable.

            // You decorate the class.

            // using System.Runtime.Serialization;

            // [Serializable]
            // public class UserAlreadyLoggedInException : Exception
            // {
            //  ...
            //      public UserAlreadyLoggedInException(SerializationInfo info, StreamingContext context)
            //          : base(info, context)
            //      {
            //
            //      }


            // ----------------------------------------------

            // 43) Exception Handling Abuse.

            // Using exception handling to implement program logical flow is bad practice.

            // Exception handling is necessary for when executing a query and database connection is lost. For example.

            // So the below code has many places where an exception could be thrown for invalid input.

            // Instead of wrapping in a try catch block.

            //try
            //{
            //    Console.WriteLine("Please enter Numerator");
            //    int Numerator = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Please enter Denominator");
            //    int Denominator = Convert.ToInt32(Console.ReadLine());

            //    int result = Numerator / Denominator;

            //    Console.WriteLine("Result = {0}", result);
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine("Please enter a number" + e.Message);
            //}
            //catch (OverflowException e)
            //{
            //    Console.WriteLine("That number should be between the ranges of {0} and {1}.", int.MinValue, int.MaxValue);
            //}
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine("The denominator cannot be 0.");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            // We want to avoid the above as it becomes cumbersome having to provide 
            // catch blocks for each specific exception.
            // Rather want to do conditional checks at the point of the input to ensure that the state is valid 
            // and communicate with the user accordingly.

            // So notice here that we are deciding which message to display to the user 
            // based on what exception is thrown and therefor deciding the program control flow 
            // based on the exception thrown.

            // ----------------------------------------------

            // 44) Preventing exception handling abuse.
            // (DEFENSIVE PROGRAMMING)

            // Rewrite program without the exceptions occurring, we still provide the user messages.

            // So with this implementation, we are not allowing exceptions to occur and we are programmatically 
            // checking that the values are in the correct state.

            //try
            //{
            //    Console.WriteLine("Please enter Numerator");
            //    int Numerator;
            //    bool isNumeratorConversionSuccessful = Int32.TryParse(Console.ReadLine(), out Numerator);

            //    if (isNumeratorConversionSuccessful)
            //    {
            //        Console.WriteLine("Please enter Denominator");
            //        int Denominator;
            //        bool isDenominatorConversionSuccessful = Int32.TryParse(Console.ReadLine(), out Denominator);
            //        if (isDenominatorConversionSuccessful && Denominator != 0)
            //        {
            //            int result = Numerator / Denominator;

            //            Console.WriteLine("Result = {0}", result);
            //        }
            //        else
            //        {
            //            if (Denominator == 0)
            //            {
            //                Console.WriteLine("Denominator cannot be 0.");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Denominator must be an integer between the values of {0} and {1}", int.MinValue, int.MaxValue);
            //            }
            //        }
            //    } 
            //    else
            //    {
            //        Console.WriteLine("Numerator should be a valid number between {0} and {1}", int.MinValue, int.MaxValue);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            // ----------------------------------------------

            // 45) Why Enums.

            // An enum is a strongly typed constant.
            // Helps make the program become more readable and maintainable.

            // It's useful as it reduces the use of magic numbers which could be stored in the database
            // the need for a switch statement to determine what the implicit value of a magic number is.

            // The program becomes more unmaintainable due to you not knowing what the meaning of a magic number is.

            // Such as a Gender being set to 0.
            // Or Gender being set to 1.
            // What does that mean?
            // So enums also help remove ambuiguity by using meaningful names for a finite set of constants.

            // ----------------------------------------------

            // 46) Enums example.

            // See the code below the end of the Main method.

            // switch (gender)
            // {
            //      case Gender.Unknown:
            //          return "Unknown";
            //      case Gender.Male:
            //          return "Male";
            //      case Gender.Female:
            //          return "Female";
            //      default:
            //          return "idk";
            // }

            // For assignment.
            // Customer.Gender = Gender.Male;

            // Within System.IO namespace.
            // FileShare. 
            // To specify the share permissions, those are enums and it makes it easy to understand which 'mode' you want.

            // ----------------------------------------------

            // 47) Enums in C#.

            // Note that enums are enumerations.
            // The default underlying type of an enum is an int that begins at 0 and incremented by 1.
            // Enums are value types.
            // You can also customize the underlying type and values.

            // An explicit cast is needed when you want to convert from an Enum type to another.

            //int[] Values = (int[])Enum.GetValues(typeof(Gender));
            //foreach (int num in Values)
            //{
            //    Console.WriteLine(num);
            //}

            //string[] names = (string[])Enum.GetNames(typeof(Gender));
            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}

            // For your enum, you could also inherit from another value such to make it 
            // your underlying implicit value.
            // Such as.
            // public enum Gender : short
            // {
            // ..
            // }

            // So now the .GetValues method will represent the underlying data type of short.

            // You could also specify the default value such as.
            // Don't even need to specify for all of them as the run time will provide the others 
            // by incrementing from the initial value.

            //public enum Gender
            //{
            //    Unknown = 1,
            //    Male,
            //    Female
            //}

            // Could also do.

            //public enum Gender
            //{
            //    Unknown = 1,
            //    Male = 5,
            //    Female 23
            //}

            // Enums are called strongly typed constants.
            // Though the underlying type is an integer, you can't assign directly 
            // a value to an enum.
            // Can't assign an enum to a value.
            // You have to perform an explicit cast.

            // Gender gender = (Gender)3;

            // ----------------------------------------------

            // 48) Differences between Types and Type members.

            // So for example, Customer is the Type and 
            // fields, Properties and methods are type members.

            // So classes, structs, enums, interfaces, and delegates are called types.

            // And fields, properties, constructors, and methods that are within a type are type members.

            // In C# there are 5 access modifiers.
            // 1. Private 
            // 2. Protected
            // 3. Internal 
            // 4. Protected Internal 
            // 5. Public 

            // Type members can have all the access modifiers.
            // Types can only have 2 (internal, public) 

            // NOTE: using regions you can expand and collapse sections of your code manually 
            // or through visual studio with Edit -> Outlining -> Toggle All Outlining
            // This helps you organize your code.

            // So to do it manually 
            // you would do 

            // #region Fields
            // then 
            // #endregion

            // On left side, you can collapse (toggle) with the - or plus sign shown in the editor.

            // ----------------------------------------------

            // 49) Access Modifiers in C#.

            // Private members are only available within the containing type.
            // Public are accessible everywhere without restrictions.

            // Protected members are available where the containing type and to the types 
            // that derive from that containing type.

            // Within a derived class, you can do 
            // base.protectedMemberName 
            // or 
            // this.protectedMemberName



        }
    }
}

public enum Gender
{
    Unknown,
    Male,
    Female
}

abstract class User
{
    // they have abstract members,
    // through the use of the abstract keyword 

    // it could also contain a method with an implementation
    public void Print()
    {
        Console.WriteLine("Non abstract method");
    }


    // so once marked as an abstract method,
    // it cannot have an implementation
    // it's there for a derived class to provide implementation
    public abstract void MyAbstractMethod();
}

class Username : User
{
    public override void MyAbstractMethod()
    {
        Console.WriteLine("This is the implementation of MyAbstractMethod");
    }
}


class Circle
{

    // so can't refer to _PI from this keyword since it belongs to the class now,
    // and not the instance 
    public static float _PI;
    int _Radius;

    // to initialize a static field you could make use of a static constructor
    // (these don't allow access modifiers)
    // these are called before instance constructors are called
    // and they are used to organize your intialization of your static fields
    static Circle()
    {
        Circle._PI = 3.14F;
    }

    public Circle(int Radius)
    {
        this._Radius = Radius;
    }

    // if you were to not include the access modifier 
    // then by default it would be private
    public float CalculateArea()
    {
        return _PI * this._Radius * this._Radius;
    }

    public static void Print()
    {
        Console.WriteLine("The value of PI is {0}", _PI);
    }
}

class Customer
{
    string _firstName;
    string _lastName;

    // here we are passing in default values
    public Customer() : this("No FirstName Provided", "No LastName Provided")
    {

    }

    public Customer(string FirstName, string LastName)
    {
        this._firstName = FirstName;
        this._lastName = LastName;
    }

    public void PrintFullName()
    {
        Console.WriteLine("Full Name = {0} {1}", _firstName, _lastName);
    }

    // destructors don't take parameters, usually we don't
    // but they can be used to clean up as to clean up the resources 
    // that the class was holding onto during its lifetime
    // They are called automatically by the garbage collector.
    ~Customer()
    {
        // clean up code
    }
}

namespace ProjectA
{
    namespace TeamA
    {
        class ClassA
        {
            public static void Print()
            {
                Console.WriteLine("Team A Method");
            }
        }
    }
}
