using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech.Application.DTOs.CommentsDto
{
    public  class GetCommentsDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
    }
}
