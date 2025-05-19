using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author.GetAll;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author.Register;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCxLabs.TechLibraryAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredAuthorJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterAuthorUseCase useCase,
        [FromBody] RequestRegisterAuthorJson request)
    {
        var author = await useCase.Execute(request);

        return Created(string.Empty, author);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAuthorsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll([FromServices] IGetAllAuthorUseCase useCase)
    {
        var authors = await useCase.Execute();
        
        if (authors.Authors.Count == 0)
        {
            return NoContent();
        }

        return Ok(authors);
    }
}
