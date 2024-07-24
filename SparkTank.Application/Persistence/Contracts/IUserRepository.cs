using SparkTank.Domain.Entities;

namespace SparkTank.Application.Persistence.Contracts
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        public Task<UserEntity> GetByEmail(string email);
    }
}