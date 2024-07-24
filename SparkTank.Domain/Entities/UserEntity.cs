using SparkTank.Domain.Entities.Common;

namespace SparkTank.Domain.Entities;

public class UserEntity: BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}