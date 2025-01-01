using System;
using System.Collections.Generic;

public class Graph2
{
    public Dictionary<int, List<Tuple<int, int>>> AdjList;

    public Graph2(int nodes)
    {
        AdjList = new Dictionary<int, List<Tuple<int, int>>>(nodes);
        for (int i = 0; i < nodes; i++)
        {
            AdjList[i] = new List<Tuple<int, int>>();
        }
    }

    public void AddEdge(int u, int v, int weight)
    {
        AdjList[u].Add(new Tuple<int, int>(v, weight));
        AdjList[v].Add(new Tuple<int, int>(u, weight));
    }

    public double[] CalculateWeightedInfluenceScore(int n)
    {
        double[] influenceScores = new double[n];

        for (int u = 0; u < n; u++)
        {

            SortedList<int, int> pq = new SortedList<int, int>();
            int[] distances = new int[n];
            Array.Fill(distances, int.MaxValue);
            distances[u] = 0;

            pq.Add(0, u);

            while (pq.Count > 0)
            {
                var min = pq.GetEnumerator();
                min.MoveNext();
                int v = min.Current.Value;
                pq.Remove(min.Current.Key);

                foreach (var neighbor in AdjList[v])
                {
                    int w = neighbor.Item1;
                    int weight = neighbor.Item2;

                    if (distances[v] + weight < distances[w])
                    {
                        distances[w] = distances[v] + weight;
                        pq.Add(distances[w], w);
                    }
                }
            }


            double sumOfDistances = 0;
            for (int i = 0; i < n; i++)
            {
                if (distances[i] != int.MaxValue)
                {
                    sumOfDistances += distances[i];
                }
            }


            influenceScores[u] = (double)(n - 1) / sumOfDistances;
        }

        return influenceScores;
    }
}
