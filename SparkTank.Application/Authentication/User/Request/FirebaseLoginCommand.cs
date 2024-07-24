﻿using MediatR;
using SparkTank.Application.Authentication.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Authentication.User.Request;

public class FirebaseLoginCommand : IRequest<AuthenticationResult>
{
    public string fbToken {  get; set; }
    public string userType { get; set; }
}
