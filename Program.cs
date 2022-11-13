namespace Projekt_2_vistula
{
    internal class Program
    {
        static int[] bubbleArray = new int[20];
        static void Main(string[] args)
        {
            Random random = new Random();
            //Insetring random values to all slots of the bubbleArray
            for (int i = 0; i < bubbleArray.Length; i++) 
            {
                bubbleArray[i] = random.Next(0, 101);
            }
            DisplayArray(bubbleArray);

            Console.WriteLine("Sorting values via bubble sorting algorithm");
            int switchCounter = 0; // tracks how many times numbers changed place
            int noSwitchCounter = -1; //track since when the last switch of values were made
                                      // when all values are sorted correctly this value is equal the array lenght
            int n = 0;
            bool done = true;
            while (done)
            {
                //Resets the value of the variable array index if it goes out of bounds of the bubbleArray
                if (n + 1 > bubbleArray.Length - 1)
                {
                    n = 0;
                }
                
                //Compares values from bubbleArray
                if (bubbleArray[n] < bubbleArray[n+1])
                {
                    noSwitchCounter++;
                    if (bubbleArray.Length < noSwitchCounter)
                    {
                        done = false;
                    }
                }
                else if (bubbleArray[n] > bubbleArray[n + 1])
                {
                    noSwitchCounter = 0;
                    int temp = bubbleArray[n];
                    bubbleArray[n] = bubbleArray[n + 1];
                    bubbleArray[n + 1] = temp;
                    switchCounter++;
                }

                n++;
            }
            DisplayArray(bubbleArray);
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