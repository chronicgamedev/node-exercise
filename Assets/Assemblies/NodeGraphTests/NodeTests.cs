using NUnit.Framework;

public class NodeTests
{
    NodeGraph _graph;
    [SetUp]
    public void Setup()
    {
        _graph = new NodeGraph();
    }

    [TearDown]
    public void TearDown()
    {
        // TODO
    }

    [Test]
    public void ConstantNumberTest()
    {
        ConstantNumber constantNumber = new ConstantNumber(42);
        _graph.Add(constantNumber);

        PrintNumber printNumber = new PrintNumber();
        _graph.Add(printNumber);

        Node.Connect(constantNumber.Number, printNumber.Number);

        _graph.Execute();
    }

    [Test]
    public void RandomNumberTest()
    {
        RandomNumber randomNumber = new RandomNumber();
        _graph.Add(randomNumber);

        PrintNumber printNumber = new PrintNumber();
        _graph.Add(printNumber);

        Node.Connect(randomNumber.Number, printNumber.Number);

        _graph.Execute();
    }

    [Test]
    public void ColorMultiplierTest()
    {
        ConstantNumber red = new ConstantNumber(200);
        _graph.Add(red);

        ConstantNumber green = new ConstantNumber(100);
        _graph.Add(green);

        ConstantNumber blue = new ConstantNumber(50);
        _graph.Add(blue);

        ConstantNumber alpha = new ConstantNumber(25);
        _graph.Add(alpha);

        RandomNumber random = new RandomNumber();
        _graph.Add(random);

        ColorMultiplier colorMultiplier = new ColorMultiplier();
        _graph.Add(colorMultiplier);

        PrintColor printColor = new PrintColor();
        _graph.Add(printColor);

        Node.Connect(red.Number, colorMultiplier.R);
        Node.Connect(green.Number, colorMultiplier.G);
        Node.Connect(blue.Number, colorMultiplier.B);
        Node.Connect(alpha.Number, colorMultiplier.A);
        Node.Connect(random.Number, colorMultiplier.Multiplier);

        Node.Connect(colorMultiplier.Color, printColor.Color);

        _graph.Execute();
    }
}
