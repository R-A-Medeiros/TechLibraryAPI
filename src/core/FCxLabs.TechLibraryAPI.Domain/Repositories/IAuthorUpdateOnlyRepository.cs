﻿using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public interface IAuthorUpdateOnlyRepository
{
    void Update(Author author);
}
