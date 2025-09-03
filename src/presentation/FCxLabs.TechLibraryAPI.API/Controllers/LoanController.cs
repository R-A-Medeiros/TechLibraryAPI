using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCxLabs.TechLibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoanController : ControllerBase
    {
        [ProducesResponseType(typeof(ResponseLoanJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterLoanUseCase useCase,
            [FromBody] RequestLoanJson request)
        {
            var loan = await useCase.Execute(request);

            return Created(string.Empty, loan);
        }
    }
}
