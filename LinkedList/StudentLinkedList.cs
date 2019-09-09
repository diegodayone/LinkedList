using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace LinkedList
{
    public class StudentLinkedList : IEnumerable<StudentListItem>
    {
        StudentListItem Head { get; set; }
        StudentListItem Tail => this.LastOrDefault();

        public int Lenght() => this.Count();
        public Student[] GetAll => this.Select(x => x.Item).ToArray();

        public void Clear()
        {
            Head = null;
            //Tail = null;
        }

        public void AddInPosition(Student element, int position = 0)
        {
            if (Head == null)
            {
                Head = new StudentListItem() { Item = element };
                //Tail = new StudentListItem() { Item = element };
            }
            else
            { 
                if (position == 0)
                {
                    var newHead = new StudentListItem() { Item = element, Next = Head };
                    Head.Prev = newHead;
                    //Tail = this.Last();
                    Head = newHead;
                }
                else
                {
                    if (this.Count() < position)
                    {
                        var newTail = new StudentListItem() { Item = element, Prev = Tail };
                        Tail.Next = newTail;
                        //Tail = newTail;
                    }
                    else
                    {
                        var previousElement = this.Skip(position -1).First();
                        var nextElement = previousElement.Next;
                        var newElement = new StudentListItem() { Item = element, Prev = previousElement, Next = nextElement };
                        previousElement.Next = newElement;
                        nextElement.Prev = newElement;
                    }
                }

            }
        }

        public bool RemoveInPosition(int position)
        {
            var numberOfElements = this.Count();
            if (position > numberOfElements) return false;

            if (position == 0) //removing head
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            else if (position == numberOfElements - 1) //removing tail
            {
                //Tail = Tail.Prev;
                Tail.Next = null;
            }
            else
            {
                var itemToBeRemoved = this.Skip(position - 1).First();
                //var itemToBeRemoved = this.ToArray()[position];
                var temp = itemToBeRemoved.Prev;
                itemToBeRemoved.Prev = itemToBeRemoved.Next;
                itemToBeRemoved.Next = temp;
            }

            return true;
        }

        //4- SwapItems(idItem1, idItem2) // Swap the item in position idItem1 with the item in position idItem2
        public void SwapItems(int position1, int position2)
        {
            var ListToArray = this.ToArray();
            if (position1 > ListToArray.Length || position2 > ListToArray.Length) throw new IndexOutOfRangeException();

            var pos1element = ListToArray[position1];
            var pos2element = ListToArray[position2];

            //change the previous and next element of both to point the other element

            var prev1 = pos1element.Prev;
            var prev2 = pos2element.Prev;

            var next1 = pos1element.Next;
            var next2 = pos2element.Next;

            if (prev1 != null)
                prev1.Next = pos2element;

            if (next1 != null)
                next1.Prev = pos2element;

            if (prev2 != null)
                prev2.Next = pos1element;

            if (next2 != null)
                next2.Prev = pos1element;

            pos1element.Next = next2;
            pos1element.Prev = prev2;

            pos2element.Next = next1;
            pos2element.Prev = prev1;

            if (pos2element.Prev == null)
                Head = pos2element;

            if (pos1element.Prev == null)
                Head = pos1element;

            //Head = this.First(x => x.Prev == null);
            //if (prev1 != null)
            //{
            //    prev1.Next = pos2element;
            //}
            //else
            //{
            //    Head = pos2element;
            //    Head.Prev = null;
            //    Head.Next = next1;
            //}

            //if (next1 != null)
            //    next1.Prev = pos2element;

            //if (prev2 != null)
            //{
            //    prev2.Next = pos1element;
            //    pos1element.Prev = prev2;
            //    pos1element.Next = next2;
            //}
            //else
            //{
            //    Head = pos1element;
            //    Head.Prev = null;
            //    Head.Next = next2;
            //}

            //if (next2 != null)
            //    next2.Prev = pos1element;

        }



        public void Save(string filename = null)
        {
            var serialized = JsonConvert.SerializeObject(this.Select(x => x.Item).ToArray());
            System.IO.File.WriteAllText(filename != null ? filename : "saved.json", serialized);
        }

        public void Load(string filename = null)
        {
            var fileContent = System.IO.File.ReadAllText(filename != null ? filename : "saved.json");
            var deserialized = JsonConvert.DeserializeObject<Student[]>(fileContent);
            this.Clear();
            foreach (var student in deserialized)
                AddInPosition(student, 0);
        }
        //this.FirstOrDefault(x => x.Item.ID == id)?.Item;
        //this.FirstOrDefault(x => x.Item.ID == id) != null ? this.FirstOrDefault(x => x.Item.ID == id)?.Item : null)
        public Student Search(int id) => this.FirstOrDefault(x => x.Item.ID == id)?.Item;

        #region Enumerator

        public IEnumerator<StudentListItem> GetEnumerator()
        {
            return new StudentLinkedListEnumerator(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new StudentLinkedListEnumerator(Head);
        }

        #endregion
    }

    public class StudentLinkedListEnumerator : IEnumerator<StudentListItem>
    {
        StudentListItem _head;
        StudentListItem _current;

        public StudentLinkedListEnumerator(StudentListItem head)
        {
            _head = head;
        }

        public StudentListItem Current => _current; //return current element

        object IEnumerator.Current => _current;

        public void Dispose()
        {
        }

        public bool MoveNext() //move to the next element
        {
            if (_current == null) _current = _head;
            else _current = _current.Next;
            return _current != null; //if the collection is finished, return false, otherwise true
        }

        public void Reset() //reset the list
        {
            _current = _head;
        }
    }
}
