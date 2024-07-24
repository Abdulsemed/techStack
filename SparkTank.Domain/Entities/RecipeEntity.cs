using SparkTank.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Domain.Entities
{
    public class RecipeEntity : BaseEntity
    {
        public string? Title { get; set; }
        public string? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public int PreparationTime {  get; set; }
        public Guid UserEntityId { get; set; }
    }
}
