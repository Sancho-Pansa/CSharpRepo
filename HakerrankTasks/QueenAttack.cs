using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakerrankTasks
{
    class QueenAttack
    {
        private readonly int N;
        private readonly HashSet<(int, int)> obstacles = new HashSet<(int, int)>();
        private (int, int) queen;

        private HashSet<(int, int)> horizontal = new HashSet<(int, int)>();
        private HashSet<(int, int)> vertical = new HashSet<(int, int)>();
        private HashSet<(int, int)> diagonal = new HashSet<(int, int)>();

        public QueenAttack() : this(8)
        {
            
        }

        public QueenAttack(int dimension) => N = dimension;

        public HashSet<(int, int)> GetAllMovements((int x, int y) queen,
            params (int a, int b)[] obstacles)
        {
            CheckCorrect(queen.x, queen.y);
            this.queen = queen;
            AssembleMovementSet();
            var movements = new HashSet<(int, int)>();
            movements.UnionWith(horizontal);
            movements.UnionWith(vertical);
            movements.UnionWith(diagonal);

            if (obstacles.Length > 0)
            {
                foreach (var (a, b) in obstacles)
                {
                    CheckCorrect(a, b);
                    if (a == queen.x && b == queen.y)
                        throw new ArgumentException("Obstacle cannot occupy the Queen's coordinates");
                    movements.Remove((a, b));
                }
            }

            
            return movements;
        }

        private void AssembleMovementSet()
        {
            for(int i = 1; i <= N; i++)
            {
                for(int j = 1; j <= N; j++)
                {
                    if (i == queen.Item1 && j == queen.Item2)
                        continue;
                    else if (i == queen.Item1)
                        vertical.Add((queen.Item1, j));
                    else if (j == queen.Item2)
                        horizontal.Add((i, queen.Item2));
                    else if (Math.Abs(queen.Item1 - i) == Math.Abs(queen.Item2 - j))
                        diagonal.Add((i, j));
                }
            }
        }

        private void CheckCorrect(int a, int b)
        {
            if(a <= 0 || b <= 0)
                throw new ArgumentException("Coordinates cannot be below 0");
            if (a > N || b > N)
                throw new IndexOutOfRangeException("Coordinates cannot exceed board dimension");
        }
    }
}
