namespace server.Drawers;

public class Point
{
    public double X {get;set;}
    public double Y {get;set;}

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

}

public abstract class DrawerBase
{
    public bool InvalidInstruction {get;set;} = true;
    public string Name {get;set;}
    public string SVGType {get;set;}
    public DrawerBase(string name, SVGType type)
    {
        Name = name;
        SVGType = type.ToString();
    }
}

public abstract class PointDrawer : DrawerBase
{
    public List<Point> Points {get;set;} = new List<Point>();
    public PointDrawer(string name) : base(name, Drawers.SVGType.Path){ } 

}

public enum SVGType
{
    None = 0,
    Circle = 1,
    Oval = 2,
    Path = 3
}