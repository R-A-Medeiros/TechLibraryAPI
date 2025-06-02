using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book.Delete;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book.GetAll;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book.GetById;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book.Register;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book.Update;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCxLabs.TechLibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredBookJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices] IRegisterBookUseCase useCase, [FromBody] RequestBookJson request)
        {
            var book = await useCase.Execute(request);

            return Created(string.Empty, book);
        }


        [HttpGet]
        [ProducesResponseType(typeof(ResponseBooksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookUseCase useCase)
        {
            var books = await useCase.Execute();

            if (books.Books.Count == 0)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetById([FromServices] IGetByIdBookUseCase useCase, [FromRoute] int id)
        {
            var book = await useCase.Execute(id);
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromServices] IDeleteBookUseCase useCase, [FromRoute] int id)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromServices] IUpdateBookUseCase useCase, [FromRoute] int id, [FromBody] RequestBookJson request)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }
    }
}
