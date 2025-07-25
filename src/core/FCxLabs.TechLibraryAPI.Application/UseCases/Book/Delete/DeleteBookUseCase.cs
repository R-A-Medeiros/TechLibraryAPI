﻿using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Delete;

public class DeleteBookUseCase : IDeleteBookUseCase
{
    private readonly IBookRepository _repository;
    private readonly IBookReadOnlyRepository _readonlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookUseCase(IBookRepository repository, IUnitOfWork unitOfWork, IBookReadOnlyRepository readonlyRepository)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _readonlyRepository = readonlyRepository;
    }
    public async Task Execute(int id)
    {
        var book = await _readonlyRepository.GetById(id);
        
        if (book is null)
        {
           throw new NotFoundException("Book not found.");
        }

         _repository.Delete(book);
        await _unitOfWork.Commit();
    }
}
