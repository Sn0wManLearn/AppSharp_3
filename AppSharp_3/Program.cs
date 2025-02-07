using System;
using System.IO;

namespace AppSharp_3
{
    class MyClass
    {
        static void Main()
        {
            

            int[,] labirynth1 = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 0 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 0, 0, 0, 0 },
                {1, 1, 1, 0, 1, 0, 1 }
            };

            int result = HasExit(1, 1, labirynth1);

            Console.WriteLine($"Количество выходов: {result}");
            Console.WriteLine(result>0?"Всё хорошо. Можно выйти!":"Нас замуровали!!!");
        }
        static int HasExit(int startI, int startJ, int[,] l)
        {
            Stack<Tuple<int, int>> _path = new Stack<Tuple<int, int>>();
            
            int numOfExits = 0;
            if (l[startI, startJ] != 0)
            {                
                return numOfExits; 
            }
            if (l[startI, startJ] == 0) _path.Push(new(startI, startJ));

            while (_path.Count > 0)
            {
                var current = _path.Pop();

                //Console.WriteLine($"{current.Item1},{current.Item2} ");
                
                l[current.Item1, current.Item2] = 1;

                if (current.Item1 + 1 < l.GetLength(0) && l[current.Item1 + 1, current.Item2] == 0)
                    _path.Push(new(current.Item1 + 1, current.Item2));

                if (current.Item2 + 1 < l.GetLength(1) && l[current.Item1, current.Item2 + 1] == 0)
                    _path.Push(new(current.Item1, current.Item2 + 1));

                if (current.Item1 > 0 && l[current.Item1 - 1, current.Item2] == 0)
                    _path.Push(new(current.Item1 - 1, current.Item2));

                if (current.Item2 > 0 && l[current.Item1, current.Item2 - 1] == 0)
                    _path.Push(new(current.Item1, current.Item2 - 1));

                if (current.Item1 + 1 == l.GetLength(0)) numOfExits++;
                if (current.Item2 + 1 == l.GetLength(1)) numOfExits++;
                if (current.Item1 == 0) numOfExits++;
                if (current.Item2 == 0) numOfExits++;
            }
            return numOfExits;
        }
    }
}