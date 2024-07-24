using SparkTank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Persistence.Contracts.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(UserEntity user, bool firebaseAuth, string image, string name,bool profileExist);
}
