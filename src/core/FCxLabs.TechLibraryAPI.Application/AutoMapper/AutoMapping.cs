using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisteredAuthorJson, Author>();
        CreateMap<RequestRegisteredBookJson, Book>();
        CreateMap<RequestUpdateAuthorJson, Author>();
        CreateMap<RequestUpdateBookJson, Book>();
    }

    private void EntityToResponse()
    {
        CreateMap<Author, ResponseRegisteredAuthorJson>();
        CreateMap<Book, ResponseRegisteredBookJson>();
        CreateMap<Author, ResponseAuthorJson>();
        CreateMap<Book, ResponseBookJson>();
    }
}
