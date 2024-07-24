using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SparkTank.Domain.Entities;
using SparkTank.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Persistence;

public class SparkTankAppDbContext : DbContext
{
    public SparkTankAppDbContext(DbContextOptions<SparkTankAppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SparkTankAppDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<UserEntity> Users { get; set; }
   

}
