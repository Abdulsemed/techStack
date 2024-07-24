using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SparkTank.Application.Persistence.Contracts;
using SparkTank.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Application.Persistence.Contracts;
using tech.Persistence.Repositories;

namespace SparkTank.Persistence;
public static class PersistenceDependencyInjection
{
    public static IServiceCollection ConfigurePersitenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        DotNetEnv.Env.Load("../.env");
        string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        services.AddDbContext<SparkTankAppDbContext>(opt => opt.UseNpgsql(connectionString));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        return services;
    }
}
