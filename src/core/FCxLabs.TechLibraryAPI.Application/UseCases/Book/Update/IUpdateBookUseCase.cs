using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Update
{
    public interface IUpdateBookUseCase
    {
        Task Execute(int id, RequestUpdateBookJson request);
    }
}
