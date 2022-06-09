using server.TextParser;

namespace server.Drawers;

public class ParallelogramDrawer : DrawerBase
{
    public List<Point> Points {get;set;} = new List<Point>();
    public ParallelogramDrawer(Instruction instruction) : base(instruction.Name.ToString())
    {
         var sideMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.SideLength).ToList();
         var angleMeasure = instruction.Actions.Where(x=>x.Measure == Measurement.Name.Angle).ToList();
         var heightMeasure = instruction.Actions.Where(x=>x.Measure == Measurement.Name.Height).ToList();
         double side1 = 0; // the slop line
         double side2 = 0; //the horizontal line 
         double angle = 0;
         double height = 0;
        if (sideMeasures.Count >= 2)
        {
            side1 = sideMeasures[0].Amount;
            side2 = sideMeasures[1].Amount;
        }

        
        if (angleMeasure.Count>=1)
        {
            angle = angleMeasure[0].Amount;
            CalculatePointsViaSidesAndAngle(side1, side2, angle);
            InvalidInstruction = false;
            return;
        }

        if (heightMeasure.Count>=1)
        {
            height = heightMeasure[0].Amount;
            CalculatePointsViaSidesAndHeight(side1, side2, height);
            InvalidInstruction = false;
            return;
        }
    }

    public void CalculatePointsViaSidesAndAngle(double side1, double side2, double angle)
    {
        var alpha = Math.PI * angle / 180.0;
        var height = (side1 * Math.Sin(alpha));
        var shift = (side1*Math.Cos(alpha));
        var intSide1 = side1;
        var intSide2 = side2;

        Points = new List<Point>();
        Points.Add(new Point(0,0));
        Points.Add(new Point(shift, height));
        Points.Add(new Point(intSide2+shift, height));
        Points.Add(new Point(intSide2, 0));
    }

    public void CalculatePointsViaSidesAndHeight(double side1, double side2, double height)
    {
        var intHeight = height;
        var shift = (Math.Sqrt(side1*side1-height*height));
        var intSide2 = side2;

        Points = new List<Point>();
        Points.Add(new Point(0,0));
        Points.Add(new Point(shift, intHeight));
        Points.Add(new Point(intSide2+shift, intHeight));
        Points.Add(new Point(intSide2, 0));
    }
}