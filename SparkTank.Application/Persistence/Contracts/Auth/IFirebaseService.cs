using SparkTank.Application.Authentication.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Persistence.Contracts.Auth;
public interface IFirebaseService
{
    public Task<AuthenticationResult> RegisterUser(string fbToken, string userType);
}
