using 
public class Program
{
    public static void Main(string[] args)
    {
        
        Graph1 g = new Graph1(5);

        // Add edges to the graph (node u, node v, edge weight)
        g.AddEdge(0, 1, 2);
        g.AddEdge(1, 2, 3);
        g.AddEdge(2, 3, 4);
        g.AddEdge(3, 4, 5);
        g.AddEdge(0, 4, 10);

       
        double[] influenceScores = g.CalculateWeightedInfluenceScore(5);

       
        for (int i = 0; i < influenceScores.Length; i++)
        {
            Console.WriteLine($"Node {i} Influence Score: {influenceScores[i]}");
        }
    }
}