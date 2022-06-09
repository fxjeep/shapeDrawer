
using server.TextParser;

namespace server.Drawers;


public class OvalDrawer : DrawerBase
{
    public int Radius1 {get;set;} = 0;
    public int Radius2 {get;set;} = 0;
    public OvalDrawer(Instruction instruction) : base(instruction.Name.ToString())
    {
        //expect one or two radius 
        var radiusMeasures = instruction.Actions.Where(x=>x.Measure == Measurement.Name.Radius).ToList();
        if (instruction.Actions.Count == 2 && instruction.Actions[1].Measure == Measurement.Name.Radius)
        {
            Radius1 = (int)instruction.Actions[0].Amount;
            Radius2 = (int)instruction.Actions[1].Amount;
            InvalidInstruction=false;
        }
    }
}

