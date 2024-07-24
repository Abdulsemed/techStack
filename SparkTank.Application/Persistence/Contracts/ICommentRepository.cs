using SparkTank.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Domain.Entities;

namespace tech.Application.Persistence.Contracts
{
    public interface ICommentRepository : IGenericRepository<CommentEntity>
    {
    }
}
