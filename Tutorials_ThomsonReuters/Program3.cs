using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutorials_ThomsonReuters
{
    class Program3
    {
        public static void Main(string[] args)
        {
            // ---------------------------------
            // 61) Partial Classes 
            // ---------------------------------

            // Partial classes allow us to split a class into 2 or more files.
            // All these parts are then combined into a single class, when the application 
            // is compiled.
            // The partial keyword can also be used to split a struct or an interface over two or more files.

            // Advantages of partial classes
            // 1) The main advantage is that visual studio uses partial classes to separate automatically
            // generated system code from the developer's code.

            // 2) When working on large projects, spreading a class over separate files allows multiple 
            // programmers to work on it simultaneously. (not really used in practice for this purpose though)

            // public class Customer 
            // {

            // }

            // So when splitting, you need to use the partial keyword 
            // public partial class PartialCustomer
            // {

            // }

            // ---------------------------------
            // 62) Creating Partial Classes 
            // ---------------------------------

            // The rules to keep in mind. It's important that you use the partial keyword 
            // so that the system will know your intention.

            // 1. All the parts spread across different files, must use the partial keyword.
            // 2. All the parts are spread across different files, must have the same access modifiers.

            // 3. If any of the parts are declared abstract, then the entire type is considered abstract.
            // 4. If any of the parts are declared as sealed, then the entire type is considered sealed.

            // 5. If any of the parts inherit a class, then the entire type inherits the class.
            // 6. C# does not support multiple class inheritance.
            //  So different parts of the partial class must not specify different base classes.

            // 7. Different parts of the partial class can specify different base interfaces, and 
            //  the final type implements all the interfaces listed by all the partial declarations.

            // 8. Any members that are decelared in a partial definition are available to all 
            // of the other parts of the partial class.

            // so for both of the files, would have the class be 
            // public partial class SamplePartialClass
            // {
            // }

            // to make it an abstract class, 
            // you would need to make this for both
            // public abstract partial class SamplePartialClass
            // {
            // }

            // At compile time, the partial classes will be merged together and it will form 
            // one class. (One file)

            // public partial class SamplePartialClass : Sample
            // { 
            // }
            // So you only need to mark one class and it will automatically
            // be inherited in any other partial class even if it doesn't 
            // say so explicitly.


            // ---------------------------------
            // 63) Partial Methods 
            // ---------------------------------

            // The rules to follow when creating partial methods.

            // 1. A partial class or a struct can contain partial methods.

            // 2. A partial method is created using the partial keyword.
            // 3. A partial method declaration consists of two parts.
            // i) The definition (only the method signature)
            // ii) The implementation
            // These may be in separate parts of a partial class or in the same part.

            // 4. The implementation for a partial method is optional.
            // If we don't provide the implementation, the compiler removes the signature and 
            // all calls to the method.

            // 5. Partial methods are private by default, and it is a compile time error to 
            // include any access modifiers, including private.

            // 6. It is a compile time error, to include declaration and implementation 
            // at the same time for a partial method.

            // 7. A partial method and return type must be void. 
            // Including any other return type is a compile time error.

            // 8. Signature of the partial method declaration must match with the signature 
            // of the implementation.

            // 9. A partial method must be declared within a partial class or a partial struct.
            // A non partial class or struct cannot include partial methods.

            // 10. A partial method can be implemented only once. Trying to implement a partial 
            // method more than once, raises a compile time error.

            // PartialClassFileOne SPC = new PartialClassFileOne();
            // SPC.PublicMethod();

            // So the compiler will ignore the signature and the invocation to partial methods.
            // So partial methods are basically 'optional' methods.

            // NOTE: that a partial method can't have ANY access modifiers.

            // ---------------------------------
            // 64) How and where are indexers used in C#  
            // ---------------------------------

            // Indexers are used to store or retrieve data from session state 
            // or application state variables such as in ASP.NET.

            // when you hover over the object, the intellisence will tell you 
            // that there is an indexer (potentially multiple overloaded ones).

            // It enables you to save something within the object utilizing the 
            // syntax of for example.

            // Session["Session1"] = "Session 1 data";
            // Session["Session2"] = "Session 2 Data";

            // You can also retrieve data with the indexer syntax.
            // Here we also use string interpolation.
            // Response.Write($"Session 1 Data = {Session[0].ToString()}<br />");
            // Response.Write($"Session 2 Data = {Session["Session2"].ToString()}");

            // NOTE:
            // You define an indexer utilizing the this keyword.
            // Ex:

            // public object this[int index] { get; set; }
            // public object this[string name] { get; set; }

            // So another example of indexer usage in .NET is to retrieve data from a specific 
            // column when looping through "SqlDataReader" object, we can use either the integral
            // indexer or string indexer.

            // NOTE: Look into ADO.NET for SQL and .NET framework.

            // So just know that there are many built in classes in the .NET framework 
            // that utilize indexers.

            // In summary:
            // Indexers allow instances of a class to be indexed just like arrays.

            // ---------------------------------
            // 65) Indexers in C# 
            // ---------------------------------

            // Points to remember:
            // 1. Use "this" keyworkd to create an indexer.
            // 2. Just like properties indexers have get and set accessors.
            // 3. Indexers can also be overloaded.

            // var company = new Company();
            // company[1] = "Joey";
            // Console.WriteLine(company[1]);

            // ---------------------------------
            // 66) Overloading indexers in C#  
            // ---------------------------------

            // Indexers are overloaded based on the number and type of parameters.

            // See code below.

            // ---------------------------------
            // 67) Optional parameters in C# 
            // ---------------------------------

            // There are different ways to make method parameters optional.
            // (This is a common interview question).

            // There are 4 ways that can be used to make method parameters optional.
            // 1. Use parameter arrays.
            // 2. Method overloading.
            // 3. Specify parameter defaults.
            // 4. Use OptionalAttribute that is present in System.Runtime.InteropServices namespace.

            // NOTE: A parameter array must be the last parameter in a formal parameter list.
            // Ex:
            // public static void AddNumbers(int firstNum, int secondNum, params object[] restOfNumbers)
            // {
            //      int sum = firstNum + secondNum;
            //      foreach (int i in restOfNumbers)
            //      {
            //          result += 1; 
            //      }
            //      Console.WriteLine("Total = " + result.ToString());
            // }

            // AddNumbers(10, 20);
            // AddNumbers(10, 20, 30, 40);

            // ---------------------------------
            // 68) Making method parameters optional using method overloading
            // ---------------------------------

            // Ex:
            // public static void AddNumbers(int firstNumbers, int secondNumber)
            // {
            //      AddNumbers(firstNumber, secondNumber, new int[] { });
            //}

            // public static void AddNumbers(int firstNumber, int secondNumber, int[] restOfNumbers)
            // {
            // ....
            // }

            // This is pretty basic. 
            // Basically it means using an overloaded method with a different parameter list.
            // Note that this may not be the most scalable as you have to overload 
            // to account for each new parameter variable.

            // ---------------------------------
            // 69) Making method parameters optional by specifying parameter defaults
            // ---------------------------------

            // So provide default parameters such that not all are mandatory.

            // Ex:
            // public static void AddNumbers(int firstNumber, int secondNumber, int[] restOfNumbers = null)
            // {
            //  ...
            //}

            // NOTE: Optional parameters must appear after all required parameters.

            // ---------------------------------
            // 70) Making method parameters optional by using OptionalAttribute
            // ---------------------------------

            // OptionalAttribute is present in System.Runtime.InteropServices namespace

            // public static void AddNumbers(int firstNumber, int secondNumber, [Optional] int[] restOfTheNumbers)
            // {
            //     int sum = firstNumber + secondNumber;
            //     if (restOfTheNumbers != null)
            //     {
            //         foreach (int i in restOfNumbers)
            //         {
            //             sum += i;
            //         }
            //     }

            //     Console.WriteLine($"Total = {sum.ToString()}");
            // }




        }

        public static void AddNumbers(int firstNumber, int secondNumber, params object[] restOfNumbers)
        {
            int sum = firstNumber + secondNumber;
            if (restOfNumbers != null)
            {
                foreach (int i in restOfNumbers)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Total = {sum.ToString()}");
        }


    }

    public partial class PartialClassFileOne
    {
        // so just the definition of the method (only the signature).
        // You could also provide the implementation in the same class (the body)
        // BUT you cannot do so at the same time.
        partial void SamplePartialMethod();

        // partial void SamplePartialMethod() 
        // {
        //     Console.WriteLine("SamplePartialMethod invoked!");
        // }

        public void PublicMethod()
        {
            Console.WriteLine("Public method invoked.");
            SamplePartialMethod();
        }
    }

    public partial class PartialClassFileOne
    {
        partial void SamplePartialMethod()
        {
            Console.WriteLine("SamplePartialMethod invoked!");
        }
    }

    public class CompanyEmployee
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }
    }

    public class Company
    {
        private List<CompanyEmployee> listEmployees;

        public Company()
        {
            listEmployees = new List<CompanyEmployee>();
            // in reality, you would get the data from a database.
            listEmployees.Add(new CompanyEmployee() { EmployeeId = 1, Name = "Steven", Gender = "Male" });
            listEmployees.Add(new CompanyEmployee() { EmployeeId = 2, Name = "Joe", Gender = "Male" });
            listEmployees.Add(new CompanyEmployee() { EmployeeId = 3, Name = "Jewel", Gender = "Female" });
        }

        // Given an EmployeeId, it will return the name.
        public string this[int employeeId]
        {
            get
            {
                // utilize LINQ
                return listEmployees.FirstOrDefault(emp => emp.EmployeeId == employeeId).Name;
            }
            set
            {
                listEmployees.FirstOrDefault(emp => emp.EmployeeId == employeeId).Name = value;
            }
        }

        // An overloaded indexer.
        // To retrieve the number of employees for each gender.
        public string this[string gender]
        {
            get
            {
                // utilize LINQ
                return listEmployees.Count(emp => emp.Gender == gender).ToString();
            }
            set
            {
                foreach (CompanyEmployee employee in listEmployees)
                {
                    if (employee.Gender == gender)
                    {
                        employee.Gender = gender;
                    }
                }
            }
        }
    }

}