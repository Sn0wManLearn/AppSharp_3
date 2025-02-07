using System;

namespace AppSharp_3
{
    class MyClass
    {
        static void Main()
        {
            Stack<Tuple<int, int>> _path = new Stack<Tuple<int, int>>();

            int[,] labirynth1 = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 0 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 }
            };

            FindPath(1, 1);


            bool FindPath(int i, int j)
            {
                Console.WriteLine(labirynth1[i, j]);
                if (labirynth1[i, j] == 0) _path.Push(new(i, j));

                while (_path.Count > 0)
                {
                    var current = _path.Pop();

                    Console.WriteLine($"{current.Item1},{current.Item2} ");
                    if (labirynth1[current.Item1, current.Item2] == 2)
                    {
                        Console.WriteLine($"Путь найден {current.Item1},{current.Item2} ");
                        return true;
                    }

                    labirynth1[current.Item1, current.Item2] = 1;

                    if (current.Item1 + 1 < labirynth1.GetLength(0)
                    && labirynth1[current.Item1 + 1, current.Item2] != 1)
                        _path.Push(new(current.Item1 + 1, current.Item2));

                    if (current.Item2 + 1 < labirynth1.GetLength(1) &&
                    labirynth1[current.Item1, current.Item2 + 1] != 1)
                        _path.Push(new(current.Item1, current.Item2 + 1));

                    if (current.Item1 > 0 && labirynth1[current.Item1 - 1, current.Item2] != 1)
                        _path.Push(new(current.Item1 - 1, current.Item2));

                    if (current.Item2 > 0 && labirynth1[current.Item1, current.Item2 - 1] != 1)
                        _path.Push(new(current.Item1, current.Item2 - 1));
                }

                Console.WriteLine("Пути нет");
                return false;

            }
        }
    }
}