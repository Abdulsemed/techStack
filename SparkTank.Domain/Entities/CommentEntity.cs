using SparkTank.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Domain.Entities
{
    public class CommentEntity : BaseEntity
    {
        public string? Content { get; set; }
        public DateOnly? Date {  get; set; }
        public string? Author { get; set; }
        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
    }
}
