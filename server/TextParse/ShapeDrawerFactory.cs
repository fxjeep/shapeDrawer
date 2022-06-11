using server.Drawers;

namespace server.TextParser;

public interface IShapeDrawerFactory
{

}
public class ShapeDrawerFactory
{
    public static DrawerBase GetDrawer(Instruction instruction)
    {
        switch(instruction.Name)
        {
            case ShapeName.Name.Circle:
                return new CircleDrawer(instruction);
            case ShapeName.Name.Oval:
                return new OvalDrawer(instruction);
            case ShapeName.Name.Rectangle:
                return new RectangleDrawer(instruction);
            case ShapeName.Name.Parallelogram:
                return new ParallelogramDrawer(instruction);
            case ShapeName.Name.Pentagon:
            case ShapeName.Name.Hexagon:
            case ShapeName.Name.Heptagon:
            case ShapeName.Name.Octagon:
            case ShapeName.Name.Square:
                return new PolygonDrawer(instruction);
            case ShapeName.Name.EquilateralTriangle:
                return new EquilateralTriangleDrawer(instruction);
            case ShapeName.Name.IsoscelesTriangle:
                return new IsoscelesTriangleDrawer(instruction);
            case ShapeName.Name.ScaleneTriangle:
                return new ScaleneTriangleDrawer(instruction);
            default:
                return new NoneDrawer(instruction);
            
        }
    } 
}