﻿using System.ComponentModel.DataAnnotations;

namespace Fitlance.Dtos;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}