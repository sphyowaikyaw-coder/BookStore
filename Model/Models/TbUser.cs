using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dependency;

public partial class TbUser
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Format")]
    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsBlock { get; set; }

    public bool? IsDelete { get; set; }
}
