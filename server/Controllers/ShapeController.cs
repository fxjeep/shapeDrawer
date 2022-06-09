using Microsoft.AspNetCore.Mvc;
using server.Drawers;
using server.TextParser;

namespace server.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class ShapeController : ControllerBase
{
    [HttpPost]
    public IActionResult GetDrawing(string text)
    {
        var instruction = new Instruction(text);
        var drawer = ShapeDrawerFactory.GetDrawer(instruction);
        return Ok(drawer);
    }
}
