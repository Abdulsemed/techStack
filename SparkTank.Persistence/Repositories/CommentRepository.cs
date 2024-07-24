using SparkTank.Persistence;
using SparkTank.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.Persistence.Contracts;
using tech.Domain.Entities;

namespace tech.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<CommentEntity>, ICommentRepository
    {
        private readonly SparkTankAppDbContext _sparkTankAppDbContext;
        public CommentRepository(SparkTankAppDbContext sparkTankAppDbContext) : base(sparkTankAppDbContext)
        {
            _sparkTankAppDbContext = sparkTankAppDbContext;
        }
    }
}
