using System.Text.RegularExpressions;

namespace server.TextParser;

public class Action{
    public Measurement.Name Measure {get;set;} = Measurement.Name.None;
    public double Amount {get;set;}
    public string Input {get;set;} = "";
    public bool ParseOk {get;set;} = false;
}

public class Instruction
{
    public const string With = "with";
    public static Regex ActionRegex = new Regex(@"an?\s+([a-zA-Z ]+)\s+of\s+([0-9\.?]+)\s*(?:and)?", RegexOptions.IgnoreCase);
    public static Regex NameRegex = new Regex(@"draw\s+an?\s+([a-zA-Z ]+)", RegexOptions.IgnoreCase);
    public ShapeName.Name Name {get;set;} = ShapeName.Name.None;
    public string NameInput {get;set;} = "";

    public List<Action> Actions {get;set;} = new List<Action>();

    public Instruction(string text)
    {
        Parse(text);
    }

    public Instruction(){}
    
    public void Parse(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        //Draw a(n) <shape> with a(n) <measurement> of <amount> (and a(n) <measurement> of <amount>)
        var lowerCase = text.ToLower();
        var nameAndRest=lowerCase.Split(new string[]{With}, StringSplitOptions.RemoveEmptyEntries);

        if (nameAndRest.Length>=1)
        {
            Name = ExtractName(nameAndRest[0]);
            NameInput = nameAndRest[0];
        }

        if (nameAndRest.Length>=2)
        {
            Actions = ExtractActions(nameAndRest[1]);
        }
    }

    public ShapeName.Name ExtractName(string text)
    {
        Match match = NameRegex.Match(text);
        if (match.Success && match.Groups.Count>=2)
        {
            return ShapeName.ParseText(match.Groups[1].Value);
        }
        return ShapeName.Name.None;
    }

    public List<Action> ExtractActions(string text)
    {
        var list = new List<Action>();
        // a(n) <measurement> of <amount> (and a(n) <measurement> of <amount>)
        var segements = text.Split(new string[]{"and"}, StringSplitOptions.RemoveEmptyEntries);
        foreach(var seg in segements)
        {
            var action = ParseAction(seg);
            list.Add(action);
        }
        return list;
    }

    public Action ParseAction(string seg)
    {
        seg = seg.Trim();
        var action = new Action();
        action.Input = seg;
        var match = ActionRegex.Match(seg);
        if (match.Groups.Count >= 2)
        {
            var actionName = match.Groups[1].Value;
            var enumName = Measurement.ParseText(actionName);
            action.Measure = enumName;
        }
        if (match.Groups.Count>=3)
        {
            var measure = match.Groups[2].Value;
            double decMeasure;
            if(double.TryParse(measure, out decMeasure))
            {
                action.Amount = decMeasure;
                action.ParseOk = true;
            }
        }
        return action;
    }

    
}







