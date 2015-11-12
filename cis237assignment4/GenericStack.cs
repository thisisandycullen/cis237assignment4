using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericStack<T>
    {
        private GenericNode<T> node;

        //Check if stack is empty
        public Boolean IsNotEmpty()
        {
            if (node == null)
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
            GenericNode<T> previousNode = node;

            //Assign a new node/item
            node = new GenericNode<T>();
            node.item = item;

            //Set a reference to previous node
            node.next = previousNode;
        }

        //Take item from stack
        public T Pop()
        {
            //Set a generic item to the item on stack
            T item = node.item;

            //Set next node
            node = node.next;

            //Get the item
            return item;
        }
    }
}
