using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new StudentLinkedList();
            list.AddInPosition(new Student() { Age = 20, ID = 10, Name = "John", Surname = "Doe" });
            list.AddInPosition(new Student() { Age = 22, ID = 5, Name = "John2", Surname = "Doe2" });
            list.AddInPosition(new Student() { Age = 23, ID = 100, Name = "John3", Surname = "Doe3" });
            list.AddInPosition(new Student() { Age = 25, ID = 4, Name = "John4", Surname = "Doe4" }, 1);

            //list.Load();
            //list.Save();
            //Console.WriteLine(list.Lenght());

            Console.WriteLine("---------------");
            foreach (var element in list)
            {
                Console.WriteLine(element.Item);
            }

            list.SwapItems(0, 2);
            Console.WriteLine("---------------");
            foreach (var element in list)
            {
                Console.WriteLine(element.Item);
            }

            list.SwapItems(1, 3);
            Console.WriteLine("---------------");
            foreach (var element in list)
            {
                Console.WriteLine(element.Item);
            }
            //Console.WriteLine("---------------");

            //foreach (var element in list)
            //{
            //    Console.WriteLine(element.Item.Name);
            //}
            //list.SwapItems(1, 3);

            //Console.WriteLine("---------------");
            //foreach (var element in list)
            //{
            //    Console.WriteLine(element.Item.Name);
            //}
        }
    }
}
