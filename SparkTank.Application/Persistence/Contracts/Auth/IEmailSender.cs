using SparkTank.Application.Responses;
using SparkTank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Persistence.Contracts.Auth
{
    public interface IEmailSender
    {
        public Task<BaseResponseClass>SendEmail(Email email);
    }
}
