
using server.TextParser;

namespace server.Drawers;


public class NoneDrawer : DrawerBase
{
    public List<Point> Points {get;set;} = new List<Point>();
    public NoneDrawer(Instruction instruction) : base(instruction.Name.ToString(), Drawers.SVGType.None)
    {

    }
}

