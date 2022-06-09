using Xunit;
using server.TextParser;
using server.Drawers;
using System;

namespace unittest;

public class DrawerTests
{
    [Fact]
    public void CircleDrawerTest()
    {
        var instruction = new Instruction();
        instruction.Name = ShapeName.Name.Circle;
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.Radius,
            Amount = 10
        });

        var drawer =  ShapeDrawerFactory.GetDrawer(instruction);
        Assert.IsType<CircleDrawer>(drawer);
        
        var realDrawer= drawer as CircleDrawer;
        Assert.Equal(10, realDrawer?.Radius1);
        Assert.Equal(10, realDrawer?.Radius2);
    }

    [Fact]
    public void OvalDrawerTest()
    {
        var instruction = new Instruction();
        instruction.Name = ShapeName.Name.Oval;
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.Radius,
            Amount = 10
        });
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.Radius,
            Amount = 20
        });

        var drawer =  ShapeDrawerFactory.GetDrawer(instruction);
        Assert.IsType<CircleDrawer>(drawer);
        
        var realDrawer= drawer as CircleDrawer;
        Assert.Equal(10, realDrawer?.Radius1);
        Assert.Equal(20, realDrawer?.Radius2);
    }

    [Fact]
    public void RectangleDrawerTest()
    {
        var instruction = new Instruction();
        instruction.Name = ShapeName.Name.Rectangle;
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.Height,
            Amount = 10
        });
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.Width,
            Amount = 20
        });

        var drawer =  ShapeDrawerFactory.GetDrawer(instruction);
        Assert.IsType<RectangleDrawer>(drawer);
        
        var realDrawer= drawer as RectangleDrawer;
        Assert.Equal(20, realDrawer?.Points[2].X);
        Assert.Equal(10, realDrawer?.Points[2].Y);
    }

    [Fact]
    public void ParallelogramDrawerTest()
    {
        var instruction = new Instruction();
        instruction.Name = ShapeName.Name.Parallelogram;
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.SideLength,
            Amount = 10
        });
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.SideLength,
            Amount = 20
        });
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.Angle,
            Amount = 45
        });

        var drawer =  ShapeDrawerFactory.GetDrawer(instruction);
        Assert.IsType<ParallelogramDrawer>(drawer);
        
        var realDrawer= drawer as ParallelogramDrawer;
        Assert.Equal(27.071067811865476, realDrawer?.Points[2].X);
        Assert.Equal(7.0710678118654755, realDrawer?.Points[2].Y);
    }

    [Fact]
    public void ParallelogramDrawer_WithHeight_Test()
    {
        var instruction = new Instruction();
        instruction.Name = ShapeName.Name.Parallelogram;
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.SideLength,
            Amount = 10
        });
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.SideLength,
            Amount = 20
        });
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.Height,
            Amount = 7
        });

        var drawer =  ShapeDrawerFactory.GetDrawer(instruction);
        Assert.IsType<ParallelogramDrawer>(drawer);
        
        var realDrawer= drawer as ParallelogramDrawer;
        Assert.Equal(27.141428428542852, realDrawer?.Points[2].X);
        Assert.Equal(7, realDrawer?.Points[2].Y);
    }

    [Fact]
    public void PentagonDrawer_Test()
    {
        var instruction = new Instruction();
        instruction.Name = ShapeName.Name.Pentagon;
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.SideLength,
            Amount = 10
        });

        var drawer =  ShapeDrawerFactory.GetDrawer(instruction);
        Assert.IsType<PolygonDrawer>(drawer);
        
        var realDrawer= drawer as PolygonDrawer;
        Assert.Equal(5, realDrawer?.Points.Count);
        Assert.True(AlmostEqualTo(8.506508, realDrawer?.Points[0].X));
    }

     [Fact]
    public void HexagonDrawer_Test()
    {
        var instruction = new Instruction();
        instruction.Name = ShapeName.Name.Hexagon;
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.SideLength,
            Amount = 10
        });

        var drawer =  ShapeDrawerFactory.GetDrawer(instruction);
        Assert.IsType<PolygonDrawer>(drawer);
        
        var realDrawer= drawer as PolygonDrawer;
        Assert.Equal(6, realDrawer?.Points.Count);
        Assert.True(AlmostEqualTo(10, realDrawer?.Points[0].X));
    }

     [Fact]
    public void HeptagonDrawer_Test()
    {
        var instruction = new Instruction();
        instruction.Name = ShapeName.Name.Heptagon;
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.SideLength,
            Amount = 10
        });

        var drawer =  ShapeDrawerFactory.GetDrawer(instruction);
        Assert.IsType<PolygonDrawer>(drawer);
        
        var realDrawer= drawer as PolygonDrawer;
        Assert.Equal(7, realDrawer?.Points.Count);
        Assert.True(AlmostEqualTo(11.6141024, realDrawer?.Points[0].X));
    }

     [Fact]
    public void OctagonDrawer_Test()
    {
        var instruction = new Instruction();
        instruction.Name = ShapeName.Name.Octagon;
        instruction.Actions.Add(new server.TextParser.Action(){
            Measure = Measurement.Name.SideLength,
            Amount = 10
        });

        var drawer =  ShapeDrawerFactory.GetDrawer(instruction);
        Assert.IsType<PolygonDrawer>(drawer);
        
        var realDrawer= drawer as PolygonDrawer;
        Assert.Equal(8, realDrawer?.Points.Count);
        Assert.True(AlmostEqualTo(13.0656296, realDrawer?.Points[0].X));
    }

    public static bool AlmostEqualTo(double value1, double? value2)
    {
        if (!value2.HasValue) return false;

        return Math.Abs(value1 - value2.Value) < 0.0000001; 
    }

}