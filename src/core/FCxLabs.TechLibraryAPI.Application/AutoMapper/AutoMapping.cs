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
        EntityToRequest();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterAuthorJson, Author>();
    }

    private void EntityToRequest()
    {
        CreateMap<Author, ResponseRegisteredAuthorJson>();
    }
}
