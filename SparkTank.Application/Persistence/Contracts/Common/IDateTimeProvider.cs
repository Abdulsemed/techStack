﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkTank.Application.Persistence.Contracts.Common;

public interface IDateTimeProvider
{
    DateTime CreateTime { get;}
}
