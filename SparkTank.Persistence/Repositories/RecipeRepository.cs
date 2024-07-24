using SparkTank.Application.Persistence.Contracts;
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
    public class RecipeRepository : GenericRepository<RecipeEntity>, IRecipeRepository
    {
        private readonly SparkTankAppDbContext _sparkTankAppDbContext;
        public RecipeRepository(SparkTankAppDbContext sparkTankAppDbContext) : base(sparkTankAppDbContext)
        {
            _sparkTankAppDbContext = sparkTankAppDbContext;
        }
    }
}
