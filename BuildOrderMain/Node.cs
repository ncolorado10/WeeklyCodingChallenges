namespace BuildClass
{
    public class Node
    {
        public List<Node> Adjacent = new List<Node>();
	public char Letter;
	public visitStatus visitStatus;
    }

    public enum visitStatus
    {
        Unvisited,
	Visiting,
	Visited	
    }

}
