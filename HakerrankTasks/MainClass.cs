using System;
using System.Collections.Generic;

namespace HakerrankTasks
{
    class MainClass
    {
        static void Main(string[] args)
        {
            var set = new HashSet<(int, int)>();
            Console.WriteLine("Enter a chessboard dimesion:");
            int dim = Convert.ToInt32(Console.ReadLine());
            QueenAttack a = new QueenAttack(dim);

            Console.WriteLine("Enter Queen position (x, y):");
            var queen = ProcessInput(Console.ReadLine());

            Console.WriteLine("Enter obstacles x1, y1; ... xn, yn:");
            var result = Console.ReadLine();
            if (result.Length > 0)
            {
                string[] coords = result.Split(';');
                var obstacles = new (int, int)[coords.Length];
                for (int i = 0; i < coords.Length; i++)
                    obstacles[i] = ProcessInput(coords[i]);
                set = a.GetAllMovements(queen, obstacles);
            }
            else
                set = a.GetAllMovements(queen);
            foreach(var x in set)
            {
                Console.WriteLine(x);
            }

        }

        static (int, int) ProcessInput(string input)
        {
            string[] numbers = input.Split(',');
            return (Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1]));
        }
    }

}
