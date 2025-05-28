using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author.Delete;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author.GetAll;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author.GetById;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author.Register;
using FCxLabs.TechLibraryAPI.Application.UseCases.Author.Update;
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
        [FromBody] RequestRegisteredAuthorJson request)
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
    
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseAuthorJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetById([FromServices] IGetByIdAuthorUseCase useCase, [FromRoute] int id)
    {
        var author = await useCase.Execute(id);
        return Ok(author);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromServices] IDeleteAuthorUseCase useCase, [FromRoute] int id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateAuthorUseCase useCase, 
        [FromRoute] int id, 
        [FromBody] RequestUpdateAuthorJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}
