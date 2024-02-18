﻿namespace Cards.Models;


//Role [Member,Admin]
public class AppUser
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;    
    public string Password { get; set; } = null!;
}
