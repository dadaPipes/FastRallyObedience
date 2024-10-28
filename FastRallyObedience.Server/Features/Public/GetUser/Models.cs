﻿namespace GetUser;

public sealed class Response
{
    public int Id { get; set; }
    public string Name{ get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}