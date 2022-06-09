using server.TextParser;

namespace server.Drawers;

public class ScaleneTriangleDrawer : PointDrawer
{
    public ScaleneTriangleDrawer(Instruction instruction) : base(instruction.Name.ToString())
    {
        var sideMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.SideLength).ToList();
        if (sideMeasures.Count == 3 && CanFormTriangle(sideMeasures[0].Amount, sideMeasures[1].Amount, sideMeasures[2].Amount))
        {
            InvalidInstruction = false;
            CalculatePoints(sideMeasures[0].Amount, sideMeasures[1].Amount, sideMeasures[2].Amount);
        }
    }

    public bool CanFormTriangle(double side1, double side2, double side3)
    {
        return side1+side2>=side3;
    }

    public void CalculatePoints(double side1, double side2, double side3)
    {
        var x = (side3*side3 - side1*side2 + side1*side1) / (2*side1);
        var y = Math.Sqrt(side3*side3 - x*x);
        Points = new List<Point>();
        Points.Add(new Point(0,0));
        Points.Add(new Point(side1, 0));
        Points.Add(new Point(x, y));
    }
}