namespace AlgorithmConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var intArray1 = new int[5] { 1, 2, 3, 4, 5 };
            var intArray2 = new int[3] { 15, 25, 35 };
            var intArray3 = new int[2] { 8, 8 };
            var solution1 = Solution(intArray1);
            var solution2 = Solution(intArray2);
            var solution3 = Solution(intArray3);
            Console.WriteLine(solution1);
            Console.WriteLine(solution2);
            Console.WriteLine(solution3);
        }

        static int Solution(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }

            var result = 0;
            foreach (var number in arr)
            {
                if (number % 2 == 0)
                {
                    if (number == 8)
                    {
                        result += 5;
                    }
                    result += 1;
                }
                else if (number % 2 == 1)
                {
                    result += 3;
                }
            }
            return result;
        }
    }
}