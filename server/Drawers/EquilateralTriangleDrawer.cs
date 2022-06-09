using server.TextParser;

namespace server.Drawers;

public class EquilateralTriangleDrawer : PointDrawer
{
    public EquilateralTriangleDrawer(Instruction instruction) : base(instruction.Name.ToString())
    {
        var sideMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.SideLength).ToList();
        if (sideMeasures.Count >=1)
        {
            InvalidInstruction = false;
            CalculatePoints(sideMeasures[0].Amount);
        }
    }

    public void CalculatePoints(double side1)
    {
        Points = new List<Point>();
        Points.Add(new Point(0,0));
        Points.Add(new Point(side1, 0));
        Points.Add(new Point(side1/2, side1*Math.Sin(60)));
    }
}