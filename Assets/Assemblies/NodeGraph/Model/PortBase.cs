public abstract class PortBase
{
    // the node that owns this port
    public Node Node { get; private set; }

    public PortBase(Node node)
    {
        Node = node;
    }

    // signal indicates data is ready on a port
    public abstract void Signal();

}
