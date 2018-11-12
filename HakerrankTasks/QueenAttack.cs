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

        public HashSet<(int, int)> GetAllMovements((int x, int y) queen)
        {
            CheckPositivity(queen.x, queen.y);
            this.queen = queen;
            this.AssembleMovementSet();
            return horizontal;
        }

        public int GetQueenMovementsNum((int x, int y) queenTuple, 
            params (int obstX, int obstY)[] obstacles)
        {
            CheckPositivity(queenTuple.x, queenTuple.y);
            this.queen = queenTuple;
            foreach ((int, int) x in obstacles)
            {
                CheckPositivity(x.Item1, x.Item2);
                if (x.Equals(queen))
                    throw new ArgumentException("Obstacle is on Queen's place!");
                this.obstacles.Add(x);
            }
            
            return 0;
        }
        
        private int EnumerateMovements()
        {
            if (obstacles.Count == 0)
                return (N - 1) * 4;

            foreach((int x, int y) in obstacles)
            {
                
            }
            return 0;
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

        /*private int GetHorizontalCount()
        {
            int up = N / 2;
            int down = up;

            foreach((int, int) x in this.obstacles)
            {
                
                if(x.Item2 == queen.Item2)
                {
                    if (x.Item1 > queen.Item1)
                        up = x.Item1 - queen.Item1 - 1;
                    else if (x.Item1 < queen.Item1)
                        down = queen.Item1 - x.Item1 - 1;
                }
            }

            return up + down;
        }

        private int GetVerticalCount()
        {
            int left = N / 2;
            int right = left;

            foreach((int, int) x in obstacles)
            {
                if(x.Item1 == queen.Item1)
                {

                }
            }

            return left + right;
        }
        */
        private void CheckPositivity(int a, int b)
        {
            if(a <= 0 || b <= 0)
                throw new ArgumentException("Coordinates cannot be below 0");
        }
    }
}
