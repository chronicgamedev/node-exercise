using UnityEngine;

// displays a number to the console
public class PrintNumber : Node
{
    public InputPort<float> Number;

    public PrintNumber()
    {
        Number = new InputPort<float>(this);
        Inputs.Add(Number);
    }

    protected override void Execute()
    {
        Debug.Log($"The number is {Number.Value}");

        // signal listeners
        base.Execute();
    }
}
