﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Persistence.Contracts.Auth;
public interface IOpenAiServices
{
    public  Task<string> ExtractPdfToJson(string texts);
    public Task<string> MakeitProffessional(string text, string type);
    public Task<string> SparkyByQuery(string text, string param, string query);
}
