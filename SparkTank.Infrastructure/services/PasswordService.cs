﻿using BCrypt.Net;
using SparkTank.Application.Persistence.Contracts.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Infrastructure.services;
public class PasswordService : IPasswordService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string PlainPassword, string HashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(PlainPassword, HashedPassword);
    }
}
