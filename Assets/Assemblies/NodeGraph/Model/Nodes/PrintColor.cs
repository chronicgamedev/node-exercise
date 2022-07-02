using UnityEngine;

// displays a Color32 to the console
public class PrintColor : Node
{
    public InputPort<Color32> Color;

    public PrintColor()
    {
        Color = new InputPort<Color32>(this);
        Inputs.Add(Color);
    }

    protected override void Execute()
    {
        Debug.Log($"The color is {Color.Value}");

        // signal listeners
        base.Execute();
    }
}
