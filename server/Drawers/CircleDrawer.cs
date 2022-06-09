
using server.TextParser;

namespace server.Drawers;


public class CircleDrawer : DrawerBase
{
    public int Radius {get;set;} = 0;
    public CircleDrawer(Instruction instruction) : base(instruction.Name.ToString())
    {
        //expect one or two radius 
        var radiusMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.Radius).ToList();
        if (radiusMeasures.Count == 1)
        {
            Radius = (int)instruction.Actions[0].Amount;
            InvalidInstruction = false;
        }
    }
}

