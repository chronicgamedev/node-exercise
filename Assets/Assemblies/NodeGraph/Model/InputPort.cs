// an InputPort expects a value to be provided

public abstract class InputPort : PortBase
{
    // where does my input come from (TODO: should be design/runtime type checks)
    public OutputPort Source { get; set; }

    // has my source completed its work
    public bool IsSignaled { get { return Source != null && Source.Node.IsSignaled; } }

    public InputPort(Node node) : base(node) { }
}

public class InputPort<T> : InputPort
{

    // this is a temporary way to coerce compatible types since I don't have a type system
    public T Value { get { return Source.GetValueAs<T>(); } }

    public InputPort(Node node) : base(node) { }

    // tell my node that my input is ready
    public override void Signal()
    {
        Node.Signal();
    }
}
