//ANDY CULLEN
//DUE DATE: 11/12/15
//ASSIGNMENT 4: Interfaces, Stacks, Queues, Generics, and Merge Sort. Project uses Assignment 3 solution.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool dontexit = true;

            //PRINT WELCOME HEADER
            Console.WriteLine("    Jawa Droid Manager" + Environment.NewLine);
            Console.WriteLine("         ,-----.{0}       ,'_/_|_\\_`.{0}      /<<::8[O]::>\\{0}     _|-----------|_{0} :::|  | ====-=- |  |:::{0} :::|  | -=-==== |  |:::{0} :::\\  | ::::|()||  /:::{0} ::::| | ....|()|| |::::{0}     | |_________| |{0}     | |\\_______/| |{0}    /   \\ /   \\ /   \\{0}    `---' `---' `---'{0}", Environment.NewLine);

            //Create a new droid collection and set the size of it to 100.
            IDroidCollection droidCollection = new DroidCollection(100);

            //Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            //Display the main menu for the program
            userInterface.DisplayMainMenu();

            //Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            while (choice != 5)
            {
                //Test which choice was made
                switch (choice)
                {
                    case 1:
                        userInterface.CreateDroid();
                        break;
                    case 2:
                        userInterface.ColorCodeDroidList();
                        break;
                    case 3:
                        droidCollection.SortByModel();
                        userInterface.ColorCodeDroidList();
                        break;
                    case 4:
                        droidCollection.SortByCost();
                        userInterface.ColorCodeDroidList();
                        break;
                    default:
                        userInterface.DisplayError();
                        break;
                }
           

            //Re-display the menu, and re-prompt for the choice
            userInterface.DisplayMainMenu();
            choice = userInterface.GetMenuChoice();
            }
        }
    }
}
