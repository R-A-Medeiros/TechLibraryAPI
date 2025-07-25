﻿using AutoMapper;
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
        CreateMap<RequestAuthorJson, Author>();
        CreateMap<RequestBookJson, Book>();
        CreateMap<RequestUpdateAuthorJson, Author>();
        CreateMap<RequestUpdateBookJson, Book>();
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Author, ResponseRegisteredAuthorJson>();
        CreateMap<Book, ResponseRegisteredBookJson>();
        CreateMap<Author, ResponseAuthorJson>();
        CreateMap<Book, ResponseBookJson>()
            .ForMember(dest => dest.PublicationYear,opt => opt.MapFrom(src => src.PublicationYear.Year)); 
    }
}
