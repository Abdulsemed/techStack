﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Application.DTOs.RecipesDto
{
    public class CreateRecipeDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public int PreparationTime { get; set; }
    }
}
