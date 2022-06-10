using Microsoft.AspNetCore.Mvc;
using server.Drawers;
using server.TextParser;

namespace server.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class ShapeController : ControllerBase
{
    [HttpPost]
    public IActionResult Drawing(ShapeInput input)
    {
        var instruction = new Instruction(input.text);
        var drawer = ShapeDrawerFactory.GetDrawer(instruction);
        return Ok(drawer);
    }

    public class ShapeInput
    {
        public string text {get;set;}
    }
}
