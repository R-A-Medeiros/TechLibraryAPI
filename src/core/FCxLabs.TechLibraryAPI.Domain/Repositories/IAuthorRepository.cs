using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public interface IAuthorRepository
{
    Task Add(Author author);
}
