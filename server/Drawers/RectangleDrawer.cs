
using server.TextParser;

namespace server.Drawers;


public class RectangleDrawer : PointDrawer
{
    public RectangleDrawer(Instruction instruction) : base(instruction.Name.ToString())
    {
        //expect one or two radius 
        var heightMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.Height).ToList();
        var widthMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.Width).ToList();
        if (heightMeasures.Count == 1 && widthMeasures.Count ==1)
        {
            InvalidInstruction = false;
            CalculatePoints((int)heightMeasures[0].Amount, (int)widthMeasures[0].Amount);
        }
    }

    public void CalculatePoints(int height, int width)
    {
        Points = new List<Point>();
        Points.Add(new Point(0, 0));
        Points.Add(new Point(0, height));
        Points.Add(new Point(width, height));
        Points.Add(new Point(width, 0));
    }
}

