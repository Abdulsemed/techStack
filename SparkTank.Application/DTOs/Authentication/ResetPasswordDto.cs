﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.DTOs.Authentication;
public class ResetPasswordDto
{
    public string NewPassword { get; set; }
    public string Email { get; set; }
}
