using System;

namespace Projekt_2_vistula
{
    internal class Program
    {
        static int[] bubbleArray = new int[20];
        static int[] insertionArray = new int[20];
        static int[] selectionArray = new int[20];
        static void Main(string[] args)
        {
            //RandomizeArrayValues(bubbleArray);
            //DisplayArray(bubbleArray);

            //BubbleSorting(bubbleArray);
            //DisplayArray(bubbleArray);


            RandomizeArrayValues(selectionArray);
            DisplayArray(selectionArray);

            Console.WriteLine("Sorting values via selection sorting algorithm"); 
            for(int i = 0; i < selectionArray.Length-1; i++)
            {
                int indexOfSmalestValue = 0;
                int minInArray = selectionArray[i];
                for (int j = i+1; j < selectionArray.Length; j++)
                {
                    if (selectionArray[j] < minInArray)
                    {
                        minInArray = selectionArray[j];
                        indexOfSmalestValue = j;
                    }
                }
                if(indexOfSmalestValue != 0)
                {
                    selectionArray[indexOfSmalestValue] = selectionArray[i];
                }    
                selectionArray[i] = minInArray;
            }
            DisplayArray(selectionArray);


        }

        /// <summary>
        /// Sorts the the values of 1d array via bubble sorting algorithm 
        /// </summary>
        /// <param name="array"></param>
        private static void BubbleSorting(int[] array)
        {
            Console.WriteLine("Sorting values via bubble sorting algorithm");
            int swapCounter = 0;      // tracks how many times numbers changed place
            int noSwapCounter = -1;   // track since when the last swap of values were made
                                        // when all values are sorted correctly this value is equal the array lenght
            int n = 0;                  // points to the index of the array
            bool done = true;           // ends the while loop when algorithm finishes sorting
            while (done)
            {
                //Resets the value of the variable array index if it goes out of bounds of the bubbleArray
                if (n + 1 > array.Length - 1)
                {
                    n = 0;
                }

                //Compares values from bubbleArray
                if (array[n] <= array[n + 1])
                {
                    // values are placed correclty, there is not value swap
                    noSwapCounter++;
                    if (array.Length < noSwapCounter)
                    {
                        done = false;
                    }
                }
                else if (array[n] > array[n + 1])
                {
                    noSwapCounter = 0;
                    int temp = array[n];
                    array[n] = array[n + 1];
                    array[n + 1] = temp;
                    swapCounter++;
                }

                n++;
            }
        }

        /// <summary>
        /// Inserts random values to all slots of the array
        /// </summary>
        /// <param name="array"></param>
        private static void RandomizeArrayValues(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 101);
            }
        }

        /// <summary>
        /// Displays all values from 1d array with int values
        /// </summary>
        /// <param name="array"></param>
        private static void DisplayArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}