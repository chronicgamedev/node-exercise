using System.Collections.Generic;

public abstract class Node
{
    public List<InputPort> Inputs = new List<InputPort>();
    public List<OutputPort> Outputs = new List<OutputPort>();

    // TODO: think about how nodes can reset this
    // se we can implement switches and repeats
    public bool IsSignaled { get; private set; }

    public void Signal()
    {
        foreach (var input in Inputs)
        {
            if (!input.IsSignaled)
            {
                // nothing to do, at least one input is not ready
                return;
            }
        }

        // if all inputs are signaled, then we can proceed
        Execute();
    }

    protected virtual void Execute()
    {
        // ASSUME: specialized node has done work before calling this base method

        // TODO: we need a way to reset this
        IsSignaled = true;
        foreach (var output in Outputs)
        {
            output.Signal();
        }
    }

    // connects an output (the source) to an input (the destination of a node further down the graph)
    public static void Connect(OutputPort source, InputPort destination)
    {
        source.Destination = destination;
        destination.Source = source;
    }
}
