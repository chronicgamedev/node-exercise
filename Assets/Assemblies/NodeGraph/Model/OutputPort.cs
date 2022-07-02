
using System;
using UnityEngine;

// An OutputPort provides a value
public abstract class OutputPort : PortBase
{
    // where does my output go?
    public InputPort Destination { get; set; }

    public OutputPort(Node node) : base(node) { }

    // type converting value getter
    public abstract T GetValueAs<T>();
}

public class OutputPort<T> : OutputPort
{
    public OutputPort(Node node) : base(node) { }

    // typed value
    public T Value { get; set; }

    // conversion implementation
    public override U GetValueAs<U>()
    {
        try
        {
            return (U)Convert.ChangeType(Value, typeof(U));
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            throw;
        }
    }

    // tell my destination node that data is ready
    public override void Signal()
    {
        Destination.Signal();
    }
}
