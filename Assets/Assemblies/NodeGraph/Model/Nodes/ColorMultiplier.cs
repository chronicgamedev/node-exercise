using UnityEngine;

// multiplies RGBA inputs by a value and outputs a Color32
public class ColorMultiplier : Node
{
    public InputPort<byte> R;
    public InputPort<byte> G;
    public InputPort<byte> B;
    public InputPort<byte> A;

    public InputPort<float> Multiplier;

    public OutputPort<Color32> Color;

    public ColorMultiplier()
    {
        R = new InputPort<byte>(this);
        Inputs.Add(R);
        G = new InputPort<byte>(this);
        Inputs.Add(G);
        B = new InputPort<byte>(this);
        Inputs.Add(B);
        A = new InputPort<byte>(this);
        Inputs.Add(A);

        Multiplier = new InputPort<float>(this);
        Inputs.Add(Multiplier);

        Color = new OutputPort<Color32>(this);
        Outputs.Add(Color);
    }

    protected override void Execute()
    {
        Color.Value = new Color32(
            (byte)(R.Value * Multiplier.Value),
            (byte)(G.Value * Multiplier.Value),
            (byte)(B.Value * Multiplier.Value),
            (byte)(A.Value * Multiplier.Value));

        // signal
        base.Execute();
    }
}
