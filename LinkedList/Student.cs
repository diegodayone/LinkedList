﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return ID + Name + Surname;
        }

    }
}
