﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Persistence.Contracts.Auth;

public interface IStringValidator
{
    public string TrimFromStart(string value, string Identifier);
    public string TrimFromEnd(string value, string Identifier);
    public string GetLastIndexValue(string value);
}
