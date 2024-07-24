using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SparkTank.Application.Persistence.Contracts;
using SparkTank.Domain.Entities;

namespace SparkTank.Persistence.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        private readonly SparkTankAppDbContext _sparkTankAppDbContext;
        
        public UserRepository(SparkTankAppDbContext sparkTankAppDbContext) : base(sparkTankAppDbContext)
        {
            _sparkTankAppDbContext = sparkTankAppDbContext;
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            var user = await _sparkTankAppDbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }
            return user;
        }

    }
}