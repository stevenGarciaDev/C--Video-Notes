using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutorials_ThomsonReuters
{
    class Program4
    {
        public static void Main(string[] args)
        {
            // ---------------------------------
            // 71) Code snippets in visual studio
            // ---------------------------------

            // Code Snippets are ready-made snippets of code you can quickly insert into your code.
            // 1. Keyboard shortcut: Ctrl K + X
            // 2. Right click and select "Insert snippet...", from the context menu
            // 3. Click on Edit - Intellisense - Insert snippet
            // 4. Use code snippet short cut.
            // Ex: use "for loop" code snippet, type "for" and press Tab key twice

            // Once a code snippet is inserted, the editable fields are highlighted in yellow, and
            // the first editable field is selected automatically.
            // Upon changing the first editable field, press TAB to move to the
            // next editable field.
            // To come to the previous editable field use SHIFT + TAB.
            // Press ENTER or ESC keys to cancel field editing and return the Code Editor to normal.

            // Code Snippet Types:
            // Expansion: These snippets allow the code snippet to be inserted at the cursor.

            // SurroundsWith: These snippets allow the code snippet to be placed around a selected
            // piece of code.

            // Refactoring: These snippets are used during code refactoring.

            // Surround-with snippets surround the selected code, with the code snippets code.
            // 1. Select the code to surround, and use keyboard shortcut. CTRL K + S
            // 2. Select the code to surround, right click and select "Surround with..." option
            // with the context menu.
            // 3. Select the code to surround, then click on Edit menu, select "IntelliSense"
            // and then select the "Surround With" command

            // Code Snippets can be used with any type of applications that you create with Visual Studio.
            // Console Apps
            // ASP.NET
            // ASP.NET MVC

            // Code Snippet Manager
            // can be used to Add or remove code snippet. You can also find the following information
            // about a code snippet.
            // 1. Description
            // 2. Shortcut
            // 3. Snippet Type
            // 4. Author

            // To access the code snippet manager, click on "Tools" and then select "Code Snippet Manager"
            // Code snippets are XML files and have .snippet extension

            // ---------------------------------
            // 72) What is a dictionary in C#?
            // ---------------------------------

            // 1. A dictionary is a collection of (key, value) pairs.
            // 2. Dictionary class is present in System.Collections.Generic namespace.
            // 3. When creating a dictionary, we need to specify the type for key and value.
            // 4. Dictionary provides fast lookups for values using keys.
            // 5. Keys in the dictionary MUST be unique.

            NewCustomer customer1 = new NewCustomer()
            {
                ID = 101,
                Name = "Steven",
                Salary = 60000
            };

            var customer2 = new NewCustomer()
            {
                ID = 110,
                Name = "Mark",
                Salary = 90000
            };

            var customer3 = new NewCustomer()
            {
                ID = 112,
                Name = "Pam",
                Salary = 70000
            };

            Dictionary<int, NewCustomer> dictionaryCustomers = new Dictionary<int, NewCustomer>();
            dictionaryCustomers.Add(customer1.ID, customer1);
            dictionaryCustomers.Add(customer2.ID, customer2);
            dictionaryCustomers.Add(customer3.ID, customer3);

            NewCustomer customer110 = dictionaryCustomers[110];
            Console.WriteLine("ID = {0}, Name = {1}, Salary = {2}", customer110.ID, customer110.Name, customer110.Salary);

            // To traverse through the dictionary, you can utilize a foreach loop.
            // For the datatype you could just use var, and it will work just the same.
            foreach (KeyValuePair<int, NewCustomer> customerKeyValuePair in dictionaryCustomers)
            {
                Console.WriteLine("ID = {0}", customerKeyValuePair.Key);
                var customer = customerKeyValuePair.Value;
                Console.WriteLine("Name = {0}, Salary = {1}", customer.Name, customer.Salary);
            }

            // So to loop through just the keys.
            foreach (int key in dictionaryCustomers.Keys)
            {
                Console.WriteLine(key);
            }

            // To loop through only the values.
            foreach (var customer in dictionaryCustomers.Values)
            {
                Console.WriteLine("Name = {0}, Salary = {1}", customer.Name, customer.Salary);
            }

            // If you have duplicate keys, then you will get a run-time exception.
            // To check that a key is not already found use .ContainsKey()
            // This method should also be used before you try to retrieve a value
            // just to ensure that it actually exists and it is not going to throw an exception.
            if (!dictionaryCustomers.ContainsKey(110))
            {
                dictionaryCustomers[110] = customer2;
            }

            // ---------------------------------
            // 73) What is a dictionary in C# continued
            // ---------------------------------
            // Cover the methods in the Dictionary class.
            // 1. TryGetValue()
            // 2. Count()
            // 3. Remove()
            // 4. Clear()
            // 5. Using LINQ extension methods with Dictionary
            // 6. Different ways to convert an array into a dictionary

            // If you try to access a key that you are not sure if it exists.
            // You can use TryGetValue()

            NewCustomer customer101;
            if (dictionaryCustomers.TryGetValue(101, out customer101))
            {
                Console.WriteLine("ID = {0}, Name = {1}, Salary = {2}", customer101.ID, customer101.Name, customer101.Salary);
            }
            else
            {
                Console.WriteLine("The key is not found");
            }

            Console.WriteLine("Total Items = {0}", dictionaryCustomers.Count);

            // could also use the Count() function which is in a different namespace
            // It's actually an extension method.

            Console.WriteLine("Total Items = {0}", dictionaryCustomers.Count(kvp => kvp.Value.Salary > 40000));
            // So here we are using LINQ and passing in a lamba expression as the predicate.

            //dictionaryCustomers.Remove(110);

            //dictionaryCustomers.Clear();

            NewCustomer[] customers = new NewCustomer[3];
            customers[0] = customer1;
            customers[1] = customer2;
            customers[2] = customer3;

            // For the arg, you first specify what the key should be
            // then specify what the value will be.
            Dictionary<int, NewCustomer> dict = customers.ToDictionary(cust => cust.ID, cust => cust);

            foreach (KeyValuePair<int, NewCustomer> kvp in dict)
            {
                Console.WriteLine("Key = {0}", kvp.Key);
                NewCustomer cust = kvp.Value;
                Console.WriteLine("ID = {0}, Name = {1}, Salary = {2}", cust.ID, cust.Name, cust.Salary);
            }

            // ---------------------------------
            // 74) List collection class in C#
            // ---------------------------------

            // List is one of the generic collection classes present in System.Collection.Generic namespace.
            // There are several generic collection classes in System.Collections.Generic namespace.
            // 1. Dictionary
            // 2. List
            // 3. Stack
            // 4. Queue

            // A List class can be used to create a collection of any type.

            // For example, we can create a list of Intgers, Strings and even complex types.

            // The objects stored in the list can be accessed by index.

            // Unlike arrays, list can grow in size automatically.

            // This class also provides methods to search, sort, and manipulate lists.

            // DEMO

            NewCustomer[] myCustomers = new NewCustomer[2];
            myCustomers[0] = customer1;
            myCustomers[1] = customer2;

            // So build would succeed, BUT would get an exception at runtime.
            customers[2] = customer3;

            // Arrays don't grow in size automatically.
            // But Lists do grow automatically.

            List<NewCustomer> customersList = new List<NewCustomer>(2);
            customersList.Add(customer1);
            customersList.Add(customer2);
            customersList.Add(customer3);

            // No error as Lists can grow in size automatically.

            NewCustomer c = customersList[0];
            Console.WriteLine("ID = {0}, Name = {1}, Salary = {2}", c.ID, c.Name, c.Salary);

            // To iterate through the entire List, you can use a for loop or a foreach loop.
            foreach (NewCustomer cu in customersList)
            {
                Console.WriteLine("ID = {0}, Name = {1}, Salary = {2}", cu.ID, cu.Name, cu.Salary);
            }

            // So prefer to use a foreach loop when iterating through a collection.

            // The List class is strongly typed, meaning that you specify the type
            // that the collection can contain.

            // To insert an object at a specific location,
            // as the .Add() will just append to the end.
            customersList.Insert(0, customer3);
            // So when you insert it, it will push the rest of the elements
            // down in the collection from that point.

            // To retrieve the index of a specific object in the list.
            int index = customersList.IndexOf(customer3);

            // The .IndexOf() method is overloaded so it can accept an second argument
            // which will specify from what index to start searching from.
            int index2 = customersList.IndexOf(customer3, 1);

            // You could also specify the number of items to look.
            // For how many elements to you want to look from the start point.
            int index3 = customersList.IndexOf(customer3, 1, 2);

            // NOTE: That it will throw an exception is the range to look through
            // is more than the actual count.

            // ---------------------------------
            // 75) List collection class in C# contiued
            // ---------------------------------

            // Contains() function
            // Checks if an item exists in the list. This method returns
            // true if the items exist, else false.

            // Exists() function
            // Checks if an item exists in the list based on a condition. This
            // method returns true if the items exists, else false.

            // Find()
            // Searches for an element that matches the conditions defined
            // by the specified lambda expression and returns the first matching
            // item from the list.

            // FindLast()
            // Searches fro an element that matches the conditions defined
            // by the specified lambda expression and returns the Last matching
            // item from the list.

            // FindAll()
            // Returns all the items from the list that match the conditions
            // specified by the lambda expression.

            // FindIndex()
            // Returns the index of the first item, that matches the condition specified
            // by the lambda expression.
            // There are 2 other overloads of this method which allow us to specify
            // the range of elements to search within the list.

            // FindLastIndex()
            // Returns the last index of the last item, that matches the condition specified
            // by the lambda expression. There are 2 other overloads of
            // this method which allows us to specify the range of elements to search
            // within the list.

            // Convert an array to a list
            // Use ToList() method

            // Convert a list to an array
            // Use ToArray() method

            // Convert a list to a dictionary
            // use ToDictionary() method

            if (customersList.Contains(customer1))
            {
                Console.WriteLine("Yes it is found");
            }
            else
            {
                Console.WriteLine("Customer was not found in the list.");
            }

            // Check if an item exists in a list depending on a given condition.
            if (customersList.Exists(cust => cust.Name.StartsWith("S")))
            {
                Console.WriteLine("Yes, customer exists in the list.");
            }

            // So Find() is quite similar, except it returns the first occurence,
            // rather than a boolean as shown previous.
            NewCustomer cust1334 = customersList.Find(cust => cust.Salary > 50000);

            // So FindLast()
            // This returns the Last matching item from the list rather than the first
            // like the one shown above.

            NewCustomer lastMatchingCustomer = customersList.FindLast(cust => cust.Salary > 50000);

            // FindAll()
            List<NewCustomer> matchingCustomers = customersList.FindAll(cust => cust.Salary > 50000);

            // FindIndex()
            // Based on the matching condition.
            int matchingIndex1 = customersList.FindIndex(cust => cust.Salary > 50000);

            // Could also supply the first argument to be an integer to state
            // where to start searching from. (could supply another arg for a range)
            int matchingIndexFromRange = customersList.FindIndex(2, cust => cust.Salary > 50000);


            // FindLastIndex()
            // This also has three overloads with use cases with the same as above.
            int matchingLastIndex = customersList.FindLastIndex(1, cust => cust.Salary > 50000);

            // Convert an array to a list
            List<NewCustomer> myNewList = myCustomers.ToList();

            // Convert a list to an array.
            NewCustomer[] myConvertedArray = customersList.ToArray();

            // Convert a list to a dictionary.
            Dictionary<int, NewCustomer> convertedDictionary = customersList.ToDictionary(x => x.ID);

            foreach (KeyValuePair<int, NewCustomer> currentCust in convertedDictionary)
            {
                Console.WriteLine("ID = {0}", currentCust.Key);
                NewCustomer cust = currentCust.Value;
                Console.WriteLine("Name = {0}, Salary = {1}", cust.Name, cust.Salary);
            }


            // ---------------------------------
            // 76) Working with generic list class and ranges in C#
            // ---------------------------------

            // AddRange()
            // Add() method allows you to add one item at a time to the end of the list,
            // where AddRange() allows you to add another list of items,
            // to the end of the list.

            // GetRange()
            // Using an item index, we can retrieve only one item at a time from the list,
            // if you want to get a list of items from the list, then use GetRange()
            // This function expects 2 parameters, the start index of the list and
            // the number of elements to return.

            // InsertRange()
            // Insert() method allows you to insert a single item into the list at a specified
            // index where InsertRange() allows you to insert another list of items to your list
            // at the specified index.

            // RemoveRange()
            // Remove() removes only the first matching item from the list.
            // RemoveAt() function removes the item at the specified index in the list.
            // RemoveAll() removes all the items that match the specified condition.
            // RemoveRange() removes a range of elements from the list.
            // This function expects 2 parameters the start index in the list and the number of
            // elements to remove.
            // If you want to remove all the elements from the list without specifying any condition,
            // then use Clear() function.

            // --

            // so from index 0 get 2 customers
            // List<Customer> customers = listCustomers.GetRange(0, 2);



            // ---------------------------------
            // 77) Sort a list of simple types in C#
            // ---------------------------------

            // Sorting a list of simple types like int, string, char is straight forward.
            // just invoke the sort() method on the list instance and the data will
            // be automatically sorted in ascending order
            List<int> numbers = new List<int> { 1, 8, 7, 5, 2, 3, 4, 9, 6 };
            numbers.Sort();
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            // If you want the data to be retrieved in desceding order, use Reverse() method
            // on the list instance.
            numbers.Reverse();


            // However when you do the same thing with a complex type like NewCustomer, we get
            // a runtime invalid operation expception - failed to compare 2 elements in the array.
            // This is because .NET runtime does not know how to sort complex types.
            // We have to tell the way we want data to be sorted in the list by
            // implementing IComparable interface.

            // How is the sort functionality working for simple types like int, string, char.
            // That is because these types (int, string, decimal, char, etc.) have
            // implemented IComparable interface already.

            // To sort a list of strings.
            List<string> alphabets = new List<string>() { "B", "F", "D", "E", "A", "C" };
            Console.WriteLine("Alphabets before sorting.");
            foreach (string alphabet in alphabets)
            {
                Console.WriteLine(alphabet);
            }

            alphabets.Sort();
            Console.WriteLine("Alphabets after sorting.");
            foreach (string alphabet in alphabets)
            {
                Console.WriteLine(alphabet);
            }

            alphabets.Reverse();
            Console.WriteLine("Alphabets sorted in descending order.");
            foreach (string alphabet in alphabets)
            {
                Console.WriteLine(alphabet);
            }

            // Now for sorting a complex type like NewCustomer.
            // You have to tell .NET runtime how you want these complex types
            // to be sorted by implementing the interface IComparable

            // ---------------------------------
            // 78) Sort a list of complex types in C#
            // ---------------------------------

            // To sort a list of complex types without using LINQ, the complex type has to implement IComparable
            // interface and provide implementation for CompareTo() method.
            // CompareTo() method returns an integer and the meaning of the return value is shown below.

            // RETURN VALUE is
            // Greater than zero =>
            // the current instance is greater than the object being compared with

            // Less than ZERO =>
            // the current instance is less than the object being compared with

            // is ZERO =>
            // the current instance is equal to the object being compared with

            // Alternatively you can also invoke CompareTo() method
            // you can invoke its value on one of its primitive properties
            // as to return its value

            customersList.Sort();

            // Using LINQ
            customersList.OrderByDescending(cust => cust.Salary);

            // There may also be the case when you want to sort a data structure
            // (a class) but you don't have access to the implementation.
            // Well you could use LINQ,

            // Or can do another way.
            // You can provide your own by implementing ICompararer interface.

            // shown below in its own class SortByName()
            // Step 1: Implement IComparer interface
            // Step 2: Pass in instance of the class that implements IComparer interace,
            // as an argument to the Sort() method
            SortByName sortByName = new SortByName();
            customersList.Sort(sortByName);

            // There are several overloaded methods for the .Sort() method
            // on the List<> data structure.

            // ---------------------------------
            // 79) Sort a list of complex types using Comparison delegate
            // ---------------------------------

            // One of the overloads of the Sort() method in List class expects Comparison delegate
            // to be passed as an argument
            // public void Sort(Comparison<T> comparison);

            // Approach 1:
            // Step 1: Create a function whose signature matches the signature of
            // System.Comparison delegate.
            // This is the method where we need to write the logic to compare 2 customer objects.
            // private static int CompareCustomers(NewCustomer c1, NewCustomer c2)
            // {
            //      return c1.ID.CompareTo(c2.ID);
            // }

            // Step 2: Create an instance of System.Comparison delegate and then pass the name
            // of the function created in Step 1 as the argument.
            // So at this point "Comparison" delegate is pointing to our function
            // that contains the logic to compare 2 customer objects.
            // Comparison<Customer> customerComparer = new Comparison<NewCustomer>(CompareCustomers);

            // Step 3: Pass the delegate instance as an argument to Sort() function.
            // customersList.Sort(customComparer);

            // NOTE: a delegate is a function pointer
            // when you invoke the delegate, it will automatically
            // invoke the function that it points to

            Comparison<NewCustomer> customerComparer = new Comparison<NewCustomer>(CompareCustomer);

            customersList.Sort(customerComparer);

            foreach (NewCustomer customer in customersList)
            {
                Console.WriteLine($"{ customer.ID }");
            }

            // APPROACH 2:
            // We don't actually have to go through all those steps as done in the previous
            // approach.
            // Rather we can achieve the same thing utilizing the delegate keyword.
            // In approach 1 we did the following:
            // 1. Created a private function that contains the logic to compare customers
            // 2. Created an instance of Comparison delegate, and then passed the name of
            // the private function to the delegate.
            // 3. Finally passed the delegate instance to the Sort() method.

            // Now a simplified way.
            // Use the delegate keyword
            customersList.Sort(delegate (NewCustomer c1, NewCustomer c2)
            {
                return (c1.ID.CompareTo(c2.ID));
            });

            // Approach 3:
            // Can be further simplified by using lamda expressions
            customersList.Sort((c1, c2) => c1.ID.CompareTo(c2.ID));
        }

        private static int CompareCustomer(NewCustomer x, NewCustomer y)
        {
            return x.ID.CompareTo(y.ID);
        }
    }

    public class SortByName : IComparer<NewCustomer>
    {
        public int Compare(NewCustomer x, NewCustomer y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    public class NewCustomer : IComparable<NewCustomer>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public int CompareTo(NewCustomer obj)
        {
            // if (this.Salary > obj.Salary)
            // {
            //     return 1;
            // }
            // else if (this.Salary < obj.Salary)
            // {
            //     return -1;
            // }
            // else
            // {
            //     return 0;
            // }

            return this.Salary.CompareTo(obj.Salary);
        }
    }
}
