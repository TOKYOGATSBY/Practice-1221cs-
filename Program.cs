using System;
using System.Collections.Generic;

class Program
{
    static bool IsValid(int[,] grid, int x, int y, int s, int N)
    {
        if (x - s < 0 || x + s >= N || y - s < 0 || y + s >= N)
            return false;

        for (int i = x - s; i <= x + s; ++i)
        {
            for (int j = y - s; j <= y + s; ++j)
            {
                if (Math.Abs(i - x) + Math.Abs(j - y) > s && grid[i, j] != 1)
                    return false;
            }
        }

        for (int i = -s; i <= s; ++i)
        {
            for (int j = -s; j <= s; ++j)
            {
                if (Math.Abs(i) + Math.Abs(j) <= s && grid[x + i, y + j] != 0)
                    return false;
            }
        }

        return true;
    }

    static void Main()
    {
        while (true)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line)) break;

            int N;
            if (!int.TryParse(line, out N) || N == 0)
                break;

            int[,] grid = new int[N, N];
            for (int i = 0; i < N; ++i)
            {
                string[] tokens = Console.ReadLine().Split();
                for (int j = 0; j < N; ++j)
                {
                    grid[i, j] = int.Parse(tokens[j]);
                }
            }

            int maxSize = 0;

            for (int s = N / 2; s >= 1; --s)
            {
                bool found = false;
                for (int x = s; x < N - s; ++x)
                {
                    for (int y = s; y < N - s; ++y)
                    {
                        if (IsValid(grid, x, y, s, N))
                        {
                            maxSize = 2 * s + 1;
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }
                if (found) break;
            }

            if (maxSize > 0)
                Console.WriteLine(maxSize);
            else
                Console.WriteLine("No solution");
        }
    }
}
