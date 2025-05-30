using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book.GetAll;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book.Register;
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
        public async Task<IActionResult> Register([FromServices] IRegisterBookUseCase useCase, [FromBody] RequestRegisteredBookJson request)
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
    }
}
