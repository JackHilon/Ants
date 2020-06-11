using System;
using System.Collections.Generic;

namespace Ants
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ants problem
            // https://open.kattis.com/problems/ants
            
            // worst time is correct, but (best time has a problem or wrong in idea?? maybe!)


            List<string> answers = new List<string>();
            string str;

            var arr1 = EnterLine(1);
            var NumOfStates = arr1[0];

            for (int i = 0; i < NumOfStates; i++)
            {
                var arr2 = EnterLine(2);
                var PoleLength = arr2[0];
                var NumOfAnts = arr2[1];

                var arr3 = EnterLine(NumOfAnts);

                // ------
                var worstTime = WorstCase(arr3, PoleLength);
                var bestTime = BestCase(arr3, PoleLength);
                str = $"{bestTime} {worstTime}";
                answers.Add(str);
            }
            PrintList(answers);
        }

        private static void PrintList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        private static int BestCase(int[] locations, int leng)
        {
            // best case when you divide the pole into two halves 
            // convert two halves to one half using MOD operation 
            // best solution is: (the worst solution for a half)
            int m;
            if (leng % 2 == 0)
                m = leng / 2;
            else m = (leng + 1) / 2; //(-/+)
            var nArr = ITemsModCalculation(locations, m);
            return WorstCase(nArr, m);
        }

        private static int[] ITemsModCalculation(int[] arr, int m)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] % m;
            }
            return arr;
        }
        

        private static int WorstCase(int[] locations, int leng)
        {
            // all ants walk to the farest end of the pole
            var minMax = MinMaxCalculations(locations);

            // chose the farest between:
            // one farest is the Max to the index (0)
            // second farest is the Min to the index (leng i.e. the end of the pole)
            var firstNum = leng - minMax[0];
            return Math.Max(minMax[1], firstNum);
        }

        private static int[] MinMaxCalculations(int[] arr)
        {
            var ans = new int[2] { int.MaxValue, int.MinValue };

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < ans[0])
                    ans[0] = arr[i];
                
                if (arr[i] > ans[1])
                    ans[1] = arr[i];
            }

            return ans;
        }
        private static int ArrayItemsSum(int[] nums)
        {
            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];
            }
            return sum;
        }

        private static int[] EnterLine(int kkk)
        {
            var arr = new int[kkk];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
            string[] strArr;
            var str = Console.ReadLine();

            try
            {
                strArr = str.Split(' ', kkk);
                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = int.Parse(strArr[j]);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.GetType().ToString());
                return EnterLine(kkk);
            }
            return arr;
        }
    }
}
