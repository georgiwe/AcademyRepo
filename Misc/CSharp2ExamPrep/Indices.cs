using System;
using System.Text;
using System.Collections.Generic;

class Indices
{
    static void Main()
    {   // start 20:40, end - 21:30
        int n = int.Parse(Console.ReadLine());
        int[] indices = new int[n];
        bool[] visited = new bool[n];

        int indOfCyc = 0;

        foreach (var item in Console.ReadLine().Split()) 
            indices[indOfCyc++] = int.Parse(item);

        var seq = new List<int>();
        int ind = 0;
        bool cycle = false;

        seq.Add(0);
        visited[0] = true;
        indOfCyc = -1;

        while (true)
        {
            indOfCyc = ind;
            ind = indices[ind];

            if ((ind >= 0 && ind < indices.Length) == false) break;

            if (visited[ind]) { cycle = true; break; }

            visited[ind] = true;

            seq.Add(ind);
        }

        GC.Collect(); // THIS!!

        if (!cycle) Console.WriteLine(String.Join(" ", seq));
        else
        {
            var indexOfIt = seq.IndexOf(indices[indOfCyc]);

            var result = new StringBuilder();

            for (int i = 0; i < seq.Count; i++)
            {
                bool hasIt = i == indexOfIt;

                if (hasIt && result.Length > 0) result[result.Length - 1] = '(';
                else if (hasIt && result.Length == 0) result.Append('(');

                result.Append(seq[i]);
                result.Append(' ');
            }

            result[result.Length - 1] = ')';

            Console.WriteLine(result.ToString());
        }
    }
}
