public class ShapeName
{
    public enum Name
    {
        None = 0,
        IsoscelesTriangle = 1,    //2 sides, or 1 side + 1 height
        Square = 2,                 //1 side
        ScaleneTriangle = 3,        //3 sides, or 2 sides + 1 angle
        Parallelogram  = 4,         //2 sides, 1 height
        EquilateralTriangle = 5,   //1 side
        Pentagon  =6,               //1 side
        Rectangle = 7,              //width and height
        Hexagon  = 8,               //1 side
        Heptagon  = 9,              //1 side
        Octagon  =10,               //1 side
        Circle  =11,                //1 radius
        Oval = 12                   //1 two radius
    }

    public static Name ParseText(string name)
    {
        name = name.Replace(" ", ""); //name can have space when it has two words
        name = name.Trim();
        foreach(ShapeName.Name shape in Enum.GetValues(typeof(ShapeName.Name)))
        {
            if (shape.ToString().ToLower() == name)
            {
                return shape;
            }
        }
        return ShapeName.Name.None;
    }
}