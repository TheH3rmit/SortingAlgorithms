namespace Projekt_2_vistula
{
    internal class Program
    {
        static int[] BubbleArray = new int[20];
        static int[] SelectionArray = new int[20];
        static int[] InsertionArray = new int[20];
        static void Main(string[] args)
        {
            RandomizeArrayValues(BubbleArray);
            DisplayArray(BubbleArray);

            BubbleSorting(BubbleArray);
            DisplayArray(BubbleArray);

            Console.WriteLine();

            RandomizeArrayValues(InsertionArray);
            DisplayArray(InsertionArray);

            InsertSorting(InsertionArray);
            DisplayArray(InsertionArray);

            Console.WriteLine();

            RandomizeArrayValues(SelectionArray);
            DisplayArray(SelectionArray);

            SelectionSorting(SelectionArray);
            DisplayArray(SelectionArray);
        }

        /// <summary>
        /// Sorts the the values of 1d array via insert sorting algorithm 
        /// </summary>
        /// <param name="array"></param>
        private static void InsertSorting(int[] array)
        {
            Console.WriteLine("Sorting values via insert sorting algorithm");
            for (int i = 1; i <= array.Length - 1; i++)
            {
                int j = i;
                while (j > 0 && array[j - 1] > array[j])
                {
                    (int, int) temp = (array[j], array[j - 1]);
                    array[j] = temp.Item2;
                    array[j - 1] = temp.Item1;
                    j--;
                }
            }
        }

        /// <summary>
        /// Sorts the the values of 1d array via selection sorting algorithm 
        /// </summary>
        /// <param name="array"></param>
        private static void SelectionSorting(int[] array)
        {
            Console.WriteLine("Sorting values via selection sorting algorithm");
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minValueIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minValueIndex])
                    {
                        minValueIndex = j;
                    }
                }

                (int, int) temp = (array[minValueIndex], array[i]);
                array[minValueIndex] = temp.Item2;
                array[i] = temp.Item1;
            }
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
                    (int, int) temp = (array[n], array[n + 1]);
                    array[n] = temp.Item2;
                    array[n + 1] = temp.Item1;
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
                Console.Write(" " + array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}