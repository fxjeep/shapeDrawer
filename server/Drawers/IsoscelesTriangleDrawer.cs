using server.TextParser;

namespace server.Drawers;

public class IsoscelesTriangleDrawer : PointDrawer
{
    public IsoscelesTriangleDrawer(Instruction instruction) : base(instruction.Name.ToString())
    {
        var sideMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.SideLength).ToList();
        if (sideMeasures.Count == 2 && CanFormTriangle(sideMeasures[0].Amount, sideMeasures[2].Amount))
        {
            InvalidInstruction = false;
            CalculatePoints(sideMeasures[0].Amount, sideMeasures[1].Amount);
        }
    }

    public bool CanFormTriangle(double side1, double side2)
    {
        return side1+side1>=side2;
    }

    public void CalculatePoints(double side1, double side2)
    {
        var height = Math.Sqrt(side1*side1+(side2/2)*(side2/2));
        Points = new List<Point>();
        Points.Add(new Point(0,0));
        Points.Add(new Point(side2, 0));
        Points.Add(new Point(side2/2, height));
    }
}