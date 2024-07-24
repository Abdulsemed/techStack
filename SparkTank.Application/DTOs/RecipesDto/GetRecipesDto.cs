using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Application.DTOs.RecipesDto
{
    public class GetRecipesDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
    }
}
