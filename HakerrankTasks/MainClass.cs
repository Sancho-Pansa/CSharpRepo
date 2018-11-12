using System;
using System.Collections.Generic;

namespace HakerrankTasks
{
    class MainClass
    {
        static void Main(string[] args)
        {
            QueenAttack a = new QueenAttack(7);
            a.GetAllMovements((4, 4));

        }

    }

}
