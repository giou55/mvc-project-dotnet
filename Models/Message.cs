﻿using System.ComponentModel.DataAnnotations;

namespace mvc_project_dotnet.Models;

public class Message
{
    [Required(ErrorMessage = "Please enter your name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter your email address")]
    [EmailAddress]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please enter your message")]
    [StringLength(maximumLength: 100, MinimumLength = 10)]
    public string? Body { get; set; }
}
