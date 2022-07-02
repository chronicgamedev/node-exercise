// outputs a constant number
public class ConstantNumber : Node
{
    public OutputPort<float> Number { get; set; }

    public ConstantNumber(float value)
    {
        Number = new OutputPort<float>(this);
        Number.Value = value;
        Outputs.Add(Number);
    }

    protected override void Execute()
    {
        // signal listeners
        base.Execute();
    }
}
