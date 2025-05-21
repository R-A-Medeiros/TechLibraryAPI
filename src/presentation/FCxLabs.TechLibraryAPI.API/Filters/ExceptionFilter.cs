using FCxLabs.TechLibraryAPI.Application.ExceptionsBase;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FCxLabs.TechLibraryAPI.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is TechLibraryException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var techLibaryException = context.Exception as TechLibraryException;
            var errorResponse = new ResponseeErrorJson(techLibaryException!.GetErrors());

            context.HttpContext.Response.StatusCode = techLibaryException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            var errorResponse = new ResponseeErrorJson("Unknow error");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
