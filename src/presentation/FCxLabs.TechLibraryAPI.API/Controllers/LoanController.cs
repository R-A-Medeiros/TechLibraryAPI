using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Application.UseCases.Loan.GetAll;
using FCxLabs.TechLibraryAPI.Application.UseCases.Loan.GetById;
using FCxLabs.TechLibraryAPI.Application.UseCases.Loan.Register;
using FCxLabs.TechLibraryAPI.Application.UseCases.Loan.ReturnLoan;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCxLabs.TechLibraryAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class LoanController : ControllerBase
{
    [ProducesResponseType(typeof(ResponseRegisteredLoanJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterLoanUseCase useCase,
        [FromBody] RequestLoanJson request)
    {
        var loan = await useCase.Execute(request);

        return Created(string.Empty, loan);
    }

    [ProducesResponseType(typeof(ResponseLoanJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromServices] IGetByIdLoanUseCase useCase, [FromRoute] int id)
    {
        //var loan = await useCase.Execute();

        var loan = await useCase.Execute(id);
        return Ok(loan);

    }

    [ProducesResponseType(typeof(ResponseLoanJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromServices] IGetAllLoanUseCase useCase)
    {

        var loan = await useCase.Execute();

        if (loan.Loans.Count == 0)
        {
            return NoContent();
        }

        return Ok(loan);
    }

    [HttpPost("{loanId:int}/return")]
    [ProducesResponseType(typeof(ResponseLoanJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Authorize]
    public async Task<IActionResult> ReturnBook(int loanId, [FromServices] IReturnLoanUseCase useCase)
    {
       var loan = await useCase.Execute(loanId);
        return Ok(loan);
    }

}
