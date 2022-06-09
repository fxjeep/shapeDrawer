namespace server.TextParser;

public class Measurement
{
    public enum Name
    {
        None = 0,
        SideLength = 1,
        Width = 2,
        Height = 3,
        Angle = 4,
        Radius = 5
    }

    public static Measurement.Name ParseText(string text)
    {
        text = text.Replace(" ", "");
        text = text.Trim();
        foreach(Measurement.Name shape in Enum.GetValues(typeof(Measurement.Name)))
        {
            if (shape.ToString().ToLower() == text)
            {
                return shape;
            }
        }
        return Measurement.Name.None;
    }
}