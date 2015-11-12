using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericQueue<T>
    {
        private GenericNode<T> startNode;
        private GenericNode<T> endNode;

        //Check if queue is not empty
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

        //Add item to queue
        public void Enqueue(T item)
        {
            //Set end node to previous node
            GenericNode<T> previousNode = endNode;

            //Assign a new node/item
            endNode = new GenericNode<T>();
            endNode.item = item;

            //Ensure next node is null
            endNode.next = null;

            switch (IsNotEmpty())
            {
                case false:
                    startNode = endNode; //There is only one item
                    break;
                case true:
                    previousNode.next = endNode; //Set reference to previous node
                    break;
            }
        }

        //Take item from the queue
        public T Dequeue()
        {
            //Set item to a generic
            T item = startNode.item;

            //Set next node
            startNode = startNode.next;

            if (IsNotEmpty())
            {
                //End node becomes null
                endNode = null;
            }

            //Get the item
            return item;
        }
    }
}
