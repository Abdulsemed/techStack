﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Application.DTOs.UserDto;

public class EditUserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Password { get; set; }
}
