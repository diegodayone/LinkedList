using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinkedList
{
    public class StudentLinkedList : IEnumerable<StudentListItem>
    {
        StudentListItem Head { get; set; }
        StudentListItem Tail { get; set; }


        public int Count() => this.Count();
        public Student[] GetAll => this.Select(x => x.Item).ToArray();

        public void Clear()
        {
            Head = null;
            Tail = null;
        }

        public void AddInPosition(Student element, int position = 0)
        {
            if (Head == null)
            {
                Head = new StudentListItem() { Item = element };
                Tail = new StudentListItem() { Item = element };
            }
            else
            { 
                if (position == 0)
                {
                    var newHead = new StudentListItem() { Item = element, Next = Head };
                    Head.Prev = newHead;
                    Tail = this.Last();
                    Head = newHead;
                }
                else
                {
                    if (this.Count() < position)
                    {
                        var newTail = new StudentListItem() { Item = element, Prev = Tail };
                        Tail.Next = newTail;
                        Tail = newTail;
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
                Tail = Tail.Prev;
                Tail.Next = null;
            }
            else
            {
                var itemToBeRemoved = this.Skip(position - 1).First();
                var temp = itemToBeRemoved.Prev;
                itemToBeRemoved.Prev = itemToBeRemoved.Next;
                itemToBeRemoved.Next = temp;
            }

            return true;
        }

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
