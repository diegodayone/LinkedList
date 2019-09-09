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
            list.AddInPosition(new Student() { Age = 20, ID = 1, Name = "John", Surname = "Doe" });
            list.AddInPosition(new Student() { Age = 22, ID = 2, Name = "John2", Surname = "Doe2" });
            list.AddInPosition(new Student() { Age = 23, ID = 3, Name = "John3", Surname = "Doe3" });
            list.AddInPosition(new Student() { Age = 25, ID = 4, Name = "John4", Surname = "Doe4" }, 1);

            var item2 = list.Search(2);
            var item55 = list.Search(55);

            Console.WriteLine("---------------");
            foreach (var element in list)
            {
                Console.WriteLine(element.Item.Name);
            }

            list.RemoveInPosition(0);
            Console.WriteLine("---------------");

            foreach (var element in list)
            {
                Console.WriteLine(element.Item.Name);
            }
            list.RemoveInPosition(2);

            Console.WriteLine("---------------");
            foreach (var element in list)
            {
                Console.WriteLine(element.Item.Name);
            }
        }
    }
}
