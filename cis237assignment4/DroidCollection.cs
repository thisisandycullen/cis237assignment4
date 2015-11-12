//ANDY CULLEN
//DUE DATE: 11/12/15
//ASSIGNMENT 4: Interfaces, Stacks, Queues, Generics, and Merge Sort. Project uses Assignment 3 solution.

//DROIDCOLLECTION CLASS

//THIS CLASS ACCEPTS NEW DROIDS FROM THE USER INTERFACE AND STORES THEM IN A LIST.
//DIFFERENT SORTING METHODS ARE CALLED FROM THIS CLASS.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        public static IDroid[] droidArray;
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidArray = new IDroid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;

            PopulateDroidList();    //add hardcoded droids to the collection
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidArray.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidArray[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidArray.Length - 1))
            {
                droidArray[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidArray.Length - 1))
            {
                droidArray[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidArray.Length - 1))
            {
                droidArray[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetLength()
        {
            int length = droidArray.Length;
            return length;
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //I ended up not using this so I could print out each droid color-coded individually.
            string returnString = "";
            return returnString;
        }
        
        public void SortByModel()
        {
            //Create generic stacks for each model type
            GenericStack<Droid> protocolStack = new GenericStack<Droid>();
            GenericStack<Droid> utilityStack = new GenericStack<Droid>();
            GenericStack<Droid> janitorStack = new GenericStack<Droid>();
            GenericStack<Droid> astromechStack = new GenericStack<Droid>();

            //Create new generic queue
            GenericQueue<Droid> droidQueue = new GenericQueue<Droid>();
           
            foreach (Droid droid in droidArray)
            {
                if (droid != null)
                {
                    switch (droid.GetModel())
                    {
                        case "Protocol":
                            protocolStack.Push(droid);
                            break;
                        case "Utility":
                            utilityStack.Push(droid);
                            break;
                        case "Janitor":
                            janitorStack.Push(droid);
                            break;
                        case "Astromech":
                            astromechStack.Push(droid);
                            break;
                        default:
                            break;
                    }
                }
            }

            //Get droids from each stack and enqueue them
            while (astromechStack.IsNotEmpty())
            {
                droidQueue.Enqueue(astromechStack.Pop());
            }
            while (janitorStack.IsNotEmpty())
            {
                droidQueue.Enqueue(janitorStack.Pop());
            }
            while (utilityStack.IsNotEmpty())
            {
                droidQueue.Enqueue(utilityStack.Pop());
            }
            while (protocolStack.IsNotEmpty())
            {
                droidQueue.Enqueue(protocolStack.Pop());
            }

            int i = 0; 
            while (droidQueue.IsNotEmpty())
            {
                droidArray[i] = droidQueue.Dequeue();
                i++;
            }
        }

        public void SortByCost()
        {
            //Get the total cost for each droid
            foreach (Droid droid in droidArray)
            {
                if (droid != null)
                {
                    droid.CalculateTotalCost();
                }
            }

            //Sort the array by cost
            MergeSort.MergeSortArray(droidArray);
        }

        public void PopulateDroidList()
        {
            Console.WriteLine("Loading droid list...");
            Add("Vanadium", "Protocol", "Gold", 20);
            Add("Carbonite", "Utility", "Bronze", true, false, true);
            Add("Quadranium", "Janitor", "Gold", false, false, false, false, true);
            Add("Vanadium", "Astromech", "Bronze", false, true, false, false, 25);
            Add("Quadranium", "Protocol", "Silver", 60);
            Add("Vanadium", "Utility", "Silver", true, false, false);
            Add("Carbonite", "Janitor", "Bronze", true, true, false, true, true);
            Add("Carbonite", "Astromech", "Silver", true, false, false, true, 10);
            Add("Vanadium", "Protocol", "Silver", 10);
            Add("Carbonite", "Utility", "Silver", true, true, false);
            Add("Quadranium", "Janitor", "Gold", true, true, false, true, true);
            Add("Quadranium", "Astromech", "Gold", true, true, true, true, 100);
            Console.WriteLine("Droids loaded succesffully!" + Environment.NewLine);
        }
    }
}
