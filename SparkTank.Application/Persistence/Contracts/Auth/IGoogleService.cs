using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Persistence.Contracts.Auth;
public interface IGoogleService
{
    public Task<string> UploadFile(IFormFile File);
}
