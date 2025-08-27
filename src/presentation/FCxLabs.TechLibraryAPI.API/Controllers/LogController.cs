using FCxLabs.TechLibraryAPI.Domain.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCxLabs.TechLibraryAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogController : ControllerBase
{
    private readonly ILogActionRepository _logRepo;

    public LogController(ILogActionRepository logRepo)
    {
        _logRepo = logRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetLogs([FromQuery] int skip = 0, [FromQuery] int take = 100)
    {
        var logs = await _logRepo.GetAllAsync(skip, take);
        return Ok(logs);
    }
}
