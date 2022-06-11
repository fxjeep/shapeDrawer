using server.TextParser;

namespace server.Drawers;

public class IsoscelesTriangleDrawer : PointDrawer
{
    public IsoscelesTriangleDrawer(Instruction instruction) : base(instruction.Name.ToString())
    {
        var widthMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.Width).ToList();
        var heightMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.Height).ToList();
        if (widthMeasures.Count == 1 && heightMeasures.Count ==1)
        {
            InvalidInstruction = false;
            CalculatePoints(widthMeasures[0].Amount, heightMeasures[0].Amount);
        }
    }

    public void CalculatePoints(double width, double height)
    {
        Points = new List<Point>();
        Points.Add(new Point(0,0));
        Points.Add(new Point(width, 0));
        Points.Add(new Point(width/2, height));
    }
}