using System.Collections.Generic;

public class NodeGraph 
{
    private List<Node> _nodes = new List<Node>();

    public void Add(Node node)
    {
        _nodes.Add(node);
    }

    // runs the graph
    // it's just one go, there are no cycles tracked 
    public void Execute()
    {
        // find all the root nodes (those with no input ports) and Execute them
        foreach(var node in _nodes)
        {
            if (node.Inputs == null || node.Inputs.Count == 0)
            {
                node.Signal();
            }
        }
    }

}
