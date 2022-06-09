using server.TextParser;

namespace server.Drawers;

public class PolygonDrawer : PointDrawer
{
    public PolygonDrawer(Instruction instruction) : base(instruction.Name.ToString())
    {
        var numOfSides = GetNumOfSides(instruction.Name);
        var sideMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.SideLength).ToList();
        if (sideMeasures.Count>=1)
        {
            var side = sideMeasures[0].Amount;
            InvalidInstruction = false;
            CalculatePoints(numOfSides, side);
        }
    }

    public int GetNumOfSides(ShapeName.Name name)
    {
        switch(name)
        {
            case ShapeName.Name.Square:
                return 4;
            case ShapeName.Name.Heptagon:
                return 7;
            case ShapeName.Name.Hexagon:
                return 6;
            case ShapeName.Name.Octagon:
                return 8;
            case ShapeName.Name.Pentagon:
                return 5;
            default: return 0;
        }
    }

    public void CalculatePoints(int numSizes, double side)
    {
        Points = new List<Point>();
        double degree = 360/numSizes;
        double angle =  Math.PI * degree / 180.0;
        var radius = side/2/Math.Sin(angle/2);
        for(var i=0; i<numSizes; i++)
        {
            var alpha = i*angle;
            Points.Add(new Point(Math.Cos(alpha)*radius, Math.Sin(alpha)*radius));
        }
    }
}