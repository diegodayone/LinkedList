using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class StudentListItem
    {
        public Student Item { get; set; }
        public StudentListItem Next { get; set; }
        public StudentListItem Prev { get; set; }

        public override string ToString()
        {
            return (Prev != null ? Prev.Item.ID.ToString() : "NULL") +
                " <-- " + Item.ID + "-->" +
                (Next != null ? Next.Item.ID.ToString() : "NULL");

        }
    }
}
