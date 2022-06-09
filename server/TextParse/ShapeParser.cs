using server.Drawers;

namespace server.TextParser;

public class ShapeParser
{
    public DrawerBase GenerateDrawingPoints(string text)
    {
        var instruction = new Instruction(text);
        var drawer = ShapeDrawerFactory.GetDrawer(instruction);
        //var points = drawer.GetPoints();
        return drawer;
    }
}