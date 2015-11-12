//ANDY CULLEN
//DUE DATE: 11/12/15
//ASSIGNMENT 4: Interfaces, Stacks, Queues, Generics, and Merge Sort. Project uses Assignment 3 solution.

//GENERICNODE CLASS

//THIS CLASS DEFINES A GENERIC NODE.
//NODES ARE USED IN THE GENERIC STACK AND QUEUE CLASSES

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericNode<T>
    {
            public T item;
            public GenericNode<T> next;
    }
}
