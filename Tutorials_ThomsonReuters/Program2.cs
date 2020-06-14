using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials_ThomsonReuters
{
    class Program2
    {
        public static void output()
        {
            // -----------------------------
            // 50) Internal and Protected Internal Access Modifiers 

            // The internal acceess modifier is accessible anywhere in the containing assembly.

            // Protected internal is available anywhere in the containing assembly,
            // and from within a derived class in any other assembly.

            // In .NET, when you compile a project, an assembly is generated.
            // The assembilies are of types executables and DLLs.
            // Usually a console app generates a windows.exe 
            // A web application, a class library, etc. generates a .dll 

            // A project corresponds to an assembly.
            // Right Click on project, open in file explorer, bin directory, debug,
            // There you will see the ProjectName.exe 
            // For a console application.

            // The assembly contains the intermediate language of your project's source code.
            // classes, methods, structures, etc. will be compiled into intermediate language.

            // If you have different assembliies, means you have to have multiple projects.
            // Right click, Add, New Project, class library (for example)

            //public class AssemblyOneClass
            //{
            //    internal int ID = 101;
            //}

            // So that member, ID, is available through that assembly.
            // It's accessible to the classes within that assembly.

            // So when in another assembly and want to use code in another assembly DLL.
            // You have to set the reference.
            // Right click on reference, Add reference,
            // On Projects tab, select.

            // Also need to import it with the using directive.

            // using AssemblyOne;

            // So that class has an internal member that we want to access outside 
            // in an assembly that has referenced and successfully imported the class.

            // NOTE: You are not allowed to access that member outside of the assembly
            // where it is defined.

            // Will get a compiler error if try to access outside.

            // Protected internal is a combination of protected and internal.

            // Protected is accessible within the base and derived classes.

            // Anywhere in the containing assembly and from within a derived class 
            // in ANY OTHER ASSEMBLY.

            // Meaning that it can serve as a base class for classes in other assembalies 
            // who derive from the containing class.

            // -----------------------------
            // 51) Access Modifiers for types

            // Can only use internal and public access modifiers for types.

            // When marked as public, you need to add a reference to the assembly.
            // Import the directive and then you can use that class to instantiate an object.

            // If you mark a type as internal, then that class is only accessible from within 
            // the assembly that it was created it.

            // If you don't explicitly mark an access modifier for the type, then the default will be internal.

            // If you don't specify an access modifier for a type member, will be private.

            // -----------------------------
            // 52) Attributes in C#

            // Attributes allow you add declarative information to your programs which can then 
            // be queries at runtime using reflection.

            //Calculator.Add(10, 20);
            // But if you wanted to add three numbers, the method will not be useful.
            // You would need to add another overloaded version.

            // The requirements change over time and users want to add more numbers.
            // You could specify a List

            // using System.Collections.Generic

            // NOTE: That you will have to leave your old implementations there for backwards compatability
            // even though you have added an updated method to handle it in a more 'scalable' way. (Modular)

            // You want to tell them to use the 'new' implementation and signify that it has been 'depracated'
            // but still available.

            // So in this case you would use an attribute.
            // It would signify a warning, essentially, in the compiler window.

            // So you decorate with the [Obsolete] attribute just before the method.
            // So you are adding some declarative information.

            // Visual Studio checks it, and it generates compiler warnings and errors.

            // The attribute allows you to add to your methods, types, properties, classes, etc.

            // All you need to do is specify just before its declaration.

            // You can actually customize it to provide more useful information through the use of overloaded constructors.
            // You can right click and go to the definition for more information and see under the hood.

            // They are a class that inherit from the base Attribute class.
            // So pass in a message. When you hover mouse over it in the source code.
            // There will be a popup with that message that you specified! 

            //[Obsolete("Use Add<List<int> Numbers) Method")]

            // NOTE: you could also use ObsoleteAttribute
            // the suffix of Attribute is optional

            // A few pre-defined attributes within the .NET framework.

            // WebMethod -> to expose a method as an XML web service method

            // Serializable -> to indicate that a class can be serialized.

            // You can customize the Obsolete class more.
            // You could pass in a second parameter, if using that method should produce an error.
            // A boolean parameter value.

            // -----------------------------
            // 53) Reflection in C#

            // When you build a solution,
            // the classes are compiled into intermediate lanaguage and packaged into an assembly.

            // An assembly consist of two parts
            // 1) The intermediate language 
            // 2) The meta data 

            // The Meta Data contains information about the types within the class and assembly.

            // It contains information regarding what are the members within a class.
            // Including constructors and methods, etc.

            // Reflection is taking the assembly and inspecting it to find 
            // how many classes are contained in the assembly, how many enums, structs,
            // and for each class what are the different members do they each have.

            // It's inspecting an assemblies contents by analyzing its metadata.

            // How is it useful?
            // One practical is in a Windows application.
            // When drag and drop a button, we know that a Button is a class.
            // You have the button class, and continue clicking 'Go to definition'.

            // So when compile, all the information about the properties and methods 
            // is also compiled into the assembly in the form of metadata.

            // Right click, go to properties window.
            // Now they are dynamically displayed on the right side of the IDE.

            // Reflection is used to inspect the assembly and pull out that information.

            // Used by IDE developers.

            // Late binding for example. You might not have knowledge of the class 
            // that you are instantiating at runtime.
            // Maybe don't have the assembly available, and don't have any knowledge.
            // You have to create an instance at runtime dynamically. (late binding)

            // One way to achieve late binding is with reflection
            // where at runtime, you check an assembly (load it dynamically)
            // the class that I am looking for, does it exist in that assembly 
            // if yes then create an instance and invoke methods needed.

            // So when you use the new keyword to explicitly invoke a class, that is an example of early binding.

            // So in summary, late binding is creating an instance of a class at runtime rather than at compile time.

            // If you were to write a function that can output a classes' type members, you would use reflection
            // to accomplish that.

            // Centered around the type class which is provided in System namespace 
            // Type 


            // so the parameter expects the fully qualified type name including the namespace.
            // Type T = Type.GetType("Tutorials_ThomsonReuters.Program2");
            // So GetType() will get the type of the class.

            // The Type datatype can be used with its built in methods 
            // to find information that we are looking for regarding 
            // the type members of the class that we are operating on.

            // It returns an Array of PropertyInfo objects
            // using System.Reflection;

            // PropertyInfo[] properties = T.GetProperties();
            // The Type data type provides many built in functionality.

            // foreach(PropertyInfo property in properties)
            // {
            //      Console.WriteLine("Name: {0}, and Property Type: {1}", property.Name, property.PropertyType.Name);
            // }

            // Now for the fully qualified type including the namespace.
            // Console.WriteLine("Full Name = {0}", T.FullName); 

            // For just the name of the class.
            // Console.WriteLine("Name of class = {0}", T.Name);

            // For just the name of the namespace.
            // Console.WriteLine("Name of the namespace = {0}", T.Namespace);

            // To get the methods.
            // MethodInfo[] methods = T.GetMethods();
            // foreach(MethodInfo method in methods)
            // {
            //      Console.WriteLine("The return type is {0}, and the name of the method is {1}", method.ReturnType.Name, method.Name);
            // }

            // NOTE that every class directly or indirectly inherits from System.Object
            // as to have some default methods.

            // ConstructorInfo[] constructors = T.GetConstructors();
            // foreach(ConstructorInfo constructor in constructors)
            // {
            //      Console.WriteLine(constructor.ToString());
            // }

            // Type T = typeof(Customer);
            // you pass the class name as the argument.

            // All objects have the .GetType() method which they inherit from System.Object

            // -----------------------------
            // 54) Reflection Example 



            // -----------------------------
            // 55) Late binding using reflection

            // It's very rare that you would use late binding.

            // It is done when you don't know the class at compile time that you are instantiating.

            // You want to invoke the class at runtime despite not knowing what it is.

            // You have to load the assembly which contains the class.
            // Assembly executingAssembly = Assembly.GetExectuingAssembly();
            // Within that assembly we have the classes.

            // We load and instantiate it dynamically at runtime.
            // Type specifiedClassName = executingAssembly.GetType("NamespaceName.ClassName");

            // object classNameInstance = Activator.CreateInstance(customerType);

            // MethodInfo getInstanceMethodName = specifiedClassName.GetMethod("InstanceMethodName");

            // Have to create the parameters as well.

            // string[] parameters = new string[2];
            // parameters[0] = "Steven";
            // parameters[1] = "Garcia";

            // So to invoke a method, you need the instance of the class and the associated parameters.
            // in this case lets say that the return type of the method is a string
            // string returnTypeValue = (string)getInstanceMethodName.Invoke(classNameInstance, parameters);

            // Console.WriteLine(returnTypeValue);

            // So it can compile but may throw an exception at runtime if the class is not found.
            // Also there are performance issues with late binding due to you needing
            // to load an assembly and create an instance at runtime.
            // Late binding is much slower than early binding.

            // In Late binding you won't know the errors until you run your application.


            // -----------------------------
            // 56) Generics in C#

            // Generics allow us to design classes and methods decoupled from the data types.

            // It's brittle when a method only works for a specific data type in some cases 
            // when that same logic and interface can be used for other data types.

            // Allowing code reuse with any data type

            // NOTE: converting value types to reference types are known as boxing
            // For example, you could specify the data type for a parameter variable to be of object data type.
            // So if you pass a value data type it'll be implicitly boxed for you.
            // But the performance is degraded.

            // Also the method loses its strongly typed.

            // So we make use of generics which is the best way to make a method independent of the data type
            // through the use of generics.

            // Refer to code below Main method for the Customer AreEqual Generic implemention

            // bool Equal = Calculator.AreEqual<string>("AB", "BA");
            // bool EqualNumbers = Calculator.AreEqual<int>(10, 7);

            // Generics are extensibly used in the Collection classes which are provided in System.Collections.Generic 

            // You could also make classes generic.
            // meaning that all the methods are going to operate on the type.

            // Instead of specifying <T> for each method 
            // you specify it on the class instead.

            // public class Calculator<T>

            // ...
            // public static bool AreEqual(T Value1, T Value2)
            // {
            // ....

            // You could also make interfaces generic, delegates

            // -----------------------------
            // 57) Why you should override ToString method

            // .Equals()
            // .GetType()
            // .ToString()
            // .GetHashCode()

            // For your custom classes,
            // You want to specify how it should print to the console and not just rely 
            // on the built in ToString() implementation.
            // It gives you the complete name of typename including the namespace.

            // You can type out override and intellisense will provide completion.
            // public override string ToString()
            // {
            //      return $"{this.LastName}, {this.FirstName}";
            // }

            // You could also convert another with with 
            // Console.WriteLine(Convert.ToString(customer));

            // -----------------------------
            // 58) Why you should override Equals method

            //int i = 10;
            //int j = 20;
            //Console.WriteLine(i == j);
            //Console.WriteLine(i.Equals(j));
            // so both of the above conditionals return true

            // It is derived from System.Object

            // There work as expected with value types.
            // But not with reference types such as a complex object.

            // Consider you are comparing two customer objects.
            // So we can ask, are they referecing the same object on the heap?
            // Then we have reference equality.

            // But also. 
            // If there are two difference objects but their fields hold the same data.

            // so == should be used for reference equality.
            // And the .Equals() method should be for value equality.

            // The default implementation doesn't know which properties to check 
            // for equality.

            // public override bool Equals(object obj) 
            // {
            //      if (obj == null)
            //      {
            //             return false;
            //      }

            //         if (!(obj is Customer))
            //         {
            //             return false;
            //         }

            //         return this.FirstName == ((Customer)obj).FirstName &&
            //          this.LastName == ((Customer)obj).LastName;
            // }

            // public override int GetHashCode()
            // {
            //      return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
            // }

            // -----------------------------
            // 59) Difference between Convert ToString and ToString

            Customer c1 = new Customer();
            string str = c1.ToString();
            Console.WriteLine(str);

            // could also use the convert class 

            Customer c2 = new Customer();
            string str2 = Convert.ToString(c2);
            Console.WriteLine(str2);

            // so you would get the same output 
            // The difference is when the c1 is null,
            // the static .ToString with the Convert class 
            // It will convert the null to an empty string.

            // If you just rely on the built in .ToString() on the object,
            // when it is null, 
            // then it will throw an exception.

            // Since can't invoke a method from a null reference.

            // So to review 
            // Convert.ToString() handles null.

            // whereas the built in .ToString() for the base object doesn't handle null 
            // and throws a Null Reference Exception

            // Neither is better than the other. 

            // -----------------------------
            // 60) Difference between String and StringBuilder

            // System.String is immutable
            // whereas StringBuilder is mutable.

            // As StringBuilder objects are mutable, they offer better performance 
            // when heavy string manipulation is involved.

            string userString = "C#";
            userString += " Video";

            // So you can concatenate, but it is actually creating a new string object on the heap.

            StringBuilder strBuilder = new StringBuilder("C#");
            strBuilder.Append(" Video");

            string emptyStr = string.Empty;

        }
    }

    // for 56)
    // for 52)
    public class Calculator
    {
        [Obsolete("Use Add(List<int> Numbers")]
        public static int Add(int FirstNumber, int SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }

        [Obsolete("Use Add(List<int> Numbers")]
        public static int Add(int FirstNumber, int SecondNumber, int ThirdNumber)
        {
            return FirstNumber + SecondNumber + ThirdNumber;
        }

        public static int Add(List<int> Numbers)
        {
            int sum = 0;
            foreach (int Number in Numbers)
            {
                sum += Number;
            }
            return sum;
        }

        // NOTE: that System.object provides the .Equals
        // for EVERY type within the .NET framework
        public static bool AreEqual<T>(T Value1, T Value2)
        {
            return Value1.Equals(Value2);
        }
    }
}
