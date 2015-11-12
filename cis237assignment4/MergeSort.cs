//ANDY CULLEN
//DUE DATE: 11/12/15
//ASSIGNMENT 4: Interfaces, Stacks, Queues, Generics, and Merge Sort. Project uses Assignment 3 solution.

//MERGESORT CLASS

//THIS CLASS TAKES AN ICOMPARABLE ARRAY AND PERFORMS A MERGESORT ON ITS CONTENTS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        //Declare a comparable array
        private static IComparable[] compareArray;

        //Create array and begin the sort process
        public static void MergeSortArray(IComparable[] array)
        {
            //Create a comparable array. 
            compareArray = new IComparable[array.Length];

            //Begin the sort process
            SortArray(array, 0, array.Length - 1);
        }

        //Sort subarrays
        private static void SortArray(IComparable[] array, int lowVal, int highVal)
        {
            //Stop the method loop with "highVal" is no longer higher
            if (highVal <= lowVal)
            {
                return;
            }

            //Find the middle of the array
            int midVal = lowVal + ((highVal - lowVal) / 2);

            //Sort the first half of the array
            SortArray(array, lowVal, midVal);

            //Sort the second half of the array
            SortArray(array, midVal + 1, highVal);

            //Begin merge of two halves
            MergeArray(array, lowVal, midVal, highVal);
        }

        //Merge subarrays
        private static void MergeArray(IComparable[] array, int lowVal, int midVal, int highVal)
        {
            int i = lowVal;
            int j = midVal + 1;

            //Copy the array to comparable array
            for (int k = lowVal; k <= highVal; k++)
            {
                compareArray[k] = array[k];
            }

            //Copy the array to comparable array
            for (int k = lowVal; k <= highVal; k++)
            {
                if (i > midVal)
                {   //End of first subarray
                    array[k] = compareArray[j++];
                }
                else if (j > highVal)
                {   //End of second subarray
                    array[k] = compareArray[i++];
                }
                else
                {
                    if (compareArray[j] == null || compareArray[i] == null)
                    {   //Checks to see
                        array[k] = compareArray[i];
                        i++;
                    }
                    else
                    {
                        if (compareArray[j].CompareTo(compareArray[i]) < 0)
                        {
                            //Insert item from 2nd half when it is less than item in 1st half
                            array[k] = compareArray[j];
                            j++;
                        }
                        else
                        {
                            //Insert item from 1st half when it is less or equal to than item in 2nd half
                            array[k] = compareArray[i];
                            i++;
                        }
                    }
                }
            }
        }
    }
}