using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteBoardMod3_2._1
{
    class Program
    {
        static int[] dataTest = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static void Main(string[] args)
        {
            Console.WriteLine(Binary_Search(dataTest, 7));
            Console.Read();
        }

        public static int Binary_Search(int[] data, int item)
        {
            int min = 0;
            int N = data.Length;
            int max = N - 1;
            int mid;

            do
            {
                mid = (min + max) / 2;

                if (data[mid] < item)
                {
                    min = mid;
                }
                else
                {
                    max = mid - 1;
                }
                if (data[mid] == item)
                    return mid;
                

            } while (mid <= max);
            return -1;
            
        }
    }
}
