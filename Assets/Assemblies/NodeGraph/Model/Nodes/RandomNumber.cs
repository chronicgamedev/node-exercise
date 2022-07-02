using UnityEngine;

// outputs a random number from [0.0..1.0]
public class RandomNumber : Node
{
    public OutputPort<float> Number;

    public RandomNumber()
    {
        Number = new OutputPort<float>(this);
        Outputs.Add(Number);
    }

    protected override void Execute()
    {
        Number.Value = Random.value;

        // signal listeners
        base.Execute();
    }
}
