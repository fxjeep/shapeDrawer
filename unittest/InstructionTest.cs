using Xunit;
using server.TextParser;

namespace unittest;

public class InstructionTests
{
    //Draw a(n) <shape> with a(n) <measurement> of <amount> (and a(n) <measurement> of <amount>)
    [Theory]
    [InlineData("Draw a circle with a radius of 10", ShapeName.Name.Circle, Measurement.Name.Radius, 10)]
    [InlineData("Draw  a  square  with a side length of 11.2", ShapeName.Name.Square, Measurement.Name.SideLength, 11.2)] //add some spaces
    [InlineData("Draw  an  Equilateral triangle  with a side length of 10", ShapeName.Name.EquilateralTriangle, Measurement.Name.SideLength, 10)] //name has two words
    [InlineData("Draw  an  Pentagon with a side length of 10", ShapeName.Name.Pentagon, Measurement.Name.SideLength, 10)]
    [InlineData("Draw  an  Hexagon with a side length of 10", ShapeName.Name.Hexagon, Measurement.Name.SideLength, 10)]
    [InlineData("Draw  an  Heptagon with a side length of 10", ShapeName.Name.Heptagon, Measurement.Name.SideLength, 10)]
    [InlineData("Draw  an  Octagon with a side length of 10", ShapeName.Name.Octagon, Measurement.Name.SideLength, 10)]
    public void OneCorrectInstruction(string text, ShapeName.Name name, Measurement.Name measure, double amount)
    {
        var instruction = new Instruction(text);
        Assert.Equal(name, instruction.Name);
        Assert.Single(instruction.Actions);
        Assert.True(instruction.Actions[0].ParseOk);
        Assert.Equal(measure, instruction.Actions[0].Measure);
        Assert.Equal(amount, instruction.Actions[0].Amount);
    }

    [Theory]
    [InlineData("Draw a rectangle with a width of 10, and a height of 15", ShapeName.Name.Rectangle, Measurement.Name.Width, 10, Measurement.Name.Height, 15)]
    public void TwoCorrectInstruction(string text, ShapeName.Name name, Measurement.Name measure, double amount, Measurement.Name secondMeasure, double secondAmount)
    {
        var instruction = new Instruction(text);
        Assert.Equal(name, instruction.Name);
        Assert.Equal(2, instruction.Actions.Count);
        
        Assert.True(instruction.Actions[0].ParseOk);
        Assert.Equal(measure, instruction.Actions[0].Measure);
        Assert.Equal(amount, instruction.Actions[0].Amount);

        Assert.True(instruction.Actions[1].ParseOk);
        Assert.Equal(secondMeasure, instruction.Actions[1].Measure);
        Assert.Equal(secondAmount, instruction.Actions[1].Amount);
    }
    
    [Fact]
    public void InvalidInput()
    {
        var instruction = new Instruction("thisisainvalidtextinput");
        Assert.Equal(ShapeName.Name.None, instruction.Name);
    }

    [Fact]
    public void InvalidInput_With()
    {
        var instruction = new Instruction("thisisainvalidtextinput with someinvalidinputs");
        Assert.Equal(ShapeName.Name.None, instruction.Name);
        Assert.Equal(Measurement.Name.None, instruction.Actions[0].Measure);
    }
}