//ANDY CULLEN
//DUE DATE: 11/12/15
//ASSIGNMENT 4: Interfaces, Stacks, Queues, Generics, and Merge Sort. Project uses Assignment 3 solution.

//USERINTERFACE CLASS

//THIS CLASS HANDLES USER INPUT, ASSIGNS VALUES FOR NEW DROID OBJECTS, AND PRINTS INFORMATION TO THE CONSOLE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class to handle all of the User Interface operations
    class UserInterface
    {
        //Create a class level variable for the droid collection
        IDroidCollection droidCollection;

        //Constructor that will take in a droid collection to use
        public UserInterface(IDroidCollection DroidCollection)
        {
            this.droidCollection = DroidCollection;
        }

        //Method to display the main menu
        public void DisplayMainMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add a new droid to the system");
            Console.WriteLine("2. Show the droid list");
            Console.WriteLine("3. Show droids sorted by model");
            Console.WriteLine("4. Show droids sorted by price");
            Console.WriteLine("5. Exit the program");
            Console.WriteLine();
        }

        //Method to get a menu choice
        public int GetMenuChoice()
        {
            //Display prompt and get the input from the user
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            string choice = Console.ReadLine();
            Console.ResetColor();


            //Set a variable for the menu choice to 0. Try to parse the input, if successful, return the menu choice.
            int menuChoice = 0;
            try
            {
                menuChoice = Int32.Parse(choice);
            }
            catch (Exception e)
            {
                menuChoice = 0;
            }

            return menuChoice;
        }

        public void DisplayError()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Environment.NewLine + "Invalid input." + Environment.NewLine);
            Console.ResetColor();
        }

        //Method to do the work of creating a new droid
        public void CreateDroid()
        {
            //Prompt for color selection
            this.DisplayColorSelection();
            //Get the choice that the user makes
            int choice = this.GetMenuChoice();

            //If the choice is not valid, loop until it is valid, or the user cancels the operation
            while(choice < 1 || choice > 4)
            {
                //Prompt for a valid choice
                this.DisplayColorSelection();
                choice = this.GetMenuChoice();
            }

            //Check the choice against the possibilities
            //If there is one found, work on getting the next piece of information.
            switch(choice)
            {
                case 1:
                    this.ChooseMaterial("Bronze");
                    break;

                case 2:
                    this.ChooseMaterial("Silver");
                    break;

                case 3:
                    this.ChooseMaterial("Gold");
                    break;
            }
        }

        //Method to print out the droid list
        public void ColorCodeDroidList()
        {
            Console.WriteLine();

            //PRINT OUT DROID INFO INDIVIUALLY -- COLOR-CODED BY DROID COLOR!
            int i = 0;
            while (DroidCollection.droidArray[i] != null)
            {
                DroidCollection.droidArray[i].CalculateTotalCost();

                switch (((Droid)DroidCollection.droidArray[i]).Color)
                {
                    case "Bronze":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        PrintDroid(i);
                        break;
                    case "Silver":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        PrintDroid(i);
                        break;
                    case "Gold":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        PrintDroid(i);
                        break;
                }

                i++;
            }

            Console.ResetColor();
        }

        private void PrintDroid(int i)
        {
            Console.WriteLine("******************************" + Environment.NewLine);
            Console.WriteLine(DroidCollection.droidArray[i].ToString());
            Console.Write("Total Cost: ");
            Console.WriteLine(DroidCollection.droidArray[i].TotalCost.ToString("N") + " Credits");
            Console.WriteLine("******************************" + Environment.NewLine);
        }

        //Display the Model Selection
        private void DisplayModelSelection()
        {
            Console.WriteLine();
            Console.WriteLine("What type of droid is it?");
            Console.WriteLine("1. Protocol");
            Console.WriteLine("2. Utility");
            Console.WriteLine("3. Janitor");
            Console.WriteLine("4. Astromech");
            Console.WriteLine("5. Cancel This Operation");
            Console.WriteLine();
        }

        //Display the Material Selection
        private void DisplayMaterialSelection()
        {
            Console.WriteLine();
            Console.WriteLine("What material is the droid made out of?");
            Console.WriteLine("1. Carbonite");
            Console.WriteLine("2. Vanadium");
            Console.WriteLine("3. Quadranium");
            Console.WriteLine("4. Cancel This Operation");
            Console.WriteLine();
        }

        //Display the Color Selection
        private void DisplayColorSelection()
        {
            Console.WriteLine();
            Console.WriteLine("What color is the droid?");
            Console.WriteLine("1. Bronze");
            Console.WriteLine("2. Silver");
            Console.WriteLine("3. Gold");
            Console.WriteLine("4. Cancel This Operation");
            Console.WriteLine();
        }

        //Display the Number of Languages Selection
        private void DisplayNumberOfLanguageSelection()
        {
            Console.WriteLine();
            Console.WriteLine("How many languages does the droid know?");
            Console.WriteLine();
        }

        //Display and get the utility options
        private bool[] DisplayAndGetUtilityOptions()
        {
            Console.WriteLine();
            bool option1 = this.DisplayAndGetOption("Does the droid have a toolbox?");
            Console.WriteLine();
            bool option2 = this.DisplayAndGetOption("Does the droid have a computer connection?");
            Console.WriteLine();
            bool option3 = this.DisplayAndGetOption("Does the droid have an arm?");
            Console.WriteLine();

            bool[] returnArray = {option1, option2, option3};
            return returnArray;
        }

        //Display and get the Janitor options
        private bool[] DisplayAndGetJanitorOptions()
        {
            Console.WriteLine();
            bool option1 = this.DisplayAndGetOption("Does the droid have a trash compactor?");
            Console.WriteLine();
            bool option2 = this.DisplayAndGetOption("Does the droid have a vaccum?");
            Console.WriteLine();

            bool[] returnArray = { option1, option2 };
            return returnArray;
        }

        //Display and get the astromech options
        private bool DisplayAndGetAstromechOptions()
        {
            Console.WriteLine();
            return this.DisplayAndGetOption("Does the droid have a fire extinguisher?");
        }

        //Display and get the number of ships
        private int DisplayAndGetAstromechNumberOfShips()
        {
            Console.WriteLine();
            Console.WriteLine("How many ships has the droid worked on?");
            Console.WriteLine();

            int choice = this.GetMenuChoice();

            while (choice <= 0)
            {
                Console.WriteLine("Not a valid number of ships");
                Console.WriteLine("How many ships as the droid worked on?");
                Console.WriteLine();

                choice = this.GetMenuChoice();
            }
            return choice;
        }

        //Method to display and get a general option
        //It ensures that Y or N is the typed response
        private bool DisplayAndGetOption(string optionString)
        {
            Console.WriteLine(optionString + " (y/n)");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            string choice = Console.ReadLine();
            Console.ResetColor();

            while (choice.ToUpper() != "Y" && choice.ToUpper() != "N")
            {
                Console.WriteLine(optionString);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("> ");
                choice = Console.ReadLine();
                Console.ResetColor();
            }
            if (choice.ToUpper() == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method to choose the Material for the droid. It accepts Color as the parameter
        private void ChooseMaterial(string Color)
        {
            //Display the material selection
            this.DisplayMaterialSelection();
            //get the users choice
            int choice = this.GetMenuChoice();

            //while the chioce is not valid, wait until there is a valid one
            while (choice < 0 || choice > 4)
            {
                this.DisplayMaterialSelection();
                choice = this.GetMenuChoice();
            }

            //Check to see which choice was chosen. Call choose model and pass the color an material over
            //to the method to get the model
            switch(choice)
            {
                case 1:
                    this.ChooseModel(Color, "Carbonite");
                    break;
                        
                case 2:
                    this.ChooseModel(Color, "Vanadium");
                    break;

                case 3:
                    this.ChooseModel(Color, "Quadranium");
                    break;

            }
        }

        //Method to choose a model and decide what other input is needed based on the selected model
        private void ChooseModel(string Color, string Material)
        {
            //Display the menu to choose which model
            this.DisplayModelSelection();
            //Get the model choice
            int choice = this.GetMenuChoice();

            //While the choice is not valid, keep prompting for a choice
            while (choice < 0 || choice > 5)
            {
                //Display the menu again, and ask for the option again.
                this.DisplayModelSelection();
                choice = this.GetMenuChoice();
            }

            //Based on the choice, call the next set of crieteria that needs to be determined
            switch (choice)
            {
                case 1:
                    this.ChooseNumberOfLanguages(Color, Material, "Protocol");
                    break;

                case 2:
                    this.ChooseOptions(Color, Material, "Utility");
                    break;

                case 3:
                    this.ChooseOptions(Color, Material, "Janitor");
                    break;

                case 4:
                    this.ChooseOptions(Color, Material, "Astromech");
                    break;
            }
        }

        //Method to choose the number of langages that a droid knows. It accepts the values that were determined
        //in the past methods. This method will also add a droid based on the collected information.
        private void ChooseNumberOfLanguages(string Color, string Material, string Model)
        {
            //Display the number of languages selection
            this.DisplayNumberOfLanguageSelection();
            //Get the users choice
            int choice = this.GetMenuChoice();

            //While the choice is not valid, keep prompting for a valid one.
            while (choice < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Not a valid number of languages");
                Console.ResetColor();

                this.DisplayNumberOfLanguageSelection();
                choice = this.GetMenuChoice();
            }

            //The only droid that we can add with this criteria is a protocol droid, so add it to the droid collection
            this.droidCollection.Add(Material, Model, Color, choice);

        }

        //Method to figure out which of the utility droids the user is creating, and then work on collecting the rest
        //of the needed information to create the droid.
        private void ChooseOptions(string Color, string Material, string Model)
        {
            //Display and get the utility options.
            bool[] standardOptions = this.DisplayAndGetUtilityOptions();

            //Based on the model chosen, figure out the remaining information needed.
            switch(Model)
            {
                //If it is a utility
                case "Utility":
                    this.droidCollection.Add(Material, Model, Color, standardOptions[0], standardOptions[1], standardOptions[2]);
                    break;

                //If it is a Janitor
                case "Janitor":
                    //Get the rest of the options for a Janitor droid.
                    bool[] janitorOptions = this.DisplayAndGetJanitorOptions();
                    //Add it to the collection
                    this.droidCollection.Add(Material, Model, Color, standardOptions[0], standardOptions[1], standardOptions[2], janitorOptions[0], janitorOptions[1]);
                    break;

                //If it is a Astromech
                case "Astromech":
                    //Get the rest of the options for an astromech
                    bool astromechOption = this.DisplayAndGetAstromechOptions();
                    int astromechNumberOfShips = this.DisplayAndGetAstromechNumberOfShips();
                    //Add it to the collection
                    this.droidCollection.Add(Material, Model, Color, standardOptions[0], standardOptions[1], standardOptions[2], astromechOption, astromechNumberOfShips);
                    break;
            }
        }

    }
}
