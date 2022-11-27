namespace Projekt_2_vistula
{
    internal class Program
    {
        static int[] jpBubbleArray = new int[20];
        static int[] jpSelectionArray = new int[20];
        static int[] jpInsertionArray = new int[20];
        static void Main(string[] args)
        {
            BubbleAlgorithm();

            Console.WriteLine();

            InsertionAlgorithm();

            Console.WriteLine();

            SelectionAlgorithm();
        }

        /// <summary>
        /// Starts the selection sorting algorithm
        /// </summary>
        private static void SelectionAlgorithm()
        {
            RandomizeArrayValues(jpSelectionArray);
            Console.WriteLine("Initial array");
            DisplayArray(jpSelectionArray);

            Console.WriteLine();

            Console.WriteLine("It took {0} swaps to sort this array", SelectionSorting(jpSelectionArray));
            DisplayArray(jpSelectionArray);
        }

        /// <summary>
        /// Starts the insertion sorting algorithm
        /// </summary>
        private static void InsertionAlgorithm()
        {
            RandomizeArrayValues(jpInsertionArray);
            Console.WriteLine("Initial array");
            DisplayArray(jpInsertionArray);

            Console.WriteLine();

            Console.WriteLine("It took {0} swaps to sort this array", InsertSorting(jpInsertionArray));
            DisplayArray(jpInsertionArray);
        }

        /// <summary>
        /// Starts the bubble sorting algorithm
        /// </summary>
        private static void BubbleAlgorithm()
        {
            RandomizeArrayValues(jpBubbleArray);
            Console.WriteLine("Initial array");
            DisplayArray(jpBubbleArray);

            Console.WriteLine();

            Console.WriteLine("It took {0} swaps to sort this array", BubbleSorting(jpBubbleArray));
            DisplayArray(jpBubbleArray);
        }

        /// <summary>
        /// Sorts the the values of 1d array via insert sorting algorithm 
        /// </summary>
        /// <param name="jpArray"></param>
        private static int InsertSorting(int[] jpArray)
        {
            Console.WriteLine("Sorting values via insert sorting algorithm");
            int jpSwapCounter = 0;
            for (int jpI = 1; jpI < jpArray.Length; jpI++)
            {
                int jpJ = jpI;
                while (jpJ > 0 && jpArray[jpJ - 1] > jpArray[jpJ]) // Currently chosen value from the array is compared to the all values that stand before it 
                {
                    (int, int) jpTemp = (jpArray[jpJ], jpArray[jpJ - 1]); // use of tuple to swap values
                    jpArray[jpJ] = jpTemp.Item2;
                    jpArray[jpJ - 1] = jpTemp.Item1;
                    jpSwapCounter++;    // tracks how many times numbers changed place
                    jpJ--;
                }
            }
            return jpSwapCounter;
        }

        /// <summary>
        /// Sorts the the values of 1d array via selection sorting algorithm 
        /// </summary>
        /// <param name="jpArray"></param>
        private static int SelectionSorting(int[] jpArray)
        {
            Console.WriteLine("Sorting values via selection sorting algorithm");
            int jpSwapCounter = 0;
            for (int jpI = 0; jpI < jpArray.Length - 1; jpI++) 
            {
                int jpMinValueIndex = jpI;
                for (int jpJ = jpI + 1; jpJ < jpArray.Length; jpJ++) // goes through all arrays elements to find the lowest number for the currently slected index of the array
                {
                    if (jpArray[jpJ] < jpArray[jpMinValueIndex])
                    {
                        jpMinValueIndex = jpJ;
                    }
                }

                (int, int) temp = (jpArray[jpMinValueIndex], jpArray[jpI]); // use of tuple to swap values
                jpArray[jpMinValueIndex] = temp.Item2;
                jpArray[jpI] = temp.Item1;
                jpSwapCounter++;    // tracks how many times numbers changed place
            }
            return jpSwapCounter;
        }

        /// <summary>
        /// Sorts the the values of 1d array via bubble sorting algorithm 
        /// </summary>
        /// <param name="jpArray"></param>
        private static int BubbleSorting(int[] jpArray)
        {
            Console.WriteLine("Sorting values via bubble sorting algorithm");
            int jpSwapCounter = 0;      // tracks how many times numbers changed place
            int jpNoSwapCounter = 0;   // track since when the last swap of values were made
                                      // when all values are sorted correctly this value is equal the array lenght
            bool jpDone = true;         // ends the while loop when algorithm finishes sorting
            while (jpDone)
            {

                for(int jpI = 0; jpI < jpArray.Length-1; jpI++)
                {
                    if(jpArray[jpI] > jpArray[jpI+1])
                    {
                        jpNoSwapCounter = 0;
                        (int, int) jpTemp = (jpArray[jpI], jpArray[jpI + 1]); // use of tuple to swap values
                        jpArray[jpI] = jpTemp.Item2;
                        jpArray[jpI + 1] = jpTemp.Item1;
                        jpSwapCounter++;    // tracks how many times numbers changed place
                    }
                    else
                    {
                        jpNoSwapCounter++;
                        if (jpArray.Length < jpNoSwapCounter) // checks if all values were sorted
                        {
                            jpDone = false; // ends program 
                        }
                    }
                }
            }
            return jpSwapCounter;
        }

        /// <summary>
        /// Inserts random values to all slots of the array
        /// </summary>
        /// <param name="jpArray"></param>
        private static void RandomizeArrayValues(int[] jpArray)
        {
            Random jpRandom = new Random();
            for (int jpI = 0; jpI < jpArray.Length; jpI++)
            {
                jpArray[jpI] = jpRandom.Next(0, 101);
            }
        }

        /// <summary>
        /// Displays all values from 1d array with int values
        /// </summary>
        /// <param name="jpArray"></param>
        private static void DisplayArray(int[] jpArray)
        {
            for (int jpI = 0; jpI < jpArray.Length; jpI++)
            {
                string jpOutput = jpArray[jpI].ToString();
                Console.Write(jpOutput.PadRight(4));
            }
            Console.WriteLine();
        }
    }
}