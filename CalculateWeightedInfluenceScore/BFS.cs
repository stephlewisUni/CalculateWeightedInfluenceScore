using System;
using System.Collections.Generic;

public class Graph1
{
    public Dictionary<int, List<int>> AdjList; 

    public Graph1(int nodes)
    {
        AdjList = new Dictionary<int, List<int>>(nodes);
        for (int i = 0; i < nodes; i++)
        {
            AdjList[i] = new List<int>();
        }
    }

    
    public void AddEdge(int u, int v)
    {
        AdjList[u].Add(v);
        AdjList[v].Add(u); 
    }

    public double[] ScoreCalc(int n)
    {
        double[] influenceScores = new double[n];

       
        for (int u = 0; u < n; u++)
        {
           
            Queue<int> queue = new Queue<int>();
            int[] distances = new int[n];
            Array.Fill(distances, -1);
            distances[u] = 0;

            queue.Enqueue(u); 

            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                foreach (var w in AdjList[v])
                {
                    if (distances[w] == -1)
                    {
                        distances[w] = distances[v] + 1;
                        queue.Enqueue(w);
                    }
                }
            }

          
            double sumOfDistances = 0;
            for (int i = 0; i < n; i++)
            {
                if (distances[i] != -1)
                {
                    sumOfDistances += distances[i];
                }
            }

            
            influenceScores[u] = (n - 1) / sumOfDistances;
        }

        return influenceScores;
    }
}
