using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Update
{
    public interface IUpdateAuthorUseCase
    {
        Task Execute(int id, RequestUpdateAuthorJson request);
    }
}
