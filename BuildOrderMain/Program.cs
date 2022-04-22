using System;
using System.Collections.Generic;
using System.Linq;
using BuildClass;
namespace BuildOrderMain;

/* 
    I give IMMENSE credit to Youtube and .NET Fiddle for this solution.
    In this solution, the output is f,a,b,d,c,e
*/

public class Program
{
    public static void Main()
    {
        var Projects = new char[] {'a','b','c','d','e','f'};
        var Dependencies = new char[,] {{'a','f','b','f','d'}, {'d','b','d','a','c'}};

        var nodes = new Dictionary<char, Node>();
		var Start = new HashSet<Node>();

        foreach(var project in Projects)
		{
			var node = new Node {Letter = project};
			nodes.Add(project, node);
			Start.Add(node);
		}

        for(var i = 0; i < Dependencies.GetLength(1); i++)
		{
			nodes[Dependencies[1, i]].Adjacent.Add(nodes[Dependencies[0, i]]);
			Start.Remove(nodes[Dependencies[0, i]]);
		}

        var result = new List<char>();

		foreach(var start in Start)
        {
            Route(start, result);
        }
        Console.WriteLine();
        Console.WriteLine(String.Join(",", result));
        Console.WriteLine();
    }

    public static void Route(Node node, List<char> listofProjects)
	{
		node.visitStatus = visitStatus.Visiting;

		foreach(var item in node.Adjacent)
		{
			if(item.visitStatus == visitStatus.Visiting)
            {
                throw new Exception("There is no possible order!");
            }
				
			if(item.visitStatus == visitStatus.Visited)
            {
                continue;
            }
				
			Route(item, listofProjects);
		}

		node.visitStatus = visitStatus.Visited;
		listofProjects.Add(node.Letter);
	}
}