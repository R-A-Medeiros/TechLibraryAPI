﻿using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

public class ResponseAuthorJson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birth { get; set; }
    public string? Nationality { get; set; }
    public ICollection<Book> Books { get; set; } = [];
}
