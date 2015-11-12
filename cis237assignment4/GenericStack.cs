using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericStack<T>
    {
        private GenericNode<T> startNode;

        //Check if stack is empty
        public Boolean IsNotEmpty()
        {
            if (startNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Add an item to the top of the stack
        public void Push(T item)
        {
            //Set previous node
            GenericNode<T> previousNode = startNode;

            //Assign a new node/item
            startNode = new GenericNode<T>();
            startNode.item = item;

            //Set a reference to previous node
            startNode.next = previousNode;
        }

        //Take item from stack
        public T Pop()
        {
            //Set a generic item to the item on stack
            T item = startNode.item;

            //Set next node
            startNode = startNode.next;

            //Get the item
            return item;
        }
    }
}
